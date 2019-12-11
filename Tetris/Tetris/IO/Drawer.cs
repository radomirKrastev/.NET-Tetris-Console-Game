namespace Tetris.IO
{
    using System;
    using Contracts;
    //using Layout;
    //using Tetris.Layout.Contracts;

    public class Drawer : IDrawable
    {
        //private ITetrisField field;

        //public Drawer()
        //{
              //this.field = new TetrisField();
        //}

        public void DrawFigure(bool[,] figure, int row, int col)
        {
            throw new NotImplementedException();
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
            Console.WriteLine(wholeField);
        }

        public void PrintLevel(string level)
        {
            throw new NotImplementedException();
        }
    }
}
