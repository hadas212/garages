using GarageApi.Data;
using GarageApi.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// הגדרות Mongo
builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDbSettings"));

// DI ל-Services
builder.Services.AddSingleton<GaragesDbService>();
builder.Services.AddHttpClient<GovernmentApiService>();

// Controllers + Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Garage API", Version = "v1" });
});

// ⭐ הוספת CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

// CORS חייב להיות לפני Controllers
app.UseCors("AllowAngular");

// Swagger
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
