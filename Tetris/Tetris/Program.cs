namespace Tetris
{
    using System;
    using Layout;
    using Tetris.Core;
    using Tetris.Configurations;

    public class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var configurator = new ConsoleConfigurator(new TetrisField());
            configurator.Configure();

            var engine = new Engine();
            engine.Run();
        }
    }
}
