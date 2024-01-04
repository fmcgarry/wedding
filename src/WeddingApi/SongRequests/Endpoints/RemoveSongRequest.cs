﻿using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Wedding.Core.Interfaces;

namespace Wedding.Api.SongRequests.Endpoints;

public class RemoveSongRequest
{
    public static async Task<Results<NotFound, NoContent>> Handler([FromBody] Guid id, [FromServices] ISongRequestService songRequestService)
    {
        var songRequestToRemove = songRequestService.GetSongRequestByIdAsync(id);

        if (songRequestToRemove is not null)
        {
            await songRequestService.RemoveSongRequestAsync(id);
        }

        return TypedResults.NoContent();
    }
}
