namespace Tetris
{
    using System;
    using System.Collections.Generic;
    using Layout;
    using IO;
    using TFigures;
    using Tetris.Core;

    public class Program
    {
        public static void Main()
        {
            var engine = new Engine();
            engine.Run();
            

        }
    }
}
