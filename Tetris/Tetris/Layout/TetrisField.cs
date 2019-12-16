namespace Tetris.Layout
{
    using System.Text;
    using Contracts;
    
    public class TetrisField : ITetrisField
    {
        private const int StatisticsColsConst = 10;
        private const int ConstRows = 20;
        private const int PlayingFieldColsConst = 10;
        private bool[,] matrix;

        public TetrisField()
        {
            this.PlayingFieldCols = PlayingFieldColsConst;
            this.PlayingFieldRows = ConstRows;
            this.StatisticsCols = StatisticsColsConst;
            this.matrix = new bool[this.PlayingFieldRows, this.PlayingFieldCols];
        }

        public int StatisticsCols { get; private set; }

        public int PlayingFieldCols { get; private set; }

        public int PlayingFieldRows { get; private set; }

        public string Field => CreateField();

        public bool[,] Matrix => this.matrix;

        private string CreateField()
        {
            var outputField = new StringBuilder();

            outputField.Append('╔');
            outputField.Append('═', this.PlayingFieldCols);
            outputField.Append('╦');
            outputField.Append('═', this.StatisticsCols);
            outputField.Append('╗');

            for (int i = 0; i < this.PlayingFieldRows; i++)
            {
                var line = new StringBuilder();

                line.AppendLine();
                line.Append('║');
                line.Append(' ', this.PlayingFieldCols);
                line.Append('║');
                line.Append(' ', this.StatisticsCols);
                line.Append("║");

                outputField.Append(line.ToString().TrimEnd());
            }

            outputField.AppendLine();
            outputField.Append('╚');
            outputField.Append('═', this.PlayingFieldCols);
            outputField.Append('╩');
            outputField.Append('═', this.StatisticsCols);
            outputField.Append('╝');

            return outputField.ToString().TrimEnd();
        }
    }
}
