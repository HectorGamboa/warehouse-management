using WH.Application;
using WH.Infrastructure;
using System.Text.Json.Serialization;
using WH.Api.Authentication;
using WH.Infrastructure.Persistence.Seeders;
using WH.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);
var Cors = "Cors";
var environment = builder.Environment.EnvironmentName;
var allowedOrigins = environment == "Development"
    ? new[] { "http://localhost:4200" }
    : new[] { "https://mi-sitio.com", "https://api.mi-sitio.com" };
// Add services to the container.
builder.Services
    .AddInfrastructure(builder.Configuration)
    .AddApplication()
    .AddAuthentication(builder.Configuration);

// Registro de DatabaseSeeder
builder.Services.AddTransient<DatabaseSeeder>();
builder.Services
    .AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: Cors,
        builder =>
        {
            builder.WithOrigins(allowedOrigins);
            builder.AllowAnyMethod();
            builder.AllowAnyHeader();
        });
});

var app = builder.Build();
app.UseCors(Cors);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.AddMiddleware();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbSeeder = services.GetRequiredService<DatabaseSeeder>();
    await dbSeeder.SeedAsync();
}

app.Run();
