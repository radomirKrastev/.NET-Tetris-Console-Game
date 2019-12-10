namespace Tetris.IO
{
    using System;
    using System.Text;
    using Contracts;
    using Layout;
    
    public class Drawer : IDrawable
    {
        public void DrawField()
        {
            var field = new TetrisField();
            var fieldRows = 1 + field.PlayingField.Rows + 1;
            var fieldCols = 1 + field.PlayingField.Cols + 1 + field.StatisticsField.Cols + 1;

            Console.WindowHeight = fieldRows + 1;
            Console.WindowWidth = fieldCols;
            Console.BufferHeight = fieldRows + 1;
            Console.BufferWidth = fieldCols;
            Console.CursorVisible = false;

            var outputField = new StringBuilder();

            outputField.Append('╔');
            outputField.Append('═', field.PlayingField.Cols);
            outputField.Append('╦');
            outputField.Append('═', field.StatisticsField.Cols);
            outputField.Append('╗');

            for (int i = 0; i < field.PlayingField.Rows; i++)
            {
                var line = new StringBuilder();

                line.AppendLine();
                line.Append('║');
                line.Append(' ', field.PlayingField.Cols);
                line.Append('║');
                line.Append(' ', field.StatisticsField.Cols);
                line.Append("║");

                outputField.Append(line.ToString().TrimEnd());
            }

            outputField.AppendLine();
            outputField.Append('╚');
            outputField.Append('═', field.PlayingField.Cols);
            outputField.Append('╩');
            outputField.Append('═', field.StatisticsField.Cols);
            outputField.Append('╝');

            var layout = outputField.ToString().TrimEnd();

            Console.WriteLine(layout);
        }

        public void Write(int row, int col, ConsoleColor color)
        {
            throw new NotImplementedException();
        }

        public void WriteLine(int row, int col, ConsoleColor color)
        {
            throw new NotImplementedException();
        }
    }
}
