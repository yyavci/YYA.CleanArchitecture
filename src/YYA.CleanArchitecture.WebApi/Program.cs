using YYA.CleanArchitecture.Persistence;
using YYA.CleanArchitecture.Application;
using YYA.CleanArchitecture.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
bool useInMemoryDb = builder.Configuration.GetValue<bool>("UseInMemoryDb");

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

//seed data
if (useInMemoryDb)
{
    using var scope = app.Services.CreateScope();
    var dataContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    new Seed().SeedData(dataContext);
}
//

app.Run();
