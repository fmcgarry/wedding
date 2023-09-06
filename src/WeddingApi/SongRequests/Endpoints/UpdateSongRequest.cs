﻿using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WeddingApi.Core.Interfaces;
using WeddingApi.Core.Models;
using WeddingApi.SongRequests.DTOs;

namespace WeddingApi.SongRequests.Endpoints;

public class UpdateSongRequest
{
    public static async Task<Results<NotFound, NoContent>> Handler([FromRoute] Guid id, [FromBody] SongRequestDTO updatedSongRequest, [FromServices] ISongRequestService songRequestService)
    {
        var existingSongRequest = songRequestService.GetSongRequestByIdAsync(id);
        if (existingSongRequest is null)
        {
            return TypedResults.NotFound();
        }

        var songRequest = new SongRequest()
        {
            Title = ""
        };

        await songRequestService.UpdateSongRequestAsync(id, songRequest);

        return TypedResults.NoContent();
    }
}
