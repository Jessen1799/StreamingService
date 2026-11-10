using StreamingService.Endpoint;
using StreamingService.Model;
using StreamingService.Repository;
using StreamingService.Services;

var builder = WebApplication.CreateBuilder(args);

IMovieRepository n = new MovieRepository();

//Get specific move based off title test from db
Movie result = await n.GetMovie("Star Wars");
Console.WriteLine($"The metadata is: {result.Title}, {result.Genre}");


//GetAll test from db
List<Movie> result2 = n.GetAllMovies();
foreach (var movie in result2)
{
    Console.WriteLine(movie.Title);
}

//Insert test into db
//Movie testInsert = new Movie(13, "Love at first sight", "Romantic");
//n.AddMovie(testInsert);
//Console.WriteLine("Inserted into database?");

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
app.UseHttpsRedirection();

//app.UseAuthorization();


app.MapMovieEndpoints();

app.Run();
