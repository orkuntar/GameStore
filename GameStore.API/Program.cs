using GameStore.API.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const string GetGameEndpointName = "GetGame";

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
// Get /games
app.MapGet("games", () => games);

// Get/games/1
app.MapGet("/games/{Id}", (int Id) => games.Find(game => game.Id == Id))
.WithName(GetGameEndpointName);

//POST /games
app.MapPost("games", (CreateGameDto newGame) => 
    {
        GameDto game = new (
            games.Count + 1,
            newGame.Name,
            newGame.Genre,
            newGame.Price,
            newGame.ReleaseDate
        );
        games.Add(game);
        return Results.CreatedAtRoute(GetGameEndpointName, new {id = game.Id}, game);
    });

// PUT /games

app.MapPut("games/{Id}", (int id, UpdateGameDto updatedGame) => {
    var index = games.FindIndex(game => game.Id == id);

    games[index] = new GameDto(
        id,
        updatedGame.Name,
        updatedGame.Genre,
        updatedGame.Price,
        updatedGame.ReleaseDate
    );
    return Results.NoContent();
});

app.Run();
