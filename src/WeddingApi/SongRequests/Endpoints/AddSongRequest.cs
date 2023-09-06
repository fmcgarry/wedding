using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WeddingApi.Core.Interfaces;
using WeddingApi.Core.Models;
using WeddingApi.SongRequests.DTOs;

namespace WeddingApi.SongRequests.Endpoints;

public class AddSongRequest
{
    public static async Task<CreatedAtRoute<SongRequestDTO>> Handler([FromBody] SongRequestDTO songRequest, [FromServices] ISongRequestService songRequestService)
    {
        var songRequestModel = new SongRequest()
        {
            Title = ""
        };

        await songRequestService.AddSongRequestAsync(songRequestModel);

        return TypedResults.CreatedAtRoute(songRequest, nameof(AddSongRequest));
    }
}
