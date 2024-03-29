﻿namespace Tetris.IO
{
    using System;
    using System.Text;
    using Contracts;
    using Tetris.Configurations;
    using Tetris.GameInformation.Contracts;
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
                    if (figure[r, c] && col <= 10 && col > 0 && row <= 20 && row > 0 )
                    {
                        Console.SetCursorPosition(col + c, row + r);
                        Console.Write('*');
                    }
                }
            }
        }

        public void PrintControls()
        {
            var row = 14;
            var col = this.field.PlayingFieldCols + 2;

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

        public void PrintScore(int score, int highScore)
        {
            var row = 1;
            var col = this.field.PlayingFieldCols + 2;
            Console.SetCursorPosition(col, row);
            Console.WriteLine($"Score:");
            Console.SetCursorPosition(col, row + 1);
            Console.WriteLine($"{score}");

            Console.SetCursorPosition(col, row + 3);
            Console.WriteLine($"Best Ever:");
            Console.SetCursorPosition(col, row + 4);

            if(highScore < score)
            {
                Console.WriteLine($"{score}");
            }
            else
            {
                Console.WriteLine($"{highScore}");
            }
            
        }

        public void DrawWholeField(string wholeField)
        {
            Console.SetCursorPosition(0, 0);
            Console.Write(wholeField);
        }

        public void PrintLevel(string level)
        {
            var row = 4;
            var col = this.field.PlayingFieldCols + 2;
            Console.SetCursorPosition(col, row + 3);
            Console.Write($"Level:");
            Console.SetCursorPosition(col, row + 4);
            Console.Write($"{this.information.Level}");
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

        public void GameOver(int score)
        {
            var spaces = new string(' ', 12 - 1 - 1 - score.ToString().Length);
            Console.SetCursorPosition(5, 5);
            Console.Write("╔══════════╗");
            Console.SetCursorPosition(5, 6);
            Console.Write("║Game Over:║");
            Console.SetCursorPosition(5, 7);
            Console.Write($"║{score.ToString()}{spaces}║");
            Console.SetCursorPosition(5, 8);
            Console.Write("╚══════════╝");
        }
    }
}
