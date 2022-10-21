
namespace chessboard.pieces
{
    // TODO special move Clasting
    public class King : PieceBase, IPiece
    {
        public King(enums.Color color = enums.Color.White) : base("", "", color) { }

        public King(string collumn, string row, enums.Color color = enums.Color.White) : base(collumn, row, color) { }

        public string Name { get => "King"; }

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

                return moves;
            }
        }
    }
}
