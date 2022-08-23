using MongoDB.Driver;
using MongoDB.Bson;


var builder = WebApplication.CreateBuilder(args);

// Fetch our connection string from appsettings which is available in the builder's Configuration
var connectionString = builder.Configuration["GamesDatabaseSettings:ConnectionString"];

MongoClient mongoDBClient = new MongoClient(connectionString);

List<string> databases = mongoDBClient.ListDatabaseNames().ToList();

foreach(string db in databases)
{
    Console.WriteLine(db);

}

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();
