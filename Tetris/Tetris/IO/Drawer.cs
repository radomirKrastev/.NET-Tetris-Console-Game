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
        private IInformable information;
        private ConsoleConfigurator configurator;

        public Drawer(TetrisField field)
        {
            this.configurator = new ConsoleConfigurator();
            this.field = field;
            this.information = new Information();
        }

        public void DrawFigure(bool[,] figure, int row, int col)
        {
            //Console.SetCursorPosition(col, row);

            //for (int i = 0; i < figure.GetLength(0); i++)
            //{
            //    for (int j = 0; j < figure.GetLength(1); j++)
            //    {
            //        if (figure[i, j])
            //        {
            //            Console.Write('*');
            //        }
            //        else
            //        {
            //            Console.Write(string.Empty);
            //        }
            //    }

            //    Console.SetCursorPosition(col, row + 1);
            //}

            for (int i = 0; i < figure.GetLength(0); i++)
            {
                for (int j = 0; j < figure.GetLength(1); j++)
                {
                    if (figure[i, j])
                    {
                        Console.Write('*');
                    }
                    else
                    {
                        Console.Write(string.Empty);
                    }
                }

                Console.SetCursorPosition(col, row + 1);
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
            Console.WriteLine(wholeField);
        }

        public void PrintLevel(string level)
        {
            var row = 3;
            var col = this.field.PlayingField.Cols + 2;
            Console.SetCursorPosition(col, row);

            Console.WriteLine($"Level: {this.information.Level}");
        }

        public void ClearLine(bool[,] figure, int row, int col)
        {
            throw new NotImplementedException();
        }
    }
}
