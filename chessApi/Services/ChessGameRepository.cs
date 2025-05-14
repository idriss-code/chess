using chessboard;
using chessboard.enums;
using chessboard.interfaces;
using chessboard.pieces;
using Microsoft.EntityFrameworkCore;
using chessboard.Models;
using chessApi;

namespace ChessApi.Services
{
    public class ChessGameRepository : IGameStateRepository
    {
        private readonly ChessDbContext _context;

        public ChessGameRepository(ChessDbContext context)
        {
            _context = context;
        }

        public int SaveGame(chessboard.Chessboard game, int? id = null)
        {
            GameState gameState;

            if (id.HasValue)
            {
                // Récupérer l'état de jeu existant
                gameState = _context.GameStates
                    .Include(g => g.Pieces)
                    .Include(g => g.RemovedPieces)
                    .FirstOrDefault(g => g.Id == id.Value);

                if (gameState == null)
                {
                    throw new InvalidOperationException($"No game state found with ID {id.Value}");
                }

                // Supprimer les anciennes pièces pour les remplacer
                _context.RemoveRange(gameState.Pieces);
                _context.RemoveRange(gameState.RemovedPieces);

                // Vider les collections
                gameState.Pieces.Clear();
                gameState.RemovedPieces.Clear();
            }
            else
            {
                // Créer un nouvel état de jeu si aucun ID n'est fourni
                gameState = new GameState();
                _context.GameStates.Add(gameState);
            }

            // Mettre à jour les informations de l'état du jeu
            gameState.CurrentPlayer = game.CurrentPlayer.ToString();

            // Ajouter les pièces actives
            foreach (var piece in game.Pieces)
            {
                gameState.Pieces.Add(new PieceState
                {
                    Type = piece.GetType().Name,
                    Color = piece.Color.ToString(),
                    Column = piece.Collumn,
                    Row = piece.Row,
                    HasMoved = piece is IPieceMoveTracking movable ? movable.HasMoved : false
                });
            }

            // Ajouter les pièces capturées
            foreach (var piece in game.RemovedPieces)
            {
                gameState.RemovedPieces.Add(new PieceState
                {
                    Type = piece.GetType().Name,
                    Color = piece.Color.ToString(),
                    Column = piece.Collumn,
                    Row = piece.Row,
                    HasMoved = piece is IPieceMoveTracking movable ? movable.HasMoved : false
                });
            }

            // Sauvegarder en base de données
            _context.SaveChanges();

            return gameState.Id;
        }

        public chessboard.Chessboard LoadGame(int id)
        {
            // Charger l'état du jeu avec ses pièces
            var gameState = _context.GameStates
                .Include(g => g.Pieces)
                .Include(g => g.RemovedPieces)
                .FirstOrDefault(g => g.Id == id);

            if (gameState == null)
            {
                throw new InvalidOperationException($"No game state found with ID {id}");
            }

            // Créer un nouveau chessboard
            var chessboard = new chessboard.Chessboard();

            // Vider l'état existant et mettre à jour le joueur courant
            var colorEnum = (Color)Enum.Parse(typeof(Color), gameState.CurrentPlayer);

            // On accède à la propriété privée via réflexion car CurrentPlayer n'a pas de setter public
            var currentPlayerProperty = typeof(chessboard.Chessboard).GetProperty("CurrentPlayer");
            currentPlayerProperty?.SetValue(chessboard, colorEnum);

            // Recréer les pièces actives
            foreach (var pieceState in gameState.Pieces)
            {
                // Créer la bonne instance selon le type
                IPiece newPiece = CreatePieceFromState(pieceState);
                chessboard.AddPiece(newPiece);
            }

            // Pour les pièces capturées, on doit utiliser la réflexion car removedPieces est privé
            var removedPiecesField = typeof(chessboard.Chessboard).GetField("removedPieces",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            if (removedPiecesField != null)
            {
                var removedPiecesList = removedPiecesField.GetValue(chessboard) as List<IPiece>;

                foreach (var pieceState in gameState.RemovedPieces)
                {
                    IPiece newPiece = CreatePieceFromState(pieceState);
                    removedPiecesList?.Add(newPiece);
                    newPiece.Chessboard = chessboard;
                }
            }

            return chessboard;
        }

        // Méthode auxiliaire pour créer une instance de pièce à partir de son état
        private IPiece CreatePieceFromState(PieceState state)
        {
            Color color = (Color)Enum.Parse(typeof(Color), state.Color);

            IPiece piece = state.Type switch
            {
                "Pawn" => new Pawn(state.Column, state.Row, color),
                "Rook" => new Rook(state.Column, state.Row, color),
                "Knight" => new Knight(state.Column, state.Row, color),
                "Bishop" => new Bishop(state.Column, state.Row, color),
                "Queen" => new Queen(state.Column, state.Row, color),
                "King" => new King(state.Column, state.Row, color),
                _ => throw new InvalidOperationException($"Unknown piece type: {state.Type}")
            };

            // Initialiser l'état de déplacement si applicable
            if (piece is IPieceMoveTracking movable && state.HasMoved)
            {
                movable.HasMoved = true;
            }

            return piece;
        }
    }
}