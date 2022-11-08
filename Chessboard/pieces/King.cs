
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

        public override List<Square> AvailableMove
        {
            get
            {
                var moves = new List<Square>();

                for (int r = RowIndex - 1; r < RowIndex + 2; r++)
                {
                    for (int c = ColIndex - 1; c < ColIndex + 2; c++)
                    {
                        if (IsNotOriginSquare(c, r) && IsOnchessBoard(c, r) && IsEmptyOrOposite(c, r))
                        {
                            moves.Add(new Square(Chessboard.collumns[c], Chessboard.rows[r]));
                        }
                    }
                }

                if (IsCastingQueenSideAvalable())
                {
                    moves.Add(new Square("c", startRow));
                }
                if (IsCastingKingSideAvalable())
                {
                    moves.Add(new Square("g", startRow));
                }

                return moves;
            }
        }

        private bool IsCastingQueenSideAvalable()
        {
            string[] side = { "b", "c", "d" };
            return !HasMoved && IsEmptySide(side) && IsRookReadyCasting("a");
        }

        private bool IsCastingKingSideAvalable()
        {
            string[] side = { "f", "g" };
            return !HasMoved && IsEmptySide(side) && IsRookReadyCasting("h");
        }

        private bool IsEmptySide(string[] side)
        {
            foreach (string col in side)
            {
                if(Chessboard?.GetPieceOnSquare(col, startRow) != null)
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
            HasMoved = true;
        }
    }
}
