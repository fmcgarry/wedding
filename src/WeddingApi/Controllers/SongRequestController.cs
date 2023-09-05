using Microsoft.AspNetCore.Mvc;
using WeddingApi.Core.Interfaces;
using WeddingApi.Core.Models;

namespace WeddingApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SongRequestController : ControllerBase
{
    private readonly ISongRequestService _songRequestService;

    public SongRequestController(ISongRequestService songRequestService)
    {
        _songRequestService = songRequestService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<SongRequest>> GetSongRequests()
    {
        var songRequests = _songRequestService.GetSongRequests();
        return Ok(songRequests);
    }

    [HttpGet("{id}")]
    public ActionResult<SongRequest> GetSongRequest(Guid id)
    {
        var songRequest = _songRequestService.GetSongRequestById(id);
        if (songRequest == null)
        {
            return NotFound();
        }

        return Ok(songRequest);
    }

    [HttpPost]
    public ActionResult<SongRequest> AddSongRequest(SongRequest songRequest)
    {
        _songRequestService.AddSongRequest(songRequest);
        return CreatedAtAction(nameof(GetSongRequest), new { id = songRequest.Id }, songRequest);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateSongRequest(Guid id, SongRequest updatedSongRequest)
    {
        var existingSongRequest = _songRequestService.GetSongRequestById(id);
        if (existingSongRequest == null)
        {
            return NotFound();
        }

        _songRequestService.UpdateSongRequest(id, updatedSongRequest);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult RemoveSongRequest(Guid id)
    {
        var songRequestToRemove = _songRequestService.GetSongRequestById(id);
        if (songRequestToRemove == null)
        {
            return NotFound();
        }

        _songRequestService.RemoveSongRequest(id);
        return NoContent();
    }
}