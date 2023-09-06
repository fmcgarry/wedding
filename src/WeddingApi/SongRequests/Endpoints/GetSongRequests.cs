using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WeddingApi.Core.Interfaces;
using WeddingApi.SongRequests.DTOs;

namespace WeddingApi.SongRequests.Endpoints;

public static class GetSongRequests
{
    public static async Task<Ok<List<SongRequestDTO>>> Handler([FromServices] ISongRequestService songRequestService)
    {
        var songRequests = await songRequestService.GetSongRequestsAsync();

        var results = new List<SongRequestDTO>();

        foreach (var songRequest in songRequests)
        {
            results.Add(new SongRequestDTO()
            {

            });
        }

        return TypedResults.Ok(results);
    }
}
