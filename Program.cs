using StreamingService.Endpoint;
using StreamingService.Repository;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//Builds a service that gives a MovieRepository instance when IMovieRepository is being called for
builder.Services.AddSingleton<IMovieRepository, MovieRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseHttpsRedirection();

app.MapMovieEndpoints();

app.Run();
