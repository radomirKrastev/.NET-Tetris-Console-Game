using System;

namespace Tetris.IO.Contracts
{
    public interface IDrawable
    {
        void DrawWholeField(string wholeFields);

        void PrintScore(string score);

        void PrintControls(string controls);

        void PrintLevel(string level);

        void DrawFigure(bool [,] figure, int row, int col);

        void ClearLine(bool [,] figure, int row, int col);
    }
}
