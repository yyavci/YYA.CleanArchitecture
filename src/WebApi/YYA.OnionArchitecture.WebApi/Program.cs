using YYA.OnionArchitecture.Persistence;
using YYA.OnionArchitecture.Application;
using YYA.OnionArchitecture.Persistence.Context;
using Microsoft.AspNetCore.HttpLogging;
using YYA.OnionArchitecture.Middlewares;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

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


builder.Services.AddOptions();
//

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "YYA Onion Architecture API",
        Version = "v1"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please insert JWT with Bearer into field like **Bearer YOUR_JWT_TOKEN**",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
    {
      new OpenApiSecurityScheme
      {
          Name = "Bearer",
          In = ParameterLocation.Header,
          Reference = new OpenApiReference
          {
            Id = "Bearer",
            Type = ReferenceType.SecurityScheme
          }
      },
      new string[] { }
    }
  });
});

//add dependency injections
builder.Services.AddPersistanceServices(builder.Configuration);
builder.Services.AddMiddlewareServices(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);
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
if (builder.Configuration.GetValue<bool>("UseInMemoryDatabase"))
{
    using var scope = app.Services.CreateScope();
    var dataContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    new Seed().SeedData(dataContext);
}
//

app.Run();
