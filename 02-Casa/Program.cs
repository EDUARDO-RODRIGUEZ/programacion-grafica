
using System;
using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;

namespace _02_Casa
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var window = new Window(GameWindowSettings.Default, new Vector2i(600, 800), "02-Casa"))
            {
                window.Run();
            }
        }

    }
}
