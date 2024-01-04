using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Wedding.Api.SongRequests.DTOs;
using Wedding.Core.Entities;
using Wedding.Core.Interfaces;

namespace Wedding.Api.SongRequests.Endpoints;

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
