using Microsoft.EntityFrameworkCore;
using ChessApi.model;


namespace ChessApi
{
    public class ChessDbContext : DbContext
    {
        public ChessDbContext(DbContextOptions<ChessDbContext> options)
            : base(options)
        {
        }

        public DbSet<Game> Games { get; set; } = null!;
    }
}
