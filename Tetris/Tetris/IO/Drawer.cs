namespace Tetris.IO
{
    using System;
    using Contracts;

    public class Drawer : IDrawable
    {
        public void DrawFigure(bool[,] figure, int row, int col)
        {
            Console.SetCursorPosition(col, row);

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


        public void PrintControls(string controls)
        {
            throw new NotImplementedException();
            //var row = 14;
            //var col = this.field.PlayingField.Cols + 2;
            //Console.SetCursorPosition(col, row);

            //Console.WriteLine("      ");

        }

        public void PrintScore(string score)
        {
            throw new NotImplementedException();
            //var row = 1;
            //var col = this.field.PlayingField.Cols+2;
            //Console.SetCursorPosition(col, row);

            Console.WriteLine("Score:");

        }

        public void DrawWholeField(string wholeField)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(wholeField);
        }

        public void PrintLevel(string level)
        {
            throw new NotImplementedException();
        }

        public void ClearLine(bool[,] figure, int row, int col)
        {
            throw new NotImplementedException();
        }
    }
}
