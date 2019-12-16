namespace Tetris.Layout
{
    using System.Text;
    using Contracts;
    
    public class TetrisField : ITetrisField
    {
        private const int StatisticsColsConst = 10;
        private const int ConstRows = 20;
        private const int PlayingFieldColsConst = 10;

        public TetrisField()
        {
            this.PlayingField = new PlayingField();
            this.StatisticsCols = StatisticsColsConst;
        }

        public IPlayingField PlayingField { get; private set; }

        public  int StatisticsCols { get; private set; }

        public string Field => CreateField();

        private string CreateField()
        {
            var outputField = new StringBuilder();

            outputField.Append('╔');
            outputField.Append('═', this.PlayingField.Cols);
            outputField.Append('╦');
            outputField.Append('═', this.StatisticsCols);
            outputField.Append('╗');

            for (int i = 0; i < this.PlayingField.Rows; i++)
            {
                var line = new StringBuilder();

                line.AppendLine();
                line.Append('║');
                line.Append(' ', this.PlayingField.Cols);
                line.Append('║');
                line.Append(' ', this.StatisticsCols);
                line.Append("║");

                outputField.Append(line.ToString().TrimEnd());
            }

            outputField.AppendLine();
            outputField.Append('╚');
            outputField.Append('═', this.PlayingField.Cols);
            outputField.Append('╩');
            outputField.Append('═', this.StatisticsCols);
            outputField.Append('╝');

            return outputField.ToString().TrimEnd();
        }
    }
}
