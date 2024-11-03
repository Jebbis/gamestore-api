using System;
using GameStore.Dtos;

namespace GameStore.Mapping;

//Static class because it is used for extension method
public static class GenreMapping
{
    public static GenreDto ToDto(this Entities.Genre genre)
    {
        return new GenreDto(genre.Id, genre.Name);
    }
}
