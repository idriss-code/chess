using Microsoft.EntityFrameworkCore;
using chessApi.model;


namespace chessApi
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
