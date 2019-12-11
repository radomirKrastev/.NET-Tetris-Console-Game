using System.Collections.Generic;

namespace Tetris.Controllers.Contracts
{
    public interface IController
    {
        bool[,] RotateFigure(bool[,] currentFigure, int row, int col, Queue<bool[,]> rotations);
    }
}
