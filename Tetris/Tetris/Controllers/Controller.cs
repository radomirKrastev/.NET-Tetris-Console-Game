namespace Tetris.Controllers
{
    using System.Collections.Generic;
    using Contracts;
    using Tetris.Layout;
    using Tetris.Layout.Contracts;
    using Tetris.TFigures;
    using Tetris.TFigures.Contracts;

    public class Controller : IController
    {
        private ITetrisField field;
        private IFigures figures;

        public Controller(TetrisField field)
        {
            this.field = field;
            this.figures = new Figures();
        }

        public bool[,] RotateFigure(bool[,] currentFigure, int row, int col, Queue<bool[,]> rotations)
        {
            while (true)
            {
                var rotatedFigure = this.figures.Rotate(rotations);

                if(rotatedFigure == currentFigure)
                {
                    return currentFigure;
                }
                else
                {
                    if(!CheckForCollision(row, col, rotatedFigure))
                    {
                        return rotatedFigure;
                    }

                    return currentFigure;
                }

            }
        }

        private bool CheckForCollision(int row, int col, bool[,] figure)
        {
            for (int r = 0; r < figure.GetLength(0); r++)
            {
                for (int c = 0; c < figure.GetLength(1); c++)
                {
                    if(figure[r, c] && 
                        (this.field.PlayingField.Matrix[row + r, col + c] 
                        || row + r > this.field.PlayingField.Rows
                        || row + r < 1
                        || col + c > this.field.PlayingField.Cols
                        || row + r < 1))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
