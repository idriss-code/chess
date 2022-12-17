using Microsoft.Extensions.Hosting;

namespace chessApi.model
{
    public class Game
    {
        public long GameId { get; set; }

        public Player? WhitePlayer { get; set; }
        public Player? BlackPlayer { get; set; }

        public List<Piece> Pieces { get; set; }
    }

    public class Player
    {
        public long Id { get; set; }
        public string? Name { get; set; }

        public long GameId { get; set; }
        public Game Game { get; set; }
    }

    public class Piece
    {
        public long Id { get; set; }
        public string? Name { get; set; }

        public string? Row { get; set; }

        public string? Col { get; set; }

        public bool? HasMoved { get; set; }


        public long GameId { get; set; }
        public Game Game { get; set; }
    }
}
