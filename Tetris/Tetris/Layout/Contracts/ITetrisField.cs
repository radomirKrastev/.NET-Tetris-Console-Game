namespace Tetris.Layout.Contracts
{
    public interface ITetrisField
    {
        int StatisticsCols { get; }

        string Field { get; }

        public int PlayingFieldCols { get; }

        public int PlayingFieldRows { get; }

        bool[,] Matrix { get; }
    }
}
