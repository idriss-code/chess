using chessboard.enums;
using chessboard.exceptions;
using chessboard.pieces;
using System.Collections.ObjectModel;

namespace chessboard
{
    public class Chessboard
    {

        public Chessboard()
        {
            CurrentPlayer = Color.White;
        }

        readonly List<IPiece> pieces = new();
        readonly List<IPiece> removedPieces = new();

        public Color CurrentPlayer { get; private set; }

        public ReadOnlyCollection<IPiece> RemovedPieces => removedPieces.AsReadOnly();

        public ReadOnlyCollection<IPiece> Pieces => pieces.AsReadOnly();

        public ReadOnlyCollection<IPiece> BlackPieces => pieces.Where(pieces => pieces.Color == Color.Black).ToList().AsReadOnly();

        public ReadOnlyCollection<IPiece> WhitePieces => pieces.Where(pieces => pieces.Color == Color.White).ToList().AsReadOnly();

        public static readonly string[] rows = { "1", "2", "3", "4", "5", "6", "7", "8" };
        public static readonly string[] collumns = { "a", "b", "c", "d", "e", "f", "g", "h" };

        public IPiece? GetPieceOnSquare(string collumn, string row)
        {
            return pieces.Find(x => x.Row == row && x.Collumn == collumn);
        }

        public void NewGame()
        {
            AddPieces("1", Color.White);
            AddPieces("8", Color.Black);

            foreach (string col in collumns)
            {
                this.AddPiece(new Pawn(col, "2", Color.White));
                this.AddPiece(new Pawn(col, "7", Color.Black));
            }

            CurrentPlayer = Color.White;
        }

        public void SwitchPlayer()
        {
            CurrentPlayer = CurrentPlayer == Color.White ? Color.Black : Color.White;
        }

        private void AddPieces(string row, Color color)
        {
            this.AddPiece(new Rook("a", row, color));
            this.AddPiece(new Knight("b", row, color));
            this.AddPiece(new Bishop("c", row, color));
            this.AddPiece(new Queen("d", row, color));
            this.AddPiece(new King("e", row, color));
            this.AddPiece(new Bishop("f", row, color));
            this.AddPiece(new Knight("g", row, color));
            this.AddPiece(new Rook("h", row, color));
        }

        public void AddPiece(IPiece piece)
        {
            this.CheckSquare(piece);
            pieces.Add(piece);
            piece.Chessboard = this;
        }

        private void CheckSquare(IPiece piece)
        {
            if (!Chessboard.rows.Any(x => x == piece.Row) || !Chessboard.collumns.Any(x => x == piece.Collumn))
            {
                throw new ChessBoardException("Invalid square");
            }

            if (this.GetPieceOnSquare(piece.Collumn, piece.Row) != null)
            {
                throw new ChessBoardException("2 pieces same square");
            }
        }

        public void Remove(IPiece piece)
        {
            pieces.Remove(piece);
            removedPieces.Add(piece);
        }

        public IEnumerable<Pawn> GetAllPawnOfOneSide(Color color)
        {
            return pieces.FindAll(piece => piece is Pawn && piece.Color == color).Cast<Pawn>();
        }

        public int Save()
        {
            return 0;
        }

        public void Load(int id)
        {

        }
    }
}