using StreamingService.Model;
using StreamingService.Repository;

var builder = WebApplication.CreateBuilder(args);

MovieRepository n = new MovieRepository();

Movie result = await n.GetMovie("Star Wars");

Console.WriteLine($"The metadata is: {result.Title}, {result.Genre}");
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


//app.MapEndpoints();


app.Run();
