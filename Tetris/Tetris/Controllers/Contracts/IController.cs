﻿using System.Collections.Generic;

namespace Tetris.Controllers.Contracts
{
    public interface IController
    {
        bool[,] RotateFigure(bool[,] currentFigure, int row, int col, Queue<bool[,]> rotations);

        int MoveLeft(bool[,] currentFigure, int row, int col);

        int MoveRight(bool[,] currentFigure, int row, int col);
    }
}