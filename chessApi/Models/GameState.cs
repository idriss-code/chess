using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace chessboard.Models
{
    public class GameState
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CurrentPlayer { get; set; } // "White" or "Black"
        public virtual ICollection<PieceState> Pieces { get; set; }
        public virtual ICollection<PieceState> RemovedPieces { get; set; }

        public GameState()
        {
            Pieces = new List<PieceState>();
            RemovedPieces = new List<PieceState>();
            CreatedAt = DateTime.Now;
        }
    }

    public class PieceState
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; } // "Pawn", "Rook", etc.
        public string Color { get; set; } // "White" or "Black"
        public string Column { get; set; }
        public string Row { get; set; }
        public bool HasMoved { get; set; } // Useful for special moves like castling

        // Foreign key to GameState
        public int GameStateId { get; set; }
        public virtual GameState GameState { get; set; }
    }
}