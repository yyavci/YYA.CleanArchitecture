using YYA.CleanArchitecture.Persistence;
using YYA.CleanArchitecture.Application;
using YYA.CleanArchitecture.Persistence.Context;
using Microsoft.AspNetCore.HttpLogging;
using YYA.CleanArchitecture.Middlewares;

var builder = WebApplication.CreateBuilder(args);

//configuration fields
bool useInMemoryDb = builder.Configuration.GetValue<bool>("UseInMemoryDb");
//

//loggings
builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;
});

builder.Services.AddLogging(conf =>
{
    conf.AddConsole();
});
//

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//add dependency injections
builder.Services.AddPersistanceServices(useInMemoryDb: useInMemoryDb);
builder.Services.AddApplicationServices();
//

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseHttpLogging();

//adds middlewares from infrastucture.middlewares
app.AddCustomMiddlewares();

//seed data
if (useInMemoryDb)
{
    using var scope = app.Services.CreateScope();
    var dataContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    new Seed().SeedData(dataContext);
}
//

app.Run();
