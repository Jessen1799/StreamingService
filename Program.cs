using MongoDB.Driver;
using StreamingService.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Open a connection to the MongoDB server
string connectionString = "mongodb://mongodb:27017/";

// Create a MongoClient instance
var client = new MongoClient(connectionString);

// Get the database named "StreamingService"
var database = client.GetDatabase("StreamingService");

// Get the collection of movies in mongodb
var moviesCollection = database.GetCollection<Movie>("Movies");

long count = moviesCollection.CountDocuments(Builders<Movie>.Filter.Empty);
Console.WriteLine($"Number of movies: {count}");

/*moviesCollection.Find(Builders<Movie>.Filter.Empty).ToList().ForEach(movie =>
{
    Console.WriteLine($"Title: {movie.Title}, Category: {movie.Category}");
});*/




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    { options.SwaggerEndpoint("/openapi/v1.json", app.Environment.ApplicationName); });
}



app.UseHttpsRedirection();


//app.MapEndpoints();

app.Run();


