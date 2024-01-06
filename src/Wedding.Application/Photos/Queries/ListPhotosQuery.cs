using MediatR;
using Microsoft.Extensions.Logging;
using Wedding.Core.Interfaces;

namespace Wedding.UseCases.Photos.Queries;

public record ListPhotosQuery : IRequest<IEnumerable<PhotoModel>>;

public class ListPhotosHandler(ILogger<ListPhotosHandler> _logger, IPhotoService _photoService) : IRequestHandler<ListPhotosQuery, IEnumerable<PhotoModel>>
{
    public async Task<IEnumerable<PhotoModel>> Handle(ListPhotosQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"{nameof(ListPhotosHandler)}");

        var photoUrls = await _photoService.GetPhotoUrlsAsync();

        var photos = new List<PhotoModel>();

        foreach (var url in photoUrls)
        {
            photos.Add(new PhotoModel()
            {
                Url = url
            });
        }

        return photos;
    }
}
