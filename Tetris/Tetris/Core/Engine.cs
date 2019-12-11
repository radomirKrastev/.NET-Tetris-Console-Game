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

    public class Engine : IEngine
    {
        private IDrawable drawer;
        private ITetrisField field;
        private IInformable information;
        private IFigures figures;
        private int frame;
        private int framesPerSecond;
        private int currentRow;
        private int currentCol;

        public Engine()
        {
            this.field = new TetrisField();
            this.information = new Information();
            this.drawer = new Drawer();
            this.figures = new Figures();
            this.frame = 1;
            this.framesPerSecond = 16;
            this.currentRow = 1;
            this.currentCol = 4;
        }

        public void Run()
        {
            //user inpu
            //change state
            //redraw UI
            

            var currentFigures = new Queue<bool[,]>();

            while (true)
            {
                this.information.Score++;

                var random = new Random();

                var index = random.Next(0, this.figures.List.Count);

                currentFigures = this.figures.List[index];

                var fallingFigure = currentFigures.Dequeue();
                currentFigures.Enqueue(fallingFigure);


                if(fallingFigure.GetLength(0) == 2 && fallingFigure.GetLength(1) == 1)
                {
                    this.currentCol += 1;
                }

                while (true)
                {
                    while (!(this.frame++ % this.framesPerSecond == 0))
                    {
                        Thread.Sleep(40);
                    }

                    this.field.DrawField();
                    this.drawer.DrawFigure(fallingFigure, this.currentRow, this.currentCol);
                    this.currentRow++;
                }
                

                

                   
            }
        }
    }
}
