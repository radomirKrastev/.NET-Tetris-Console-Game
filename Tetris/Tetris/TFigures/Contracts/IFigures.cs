namespace Tetris.TFigures.Contracts
{
    using System.Collections.Generic;

    public interface IFigures
    {
        List<Queue<bool[,]>> List { get; }

        public bool[,] Rotate(Queue<bool[,]> rotations)
    }
}
