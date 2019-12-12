namespace Tetris.TFigures
{
    using System;
    using System.Collections.Generic;
    using Contracts;

    public class Figures : IFigures
    {
        private List<Queue<bool[,]>> list;

        public Figures()
        {
            this.list = new List<Queue<bool[,]>>();
            this.FillList();
        }

        public List<Queue<bool[,]>> List => this.list;

        private void FillList()
        {
            var figureI = new bool[,]
            {
                { true, true, true, true}
            };

            var rotatedI = new bool[,]
            {
                { true },
                { true },
                { true },
                { true }
            };

            var figuresI = new Queue<bool[,]>();
            figuresI.Enqueue(figureI);
            figuresI.Enqueue(rotatedI);
            this.list.Add(figuresI);

            var figureO = new bool[,]
            {
                { true, true },
                { true, true }
            };

            var figuresO = new Queue<bool[,]>();
            figuresO.Enqueue(figureO);
            this.list.Add(figuresO);

            var figureT = new bool[,]
            {
                { false, true, false },
                { true, true, true }
            };

            var leftRotatedT = new bool[,]
            {
                { true, false },
                { true, true },
                { true, false }
            };

            var rightRotatedT = new bool[,]
            {
                { false, true },
                { true, true },
                { false, true }
            };

            var downRotatedT = new bool[,]
            {
                { true, true, true },
                { false, true, false }
            };

            var figuresT = new Queue<bool[,]>();
            figuresT.Enqueue(figureT);
            figuresT.Enqueue(leftRotatedT);
            figuresT.Enqueue(rightRotatedT);
            figuresT.Enqueue(downRotatedT);
            this.list.Add(figuresT);

            var figureJ = new bool[,]
            {
                { true, false, false },
                { true, true, true }
            };

            var rightRotatedJ = new bool[,]
            {
                { true, true },
                { true, false },
                { true, false }
            };

            var downRotatedJ = new bool[,]
            {
                { true, true, true },
                { false, false, true }
            };

            var leftRotatedJ = new bool[,]
            {
                { false, true },
                { false, true },
                { true, true}
            };

            var figuresJ = new Queue<bool[,]>();
            figuresJ.Enqueue(figureJ);
            figuresJ.Enqueue(rightRotatedJ);
            figuresJ.Enqueue(downRotatedJ);
            figuresJ.Enqueue(leftRotatedJ);
            this.list.Add(figuresJ);

            var figureL = new bool[,]
            {
                { false, false, true },
                { true, true, true }
            };

            var rightRotatedL = new bool[,]
            {
                { true, false},
                { true, false},
                { true, true}
            };

            var downRotatedL = new bool[,]
            {
                { true, true, true },
                { true, false, false }
            };

            var leftRotatedL = new bool[,]
            {
                { true, true },
                { false, true },
                { false, true}
            };

            var figuresL = new Queue<bool[,]>();
            figuresL.Enqueue(figureL);
            figuresL.Enqueue(rightRotatedL);
            figuresL.Enqueue(downRotatedL);
            figuresL.Enqueue(leftRotatedL);
            this.list.Add(figuresL);

            var figureS = new bool[,]
            {
                { false, true, true },
                { true, true, false}
            };

            var rotatedS = new bool[,]
            {
                { true, false},
                { true, true},
                { false, true}
            };

            var figuresS = new Queue<bool[,]>();
            figuresS.Enqueue(figureS);
            figuresS.Enqueue(rotatedS);
            this.list.Add(figuresS);

            var figureZ = new bool[,]
            {
                { true, true, false },
                { false, true, true}
            };

            var rotatedZ = new bool[,]
            {
                { false, true},
                { true, true},
                { true, false}
            };

            var figuresZ = new Queue<bool[,]>();
            figuresZ.Enqueue(figureZ);
            figuresZ.Enqueue(rotatedZ);
            this.list.Add(figuresZ);
        }

        public bool [,] Rotate(Queue<bool[,]> rotations)
        {
            var figure = rotations.Dequeue();
            rotations.Enqueue(figure);

            return figure;
        }
    }
}
