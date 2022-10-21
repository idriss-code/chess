
namespace chessboard.pieces
{
    public class Queen : PieceBase, IPiece
    {
        public Queen(enums.Color color = enums.Color.White) : base("", "", color) { }


        public Queen(string collumn, string row, enums.Color color = enums.Color.White) : base(collumn, row, color) { }

        public string Name { get => "Queen"; }

        public override List<Square> AvailableMove
        {
            get
            {
                var moves = new List<Square>();

                AddDiagonalMove(moves);
                AddColumnMove(moves);

                return moves;
            }
        }
    }
}
