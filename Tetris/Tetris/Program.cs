namespace Tetris
{
    using System;
    using System.Collections.Generic;
    using Layout;
    using IO;
    using TFigures;
    using Tetris.Core;
    using Tetris.Configurations;

    public class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var engine = new Engine();

            engine.Run();
            

        }
    }
}
