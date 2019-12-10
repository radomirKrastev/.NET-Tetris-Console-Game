using System;

namespace Tetris.IO.Contracts
{
    public interface IDrawable
    {
        void WriteLine(int row, int col, ConsoleColor color);

        void Write(int row, int col, ConsoleColor color);
    }
}
