﻿namespace Tetris.Layout.Contracts
{
    public interface ITetrisField
    {
        IPlayingField PlayingField { get; }

        IStatisticsField StatisticsField { get; }

        string ToString();
    }
}