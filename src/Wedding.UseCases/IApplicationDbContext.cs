using Microsoft.EntityFrameworkCore;
using Wedding.Core.Guests.Entities.GuestAggregate;
using Wedding.Core.Photos;
using Wedding.Core.SongRequests;

namespace Wedding.UseCases;

public interface IApplicationDbContext
{
    DbSet<Guest> Guests { get; set; }
    DbSet<Photo> Photos { get; set; }
    DbSet<SongRequest> SongRequests { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}