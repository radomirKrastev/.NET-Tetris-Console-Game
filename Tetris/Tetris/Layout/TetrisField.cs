namespace Tetris.Layout
{
    using Contracts;
    using System.Text;

    public class TetrisField : ITetrisField
    {
        public TetrisField()
        {
            this.PlayingField = new PlayingField();
            this.StatisticsField = new StatisticsField();
        }

        public IPlayingField PlayingField { get; private set; }

        public  IStatisticsField StatisticsField { get; private set; }

    }
}
