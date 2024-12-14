using GameStore.API.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<GameDto> games = [
    new(
        1,
        "Dark Souls 3",
        "Fanstasy,SoulsLike",
        59.99M,
        new DateOnly(2000,12,23)),
    new(
        2,
        "FIFA 2024",
        "Sport",
        69.99M,
        new DateOnly(2024,1,1)),
    new(
        3,
        "Final Fantasy XIV",
        "RPG",
        59.99M,
        new DateOnly(2010,9,30))
];

app.MapGet("games", () => games);
app.MapGet("/", () => "Hello World!");

app.Run();
