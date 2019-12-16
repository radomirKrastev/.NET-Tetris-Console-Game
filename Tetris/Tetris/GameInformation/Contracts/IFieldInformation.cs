namespace Tetris.GameInformation.Contracts
{
    public class IFieldInformation
    {
        int Rows { get; }

        int PlayingFieldCols { get; }

        int StatisticsCols { get; }
    }
}
