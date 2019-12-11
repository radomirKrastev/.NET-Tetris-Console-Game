namespace Tetris.Layout
{
    using Contracts;

    public class PlayingField : IPlayingField
    {
        private const int ConstRows = 20;
        private const int ConstCols = 10;
        private bool[,] matrix;

        public PlayingField()
        {
            this.Rows = ConstRows;

            this.Cols = ConstCols;

            this.matrix = new bool[this.Rows, this.Cols];
        }

        public int Rows {get; private set;}

        public int Cols { get; private set; }

        public bool[,] Matrix => this.matrix;
    }
}
