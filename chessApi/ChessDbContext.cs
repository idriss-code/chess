using chessboard.Models;
using Microsoft.EntityFrameworkCore;


namespace chessApi
{
    public class ChessDbContext : DbContext
    {
        public DbSet<GameState> GameStates { get; set; }
        public DbSet<PieceState> PieceStates { get; set; }

        public ChessDbContext(DbContextOptions<ChessDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships
            modelBuilder.Entity<GameState>()
                .HasMany(g => g.Pieces)
                .WithOne(p => p.GameState)
                .HasForeignKey(p => p.GameStateId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<GameState>()
                .HasMany(g => g.RemovedPieces)
                .WithOne()
                .HasForeignKey(p => p.GameStateId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
