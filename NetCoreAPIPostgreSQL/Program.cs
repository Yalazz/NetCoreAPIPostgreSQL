using NetCoreAPIPostgreSQL;
using NetCoreAPIPostgreSQL.Data;
using NetCoreAPIPostgreSQL.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// PostgreSQL yap�land�rmas�n� ekleyin
var postgreSQLConnectionConfiguration = new PostgreSQLConfiguration(builder.Configuration.GetConnectionString("PostgreSQLConnection"));
builder.Services.AddSingleton(postgreSQLConnectionConfiguration);

// CarRepository ba��ml�l���n� ekleyin
builder.Services.AddScoped<ICarRepository, CarRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware'leri yap�land�r�n
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();















//var startup = new Startup(builder.Configuration); // My custom startup class.

//startup.ConfigureServices(builder.Services); // Add services to the container.

//var app = builder.Build();

//startup.Configure(app, app.Environment); // Configure the HTTP request pipeline.

//app.Run();
