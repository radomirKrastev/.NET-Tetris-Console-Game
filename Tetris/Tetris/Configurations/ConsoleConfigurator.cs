using System;
using Tetris.Layout.Contracts;

namespace Tetris.Configurations
{
    public class ConsoleConfigurator
    {
        private ITetrisField field;

        public ConsoleConfigurator(ITetrisField field)
        {
            this.field = field;
        }

        public int FieldRows {get; private set;}

        public int FieldCols {get; private set;}

        public void Configure()
        {
            Console.Title = "Tetris v 1.0";

            this.FieldRows = 1 + this.field.PlayingField.Rows + 1;
            this.FieldCols = 1 + this.field.PlayingField.Cols + 1 + this.field.StatisticsCols + 1;

            Console.WindowHeight = this.FieldRows + 1;
            Console.WindowWidth = this.FieldCols;
            Console.BufferHeight = this.FieldRows + 1;
            Console.BufferWidth = this.FieldCols;
            Console.CursorVisible = false;
        }
    }
}
