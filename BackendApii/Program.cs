using System.Data.SqlClient;
using Dapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors("AllowAll");

app.MapGet("/", () => "Hello world");

app.MapGet("/podcasts", async () =>
{

    var db = new SqlConnection("Server=tcp:database;Initial Catalog=podcasts;Persist Security Info=False;User ID=sa;Password=Dometrain#123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;");

    // Open the connection
    await db.OpenAsync();

    return (await db.QueryAsync<Podcast>("SELECT * FROM Podcasts")).Select(x => x.Title);
});


app.Run();


record class Podcast(Guid Id, string Title);
