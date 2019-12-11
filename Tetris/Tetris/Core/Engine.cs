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

    public class Engine : IEngine
    {
        private IDrawable drawer;
        private ITetrisField field;
        private IInformable information;
        private IFigures figures;
        private int frame;
        private int framesPerSecond;


        public Engine()
        {
            this.field = new TetrisField();
            this.information = new Information();
            this.drawer = new Drawer();
            this.figures = new Figures();
            this.frame = 0;
            this.framesPerSecond = 15;
        }



        public void Run()
        {
            //user inpu
            //change state
            //redraw UI

            this.field.DrawField();


            var currentFigures = new Queue<bool[,]>();

            while (true)
            {
                this.information.Score++;

                currentFigures = this.figures.List[0];

                var fallingFigure = currentFigures.Dequeue();
                currentFigures.Enqueue(fallingFigure);

                for (int i = 0; i < this.framesPerSecond; i++)
                {

                }

                Thread.Sleep(40);   
            }
        }
    }
}
