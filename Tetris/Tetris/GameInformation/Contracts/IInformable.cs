namespace Tetris.GameInformation.Contracts
{
    public interface IInformable
    {
        int Score { get; set; }

        bool [,] NextFigure { get; set; }

        int Level { get; set; }
    }
}
