namespace Tetris.Layout.Contracts
{
    public interface ITetrisField
    {
        IPlayingField PlayingField { get; }

        int StatisticsCols { get; }

        string Field { get; }
    }
}
