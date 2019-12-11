namespace Tetris.GameInformation
{
    using Contracts;
    using IO;
    using IO.Contracts;

    public class Information : IInformable
    {
        private IDrawable drawer;

        public Information()
        {
            this.Level = 1;
            this.Score = 0;
            this.drawer = new Drawer();
        }

        public int Score { get; set; }

        public bool[,] NextFigure { get; set; }

        public int Level { get; set; }

        public string Controls => CreateControlsString();

        public void PrintControls()
        {
            throw new System.NotImplementedException();
        }

        public void PrintLevel()
        {
            var output = $"Level: {this.Level}";
            this.drawer.PrintLevel(output);
        }

        public void PrintNextFigure()
        {
            throw new System.NotImplementedException();
        }

        public void PrintScore()
        {
            var output = $"Score: {this.Score}";
            this.drawer.PrintScore(output);
        }

        private string CreateControlsString()
        {
            var upArrowControl = "    ";

            return upArrowControl;
        }
    }
}
