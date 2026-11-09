using MongoDB.Driver;
using StreamingService.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    { options.SwaggerEndpoint("/openapi/v1.json", app.Environment.ApplicationName); });
}

var connectionString = "mongodb://localhost:27017/";
MongoClient testClient = new MongoClient(connectionString);

var database = testClient.GetDatabase("dbStreamingService"); 

var movieCollection = database.GetCollection<Movie>("testet");

movieCollection.Find(m => m.Title == "T");


app.UseHttpsRedirection();


//app.MapEndpoints();


app.Run();
