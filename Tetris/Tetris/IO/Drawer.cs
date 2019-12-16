namespace Tetris.IO
{
    using System;
    using Contracts;
    using Tetris.Configurations;
    using Tetris.GameInformation;
    using Tetris.GameInformation.Contracts;
    using Tetris.Layout;
    using Tetris.Layout.Contracts;

    public class Drawer : IDrawable
    {
        private ITetrisField field;
        private IGameInformable information;
        private ConsoleConfigurator configurator;

        public Drawer(ITetrisField field, IGameInformable information)
        {
            this.configurator = new ConsoleConfigurator(this.field);
            this.field = field;
            this.information = information;
        }

        public void DrawFigure(bool[,] figure, int row, int col)
        {
            for (int r = 0; r < figure.GetLength(0); r++)
            {
                for (int c = 0; c < figure.GetLength(1); c++)
                {
                    Console.SetCursorPosition(col + c, row + r);

                    if (figure[r, c])
                    {
                        Console.Write('*');
                    }
                    else
                    {
                        Console.Write(string.Empty);
                    }
                }
            }
        }

        public void PrintControls()
        {
            var row = 14;
            var col = this.field.PlayingField.Cols + 2;

            Console.SetCursorPosition(col, row);
            var change = "   ▲/Space";
            Console.WriteLine(change);

            Console.SetCursorPosition(col, row + 1);
            var rightLeft = "◄     ►";
            Console.WriteLine(rightLeft);

            Console.SetCursorPosition(col, row + 2);
            var down = "   ▼   ";
            Console.WriteLine(down);            
        }

        public void PrintScore(string score)
        {
            var row = 1;
            var col = this.field.PlayingField.Cols + 2;
            Console.SetCursorPosition(col, row);

            Console.WriteLine($"Score: {this.information.Score}");
        }

        public void DrawWholeField(string wholeField)
        {
            Console.SetCursorPosition(0, 0);
            Console.Write(wholeField);
        }

        public void PrintLevel(string level)
        {
            var row = 3;
            var col = this.field.PlayingField.Cols + 2;
            Console.SetCursorPosition(col, row);

            Console.Write($"Level: {this.information.Level}");
        }

        public void ClearLine(bool[,] figure, int row, int col)
        {
            throw new NotImplementedException();
        }

        public void DrawOccupiedSpots(bool[,] matrix)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (matrix[r, c])
                    {
                        Console.SetCursorPosition(c + 1, r + 1);

                        Console.Write("*");
                    }
                }
            }
        }
    }
}
