var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors();

var app = builder.Build();

app.UseCors(x => x.AllowAnyOrigin());

app.MapGet("/podcasts", () => new List<string>
{
    "Podcast 1 - Kashif",
    "Podcast 2 - Muzamil",
    "Podcast 3 - Usaid",
    "Podcast 4 - Ali",
    "Podcast 5 - Ahsan",
    "Podcast 6 - Ahsan",
    "Podcast 7 - Ahsan",
    "Podcast 8 - Ahsan",
});

app.Run();
