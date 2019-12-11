using System;

namespace Tetris.IO.Contracts
{
    public interface IDrawable
    {
        void DrawWholeField(string wholeField);

        void PrintScore(string score);

        void PrintControls(string controls);

        void PrintLevel(string level);

        void DrawFigure(bool [,] figure, int row, int col);
    }
}
