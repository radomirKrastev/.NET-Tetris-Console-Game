namespace Tetris.Core
{
    using System;
    using System.Threading;
    using System.Collections.Generic;
    using GameInformation;
    using GameInformation.Contracts;
    using Tetris.Controllers;
    using Tetris.Controllers.Contracts;
    using Tetris.TFigures;
    using Tetris.TFigures.Contracts;
    using Tetris.Core.Contracts;
    using IO.Contracts;
    using IO;
    using Layout;
    using Layout.Contracts;

    public class Engine : IEngine
    {
        private IDrawable drawer;
        private ITetrisField field;
        private IGameInformable information;
        private IFigures figures;
        private IController controller;
        private int frame;
        private int framesPerSecond;
        private int currentRow;
        private int currentCol;
        private Queue<bool[,]> currentFigures;
        private bool[,] fallingFigure;

        public Engine()
        {
            this.field = new TetrisField();
            this.information = new GameInformation();
            this.drawer = new Drawer(this.field, this.information);
            this.figures = new Figures();
            this.controller = new Controller(this.field);
            this.frame = 1;
            this.framesPerSecond = 16;
            this.currentRow = 1;
            this.currentCol = 4;
            this.currentFigures = new Queue<bool[,]>();
        }

        public void Run()
        {
            this.GenerateFigure();
            this.DrawLayout();
            this.drawer.DrawFigure(fallingFigure, this.currentRow, this.currentCol);

            while (true)
            {
                if(this.controller.CheckIfGameIsOver(this.fallingFigure, this.currentCol))
                {
                    this.drawer.GameOver(this.information.Score);
                    Environment.Exit(0);
                }

                UpdateLevel();
                CheckForPressedKeyAndExecuteCommand(false);

                this.frame++;

                if (this.frame == this.framesPerSecond - this.information.Level)
                {
                    this.frame = 1;
                    this.currentRow++;
                }

                this.DrawLayout();
                this.drawer.DrawOccupiedSpots(this.field.Matrix);
                this.drawer.DrawFigure(this.fallingFigure, this.currentRow, this.currentCol);

                if (this.controller.FigureCollides(this.fallingFigure, currentRow, currentCol))
                {
                    Thread.Sleep(100);
                    CheckForPressedKeyAndExecuteCommand(true);

                    for (int r = 0; r < fallingFigure.GetLength(0); r++)
                    {
                        for (int c = 0; c < fallingFigure.GetLength(1); c++)
                        {
                            if (fallingFigure[r, c])
                            {
                                this.field.Matrix[this.currentRow -1 + r, this.currentCol + c - 1] = true;
                            }
                        }
                    }

                    var linesClearedCount = this.controller.ClearLines();
                    this.GiveLinesClearedScore(linesClearedCount);
                    
                    this.drawer.DrawOccupiedSpots(this.field.Matrix);

                    this.currentCol = 4;
                    this.currentRow = 1;
                    this.frame = 0;

                    this.GenerateFigure();
                }


                Thread.Sleep(40);
            }
        }

        private void UpdateLevel()
        {
            if (this.information.Score <= 0)
            {
                this.information.Level = 1;
                return;
            }

            this.information.Level = (int)Math.Log10(this.information.Score) - 1;

            if (this.information.Level < 1)
            {
                this.information.Level = 1;
            }

            if (this.information.Level > 10)
            {
                this.information.Level = 10;
            }
        }

        private void CheckForPressedKeyAndExecuteCommand(bool collision)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.Spacebar)
                {
                    this.fallingFigure = controller.RotateFigure(this.fallingFigure, this.currentRow, this.currentCol, this.currentFigures);
                }

                if (key.Key == ConsoleKey.LeftArrow)
                {
                    this.currentCol = controller.MoveLeft(this.fallingFigure, this.currentRow, this.currentCol);
                }

                if (key.Key == ConsoleKey.RightArrow)
                {
                    this.currentCol = controller.MoveRight(this.fallingFigure, this.currentRow, this.currentCol);
                }

                if (key.Key == ConsoleKey.DownArrow 
                    && this.fallingFigure.GetLength(0) - 1 + this.currentRow < this.field.PlayingFieldRows
                    && collision == false
                    && this.frame + 1 < this.framesPerSecond - this.information.Level)
                {
                    this.frame++;
                    this.information.Score++;
                    this.currentRow++;
                }
            }
        }

        private void GiveLinesClearedScore(int linesCleared)
        {
            switch (linesCleared)
            {
                case 0:
                    break;
                case 1:
                    this.information.Score += 40 * (this.information.Level + 1);
                    break;
                case 2:
                    this.information.Score += 100 * (this.information.Level + 1);
                    break;
                case 3:
                    this.information.Score += 300 * (this.information.Level + 1);
                    break;
                case 4:
                    this.information.Score += 1200 * (this.information.Level + 1);
                    break;
            }
        }

        private void DrawLayout()
        {
            this.drawer.DrawWholeField(this.field.Field);
            this.drawer.PrintScore(this.information.Score.ToString());
            this.drawer.PrintLevel(this.information.Level.ToString());
            this.drawer.PrintControls();
        }

        private void GenerateFigure()
        {
            var random = new Random();
            var index = random.Next(0, this.figures.List.Count);
            this.currentFigures = new Queue<bool[,]>(this.figures.List[index]);
            this.fallingFigure = currentFigures.Dequeue();
            this.currentFigures.Enqueue(fallingFigure);

            if (fallingFigure.GetLength(0) == 2 && fallingFigure.GetLength(1) == 1)
            {
                this.currentCol += 1;
            }
        }
    }
}
