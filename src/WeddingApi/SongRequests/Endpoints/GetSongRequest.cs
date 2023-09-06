﻿using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WeddingApi.Core.Interfaces;
using WeddingApi.SongRequests.DTOs;

namespace WeddingApi.SongRequests.Endpoints;

public static class GetSongRequest
{
    public static async Task<Results<NotFound, Ok<SongRequestDTO>>> Handler([FromRoute] Guid id, [FromServices] ISongRequestService songRequestService)
    {
        var songRequest = await songRequestService.GetSongRequestByIdAsync(id);
        if (songRequest == null)
        {
            return TypedResults.NotFound();
        }

        var songRequestDTO = new SongRequestDTO();

        return TypedResults.Ok(songRequestDTO);
    }
}