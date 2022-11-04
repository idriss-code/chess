
using chessboard.enums;
using System.Collections.Generic;

namespace chessboard.pieces
{
    public class Pawn : PieceBase, IPiece
    {
        public Pawn(enums.Color color = enums.Color.White) : base("", "", color) { }

        public Pawn(string collumn, string row, enums.Color color = enums.Color.White) : base(collumn, row, color) { }

        public override string Name { get => "Pawn"; }

        private readonly List<Square> EnPassantMove = new();

        public override List<Square> AvailableMove
        {
            get
            {
                var moves = new List<Square>();

                AddSimpleMove(moves);
                if (IsOnStartRow())
                {
                    AddDoubleMove(moves);
                }
                AddCaptureMove(moves);

                AddEnPassantMove(moves);

                return moves;
            }
        }

        public override void Move(string c, string r)
        {
            if (IsDoubleMove(c, r))
            {
                GiveEnPassantToOpositPawns();
            }

            base.Move(c, r);
        }

        private bool IsDoubleMove(string c, string r)
        {
            int start = Int16.Parse(Row);
            int end = Int16.Parse(r);
            int diff = Math.Abs(start - end);
            return diff == 2;
        }

        public void AddEnPassant(string c, string r)
        {
            EnPassantMove.Add(new Square(c, r));
        }

        private void GiveEnPassantToOpositPawns()
        {
            int rowOpositPiece = this.Color == enums.Color.White ? RowIndex + 2 : RowIndex - 2;
            int rowMoveToGive = this.Color == enums.Color.White ? RowIndex + 1 : RowIndex - 1;
            int colOpositPiece1 = ColIndex - 1;
            int colOpositPiece2 = ColIndex + 1;
            if (colOpositPiece1 >= 0)
            {
                GiveEnPassantToOpositPawn(rowOpositPiece, colOpositPiece1, rowMoveToGive);
            }

            if (colOpositPiece2 <= Chessboard.collumns.Count())
            {
                GiveEnPassantToOpositPawn(rowOpositPiece, colOpositPiece2, rowMoveToGive);
            }
        }

        private void GiveEnPassantToOpositPawn(int opositRow, int opositColumn, int rowMoveToGive)
        {
            IPiece? piece = Chessboard?.GetSquare(Chessboard.collumns[opositColumn], Chessboard.rows[opositRow]);
            if (piece is Pawn && piece.Color != Color)
            {
                ((Pawn)piece).AddEnPassant(Chessboard.collumns[ColIndex], Chessboard.rows[rowMoveToGive]);
            }
        }

        private void AddCaptureMove(List<Square> moves)
        {
            int r = this.Color == enums.Color.White ? RowIndex + 1 : RowIndex - 1;
            int c1 = ColIndex - 1;
            int c2 = ColIndex + 1;

            if (IsOnchessBoard(c1, r) && IsOposite(c1, r))
            {
                moves.Add(new Square(Chessboard.collumns[c1], Chessboard.rows[r]));
            }

            if (IsOnchessBoard(c2, r) && IsOposite(c2, r))
            {
                moves.Add(new Square(Chessboard.collumns[c2], Chessboard.rows[r]));
            }
        }

        private void AddDoubleMove(List<Square> moves)
        {
            int ri = this.Color == enums.Color.White ? RowIndex + 1 : RowIndex - 1;
            int r = this.Color == enums.Color.White ? RowIndex + 2 : RowIndex - 2;
            int c = ColIndex;

            if (IsOnchessBoard(c, r) && IsEmpty(c, r) && IsEmpty(c, ri))
            {
                moves.Add(new Square(Chessboard.collumns[c], Chessboard.rows[r]));
            }
        }

        private void AddSimpleMove(List<Square> moves)
        {
            int r = this.Color == enums.Color.White ? RowIndex + 1 : RowIndex - 1;
            int c = ColIndex;

            if (IsOnchessBoard(c, r) && IsEmpty(c, r))
            {
                moves.Add(new Square(Chessboard.collumns[c], Chessboard.rows[r]));
            }
        }

        private void AddEnPassantMove(List<Square> moves)
        {
            moves.AddRange(EnPassantMove);
        }

        private bool IsOnStartRow()
        {
            return this.Color == enums.Color.White ? Row == "2" : Row == "7";
        }
    }
}
