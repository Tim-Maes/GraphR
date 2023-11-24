using GrapR.API.GraphApi.Query;
using GrapR.WebAPI;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddSolutionComponents(configuration);

builder.Services.AddGraphQLServer()
    .AddQueryType<Query>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapGraphQL();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
