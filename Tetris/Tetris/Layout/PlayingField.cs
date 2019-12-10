namespace Tetris.Layout
{
    using Contracts;

    public class PlayingField : IPlayingField
    {
        private const int ConstRows = 20;
        private const int ConstCols = 10;

        public PlayingField()
        {
            this.Rows = ConstRows;

            this.Cols = ConstCols;
        }

        public int Rows {get; private set;}

        public int Cols { get; private set; }
    }
}
