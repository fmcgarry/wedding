using Microsoft.EntityFrameworkCore;
using Wedding.Core.Entities;
using Wedding.Core.Entities.GuestAggregate;
using Wedding.UseCases;

namespace Wedding.Infrastructure.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
     : base(options)
    {
    }

    public DbSet<Guest> Guests { get; set; }
    public DbSet<SongRequest> SongRequests { get; set; }
    public DbSet<Photo> Photos { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }
}