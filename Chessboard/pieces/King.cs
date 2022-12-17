
using chessboard;

namespace chessboard.pieces
{
    public class King : PieceBase, IPiece
    {
        public King(enums.Color color = enums.Color.White) : base("", "", color)
        {
            startRow = this.Color == enums.Color.White ? "1" : "8";
            startCol = "e";
        }

        public King(string collumn, string row, enums.Color color = enums.Color.White) : base(collumn, row, color)
        {
            startRow = Color == enums.Color.White ? "1" : "8";
            startCol = "e";
        }

        private readonly string startRow;
        private readonly string startCol;
        private bool HasMoved { get; set; }

        public override string Name { get => "King"; }

        public bool CastingQueenSideAvailable
        {
            get
            {
                string[] side = { "b", "c", "d" };
                return !HasMoved && IsEmptySide(side) && IsRookReadyCasting("a");
            }
        }

        public bool CastingKingSideAvailable
        {
            get
            {
                string[] side = { "f", "g" };
                return !HasMoved && IsEmptySide(side) && IsRookReadyCasting("h");
            }
        }

        public override List<Square> AvailableMove
        {
            get
            {
                var moves = new List<Square>();

                for (int r = RowIndex - 1; r < RowIndex + 2; r++)
                {
                    for (int c = ColIndex - 1; c < ColIndex + 2; c++)
                    {
                        if (IsNotOriginSquare(c, r) && IsOnchessBoard(c, r) && IsEmptyOrOposite(c, r) && !IsKingCheckPosition(c, r))
                        {
                            moves.Add(new Square(Chessboard.collumns[c], Chessboard.rows[r]));
                        }
                    }
                }

                if (CastingQueenSideAvailable)
                {
                    moves.Add(new Square("c", startRow));
                }
                if (CastingKingSideAvailable)
                {
                    moves.Add(new Square("g", startRow));
                }

                return moves;
            }
        }

        private bool IsEmptySide(string[] side)
        {
            foreach (string col in side)
            {
                if (Chessboard?.GetPieceOnSquare(col, startRow) != null)
                    return false;
            }
            return true;
        }

        private bool IsRookReadyCasting(string col)
        {
            var rook = Chessboard?.GetPieceOnSquare(col, startRow);
            return rook is Rook && rook.Color == Color && !((Rook)rook).HasMoved;
        }

        public override void Move(string c, string r)
        {
            base.Move(c, r);

            if (HasMoved == false)
            {
                Square destPos = new Square(c, r);

                if (destPos == new Square("g", startRow))
                {
                    Rook? rook = (Rook)Chessboard?.GetPieceOnSquare("h", startRow);
                    rook?.CastlingMove("f");
                }
                else if (destPos == new Square("c", startRow))
                {
                    Rook? rook = (Rook)Chessboard?.GetPieceOnSquare("a", startRow);
                    rook?.CastlingMove("d");
                }
            }

            HasMoved = true;
        }
    }
}
