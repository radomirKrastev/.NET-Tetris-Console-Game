namespace Tetris.GameInformation
{
    using Contracts;

    public class Information : IInformable
    {
        public Information()
        {
            this.Level = 1;
            this.Score = 0;
        }

        public int Score { get; set; }

        public bool[,] NextFigure { get; set; }

        public int Level { get; set; }
    }
}
