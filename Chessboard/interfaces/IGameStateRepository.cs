namespace chessboard.interfaces
{
    public interface IGameStateRepository
    {
        int SaveGame(Chessboard game, int? id = null);
        Chessboard LoadGame(int id);
    }
}
