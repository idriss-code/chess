
namespace chessboard.pieces
{
    // TODO en Passant
    public class Pawn : PieceBase, IPiece
    {
        public Pawn(enums.Color color = enums.Color.White) : base("", "", color) { }


        public Pawn(string collumn, string row, enums.Color color = enums.Color.White) : base(collumn, row, color) { }

        public string Name { get => "Pawn"; }

        public List<Square> AvailableMove
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

                return moves;
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

        private bool IsOnStartRow()
        {
            return this.Color == enums.Color.White ? Row == "2" : Row == "7";
        }
    }
}
