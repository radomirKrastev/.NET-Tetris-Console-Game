namespace Tetris.GameInformation.Contracts
{
    public interface IGameInformable
    {
        int Score { get; set; }

        bool [,] NextFigure { get; set; }

        int Level { get; set; }
    }
}
