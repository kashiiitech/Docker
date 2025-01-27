using System.Data.SqlClient;
using Dapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

var app = builder.Build();

app.UseCors(x => x.AllowAnyOrigin());

app.MapGet("/", () => "Hello world");

app.MapGet("/podcasts", async () =>
{
    using var db = new SqlConnection("Server=tcp:localhost;Initial Catalog=podcasts;Persist Security Info=False;User ID=sa;Password=Admin@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;");

    // Open the connection
    await db.OpenAsync();

    var podcasts = await db.QueryAsync<Podcast>("SELECT * FROM Podcasts");
    return podcasts.Select(x => x.Title);
});


app.Run();


record class Podcast(Guid Id, string Title);
