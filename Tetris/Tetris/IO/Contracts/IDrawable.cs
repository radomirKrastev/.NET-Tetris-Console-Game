namespace Tetris.IO.Contracts
{
    public interface IDrawable
    {
        void GameOver(int score);

        void DrawWholeField(string wholeFields);

        void PrintScore(string score);

        void PrintControls();

        void PrintLevel(string level);

        void DrawFigure(bool [,] figure, int row, int col);

        void DrawOccupiedSpots (bool[,] matrix);
    }
}
