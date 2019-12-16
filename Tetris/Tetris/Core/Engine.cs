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

        private void GenerateFigures()
        {
            var random = new Random();
            var index = random.Next(0, this.figures.List.Count);
            this.currentFigures = new Queue<bool[,]>(this.figures.List[index]);
            this.fallingFigure = currentFigures.Dequeue();
            this.currentFigures.Enqueue(fallingFigure);
        }

        public void Run()
        {
            //    var random = new Random();
            //    var index = random.Next(0, this.figures.List.Count);
            //    this.currentFigures = this.figures.List[index];
            //    this.fallingFigure = currentFigures.Dequeue();
            //    this.currentFigures.Enqueue(fallingFigure);

            GenerateFigures();

            if (fallingFigure.GetLength(0) == 2 && fallingFigure.GetLength(1) == 1)
            {
                this.currentCol += 1;
            }

            //var currentFigures = this.figures.List[2];
            //var fallingFigure = currentFigures.Dequeue();
            //currentFigures.Enqueue(fallingFigure);

            this.DrawLayout();
            this.drawer.DrawFigure(fallingFigure, this.currentRow, this.currentCol);

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey();

                    if (key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.Spacebar)
                    {
                        fallingFigure = controller.RotateFigure(fallingFigure, this.currentRow, this.currentCol, this.currentFigures);
                    }

                    if (key.Key == ConsoleKey.LeftArrow)
                    {
                        this.currentCol = controller.MoveLeft(fallingFigure, this.currentRow, this.currentCol);
                    }

                    if (key.Key == ConsoleKey.RightArrow)
                    {
                        this.currentCol = controller.MoveRight(fallingFigure, this.currentRow, this.currentCol);
                    }

                    if (key.Key == ConsoleKey.DownArrow)
                    {
                        this.frame++;
                        this.currentRow++;
                        this.information.Score++;
                    }
                }

                if (this.frame % this.framesPerSecond == 0)
                {
                    this.frame = 1;
                    this.currentRow++;                    
                }


                this.DrawLayout();
                this.drawer.DrawOccupiedSpots(this.field.PlayingField.Matrix);

                if (this.controller.FigureCollides(fallingFigure, currentRow, currentCol))
                {
                    for (int r = 0; r < fallingFigure.GetLength(0); r++)
                    {
                        for (int c = 0; c < fallingFigure.GetLength(1); c++)
                        {
                            if (fallingFigure[r, c])
                            {
                                this.field.PlayingField.Matrix[currentRow - 1 + r, currentCol + c -1] = true;
                            }
                        }
                    }

                    this.controller.ClearLines();

                    this.drawer.DrawOccupiedSpots(this.field.PlayingField.Matrix);

                    this.currentCol = 4;
                    this.currentRow = 1;
                    this.frame = 0;

                    GenerateFigures();
                }

                this.drawer.DrawFigure(fallingFigure, this.currentRow, this.currentCol);
                this.frame++;

                Thread.Sleep(40);
            }
        }

        private void DrawLayout()
        {
            this.drawer.DrawWholeField(this.field.Field);
            this.drawer.PrintScore(this.information.Score.ToString());
            this.drawer.PrintLevel(this.information.Level.ToString());
            this.drawer.PrintControls();
        }
    }
}
