namespace Tetris.GameInformation.Contracts
{
    public interface IInformable
    {
        int Score { get; set; }

        bool [,] NextFigure { get; set; }

        int Level { get; set; }

        string Controls { get; }

        void PrintScore();

        void PrintNextFigure();

        void PrintLevel();

        void PrintControls();
    }
}
