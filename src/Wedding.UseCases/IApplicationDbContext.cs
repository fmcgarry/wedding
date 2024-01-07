using Microsoft.EntityFrameworkCore;
using Wedding.Core.Entities;
using Wedding.Core.Entities.GuestAggregate;

namespace Wedding.UseCases;

public interface IApplicationDbContext
{
    DbSet<Guest> Guests { get; set; }
    DbSet<Photo> Photos { get; set; }
    DbSet<SongRequest> SongRequests { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}