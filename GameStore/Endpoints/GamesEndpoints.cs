using GameStore.Data;
using GameStore.Dtos;
using GameStore.Entities;
using GameStore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Endpoints;

/**************************************************************************************
The reason to make this a static is that in this way we dont need to make an instance of this class to be used
**************************************************************************************/
public static class GamesEndpoints
{
    const string GetGameEndpointName = "GetGame";

    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("games").WithParameterValidation();

        //Get /games
        /**************************************************************************************
        Defining GET endpoint, return all games => also return the Genre data.
        Selecting each record and transform the records to Data Transfer Objects.
        Skip tracking to the entities, result is returned as a list
        **************************************************************************************/
        group.MapGet(
            "/",
            async (GameStoreContext dbContext) =>
                await dbContext
                    .Games.Include(game => game.Genre)
                    .Select(game => game.ToGameSummaryDto())
                    .AsNoTracking()
                    .ToListAsync()
        );

        //GET /games/{id}
        /**************************************************************************************
        Defining GET endpoint, find where game.id matches the id from lambda expression,
        If the game was not found and is null respond with NotFound otherwise respond
        with OK and the game that is transformed to Data Transfer Object
        **************************************************************************************/
        group
            .MapGet(
                "/{id}",
                async (int id, GameStoreContext dbContext) =>
                {
                    Game? game = await dbContext.Games.FindAsync(id);

                    return game is null ? Results.NotFound() : Results.Ok(game.ToGameDetailsDto());
                }
            )
            .WithName(GetGameEndpointName);

        // POST /games
        /**************************************************************************************
        Defining POST endpoint, converting the entity to a Game entity for server.
        Adding the new Game entity to the server and saving the changes.
        Return the newly created entity object and the location of it
        **************************************************************************************/
        group.MapPost(
            "/",
            async (CreateGameDto newGame, GameStoreContext dbContext) =>
            {
                Game game = newGame.ToEntity();

                dbContext.Games.Add(game);
                await dbContext.SaveChangesAsync();

                return Results.CreatedAtRoute(
                    GetGameEndpointName,
                    new { id = game.Id },
                    game.ToGameDetailsDto()
                );
            }
        );

        //PUT /games
        /**************************************************************************************
        Defining PUT endpoint, Find any entity with the given id.
        If not found return NotFound response. Replace the values of existing record with new values
        Lastly save it and return with 204 but without any response in the body.
        **************************************************************************************/
        group.MapPut(
            "/{id}",
            async (int id, UpdateGameDto updatedGame, GameStoreContext dbContext) =>
            {
                var existingGame = await dbContext.Games.FindAsync(id);

                //There could be a option to create a new record if the the record to be update is not found. Should be considered case by case.
                if (existingGame is null)
                {
                    return Results.NotFound();
                }

                dbContext.Entry(existingGame).CurrentValues.SetValues(updatedGame.ToEntity(id));

                await dbContext.SaveChangesAsync();

                return Results.NoContent();
            }
        );

        //Delete /games/{id}
        /**************************************************************************************
        Defining DELETE endpoint. Remove any game with matcing id.
        **************************************************************************************/
        group.MapDelete(
            "/{id}",
            async (int id, GameStoreContext dbContext) =>
            {
                await dbContext.Games.Where(game => game.Id == id).ExecuteDeleteAsync();

                return Results.NoContent();
            }
        );

        return group;
    }
}
