namespace Tetris.GameInformation.Contracts
{
    public interface IFieldInformation
    {
        int Rows { get; }

        int PlayingFieldCols { get; }

        int StatisticsCols { get; }
    }
}
