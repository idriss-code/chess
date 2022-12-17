
namespace chessboard.pieces
{
    // TODO special move Clasting
    public class Rook : PieceBase, IPiece
    {
        public Rook(enums.Color color = enums.Color.White) : base("", "", color)
        {
            HasMoved = false;
        }

        public Rook(string collumn, string row, enums.Color color = enums.Color.White) : base(collumn, row, color)
        {
            HasMoved = false;
        }

        public bool HasMoved { get; private set; }

        public override string Name { get => "Rook"; }

        public override List<Square> AvailableMove
        {
            get
            {
                var moves = new List<Square>();

                AddColumnMove(moves);

                return moves;
            }
        }

        public void CastlingMove(string col)
        {
            Collumn = col;
        }

        public override void Move(string c, string r)
        {
            base.Move(c, r);
            HasMoved = true;
        }
    }
}
