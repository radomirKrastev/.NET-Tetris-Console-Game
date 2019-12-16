namespace Tetris.Controllers
{
    using System.Collections.Generic;
    using Contracts;
    using Tetris.Layout.Contracts;
    using Tetris.TFigures;
    using Tetris.TFigures.Contracts;

    public class Controller : IController
    {
        private ITetrisField field;
        private IFigures figures;

        public Controller(ITetrisField field)
        {
            this.field = field;
            this.figures = new Figures();
        }

        public int MoveLeft(bool[,] currentFigure, int row, int col)
        {
            if (col <= 1)
            {
                return col;
            }

            for (int r = 0; r < currentFigure.GetLength(0); r++)
            {
                for (int c = 0; c < currentFigure.GetLength(1); c++)
                {
                    if (currentFigure[r, c]
                        && this.field.PlayingField.Matrix[row + r - 1, col + c - 1 -1])
                    {
                        return col;
                    }
                }
            }

            return col -= 1;
        }

        public int MoveRight(bool[,] currentFigure, int row, int col)
        {
            var greatestColIndex = currentFigure.GetLength(1) - 1;

            if (col + greatestColIndex >= this.field.PlayingField.Cols)
            {
                return col;
            }

            for (int r = 0; r < currentFigure.GetLength(0); r++)
            {
                for (int c = currentFigure.GetLength(1) - 1; c >= 0; c--)
                {
                    if (currentFigure[r, c]
                        && this.field.PlayingField.Matrix[row + r - 1, col + c])
                    {
                        return col;
                    }
                }
            }

            return col += 1;
        }

        public bool[,] RotateFigure(bool[,] currentFigure, int row, int col, Queue<bool[,]> rotations)
        {
            while (true)
            {
                var rotatedFigure = this.figures.Rotate(rotations);

                if (rotatedFigure == currentFigure)
                {
                    return currentFigure;
                }
                else
                {
                    var greatestColIndex = rotatedFigure.GetLength(1) - 1;

                    if (col >= 1 && col + greatestColIndex <= this.field.PlayingField.Cols)
                    {
                        return rotatedFigure;
                    }

                    return currentFigure;
                }
            }
        }

        public bool FigureCollides(bool[,] currentFigure, int row, int col)
        {
            if (row + currentFigure.GetLength(0) - 1 == this.field.PlayingField.Matrix.GetLength(0))
            {
                return true;
            }
            
            for (int r = currentFigure.GetLength(0) - 1; r >= 0; r--)
            {
                for (int c = 0; c < currentFigure.GetLength(1); c++)
                {
                    if (currentFigure[r, c]
                        && this.field.PlayingField.Matrix[row + r, col + c - 1])
                    {
                        return true;
                    }
                }
            }            

            return false;
        }

        public void ClearLines()
        {
            for (int r = 0; r < this.field.PlayingField.Rows; r++)
            {
                if (ShouldClearLine(r))
                {
                    for (int currentRow = r; currentRow >= 1; currentRow--)
                    {
                        for (int c = 0; c < this.field.PlayingField.Cols; c++)
                        {
                            this.field.PlayingField.Matrix[currentRow, c] = this.field.PlayingField.Matrix[currentRow - 1, c];
                        }
                    }

                    for (int c = 0; c < this.field.PlayingField.Cols; c++)
                    {
                        this.field.PlayingField.Matrix[0, c] = false;
                    }
                }
            }
        }

        private bool ShouldClearLine(int row)
        {
            for (int c = 0; c < this.field.PlayingField.Cols; c++)
            {
                if (!this.field.PlayingField.Matrix[row, c])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
