namespace Tetris.Layout
{
    using Contracts;
    using System;
    using System.Text;
    using IO.Contracts;
    using IO;

    public class TetrisField : ITetrisField
    {
        private IDrawable drawer;

        public TetrisField()
        {
            this.PlayingField = new PlayingField();
            this.StatisticsField = new StatisticsField();
        }

        public IPlayingField PlayingField { get; private set; }

        public  IStatisticsField StatisticsField { get; private set; }

        public string Field => CreateField();

        private string CreateField()
        {
            //var fieldRows = 1 + this.PlayingField.Rows + 1;
            //var fieldCols = 1 + this.PlayingField.Cols + 1 + this.StatisticsField.Cols + 1;

            ////TODO da iznesa Console class-a

            //Console.WindowHeight = fieldRows + 1;
            //Console.WindowWidth = fieldCols;
            //Console.BufferHeight = fieldRows + 1;
            //Console.BufferWidth = fieldCols;
            //Console.CursorVisible = false;

            var outputField = new StringBuilder();

            outputField.Append('╔');
            outputField.Append('═', this.PlayingField.Cols);
            outputField.Append('╦');
            outputField.Append('═', this.StatisticsField.Cols);
            outputField.Append('╗');

            for (int i = 0; i < this.PlayingField.Rows; i++)
            {
                var line = new StringBuilder();

                line.AppendLine();
                line.Append('║');
                line.Append(' ', this.PlayingField.Cols);
                line.Append('║');
                line.Append(' ', this.StatisticsField.Cols);
                line.Append("║");

                outputField.Append(line.ToString().TrimEnd());
            }

            outputField.AppendLine();
            outputField.Append('╚');
            outputField.Append('═', this.PlayingField.Cols);
            outputField.Append('╩');
            outputField.Append('═', this.StatisticsField.Cols);
            outputField.Append('╝');

            return outputField.ToString().TrimEnd();
        }
    }
}
