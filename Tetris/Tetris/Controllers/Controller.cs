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
            if (col > 1)
            {
                return col -= 1;
            }

            return col;
        }

        public int MoveRight(bool[,] currentFigure, int row, int col)
        {
            var greatestColIndex = currentFigure.GetLength(1) - 1;

            if (col + greatestColIndex < this.field.PlayingField.Cols)
            {
                return col += 1;
            }

            return col;
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
            if(row + currentFigure.GetLength(0) - 1 == this.field.PlayingField.Matrix.GetLength(0))
            {
                return true;
            }

            return false;
        }
    }
}
