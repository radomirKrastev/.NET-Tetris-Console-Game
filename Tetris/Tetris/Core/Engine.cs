namespace Tetris.Core
{
    using System.Threading;
    using Tetris.Core.Contracts;
    using IO.Contracts;
    using IO;
    using Layout;
    using Layout.Contracts;
    using GameInformation;
    using GameInformation.Contracts;
    using Tetris.TFigures.Contracts;
    using Tetris.TFigures;
    using System.Collections.Generic;
    using System;
    using Tetris.Controllers.Contracts;
    using Tetris.Controllers;
    using Tetris.Configurations;

    public class Engine : IEngine
    {
        private IDrawable drawer;
        private ITetrisField field;
        private IInformable information;
        private IFigures figures;
        private IController controller;
        private ConsoleConfigurator configurator;
        private int frame;
        private int framesPerSecond;
        private int currentRow;
        private int currentCol;

        public Engine()
        {
            this.field = new TetrisField();
            this.information = new Information();
            this.drawer = new Drawer(this.field);
            this.figures = new Figures();
            this.controller = new Controller(this.field);
            this.configurator = new ConsoleConfigurator(this.field);
            this.frame = 1;
            this.framesPerSecond = 16;
            this.currentRow = 1;
            this.currentCol = 4;
        }

        public void Run()
        {
            //user input
            //change state
            //redraw UI

            this.configurator.Configure();

            //var random = new Random();
            //var index = random.Next(0, this.figures.List.Count);
            //var currentFigures = this.figures.List[index];
            //var fallingFigure = currentFigures.Dequeue();
            //currentFigures.Enqueue(fallingFigure);


            //if (fallingFigure.GetLength(0) == 2 && fallingFigure.GetLength(1) == 1)
            //{
            //    this.currentCol += 1;
            //}

            var currentFigures = this.figures.List[2];
            var fallingFigure = currentFigures.Dequeue();
            currentFigures.Enqueue(fallingFigure);

            this.drawer.DrawWholeField(this.field.Field);
            this.drawer.PrintScore(this.information.Score.ToString());
            this.drawer.PrintLevel(this.information.Level.ToString());
            this.drawer.PrintControls();
            this.drawer.DrawFigure(fallingFigure, this.currentRow, this.currentCol);

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey();

                    if (key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.Spacebar)
                    {
                        fallingFigure = controller.RotateFigure(fallingFigure, this.currentRow, this.currentCol, currentFigures);
                    }

                    if (key.Key == ConsoleKey.LeftArrow)
                    {
                        this.currentCol = controller.MoveLeft(fallingFigure, this.currentRow, this.currentCol);
                    }

                    if (key.Key == ConsoleKey.RightArrow)
                    {
                        this.currentCol = controller.MoveRight(fallingFigure, this.currentRow, this.currentCol);
                    }
                }

                if (this.frame % this.framesPerSecond == 0)
                {
                    this.frame = 1;
                    this.currentRow++;                    
                }

                this.drawer.DrawWholeField(this.field.Field);
                this.drawer.DrawOccupiedSpots(this.field.PlayingField.Matrix);
                this.drawer.PrintScore(this.information.Score.ToString());
                this.drawer.PrintLevel(this.information.Level.ToString());
                this.drawer.PrintControls();
               
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
                    
                    this.drawer.DrawOccupiedSpots(this.field.PlayingField.Matrix);

                    this.currentCol = 4;
                    this.currentRow = 1;

                    currentFigures = this.figures.List[2];
                    fallingFigure = currentFigures.Dequeue();
                    currentFigures.Enqueue(fallingFigure);


                    if (fallingFigure.GetLength(0) == 2 && fallingFigure.GetLength(1) == 1)
                    {
                        this.currentCol += 1;
                    }

                    this.frame = 0;
                }

                this.drawer.DrawFigure(fallingFigure, this.currentRow, this.currentCol);
                this.frame++;

                Thread.Sleep(40);
            }
        }
    }
}
