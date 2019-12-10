namespace Tetris.Layout
{
    using Contracts;

    public class StatisticsField : IStatisticsField
    {
        private const int ConstCols = 10;

        public StatisticsField()
        {
            this.Cols = ConstCols;
        }

        public int Cols { get; private set; }
    }
}
