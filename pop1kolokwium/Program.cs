using pop1kolokwium.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IDbService, DbService>();

builder.Configuration.AddJsonFile("appsettings.json");

var app = builder.Build();

app.UseAuthorization();
app.MapControllers();
app.Run();