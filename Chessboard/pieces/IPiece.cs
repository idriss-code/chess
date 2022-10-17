
namespace chessboard.pieces
{
    public interface IPiece
    {
        string Name { get; }

        string Row { get; }
        string Collumn { get; }

        public enums.Color Color { get; }

        public Chessboard? Chessboard
        {
            get;
            set;//todo on set qu'une fois nomalement
        }

        List<Square> AvailableMove { get; }
    }
}
