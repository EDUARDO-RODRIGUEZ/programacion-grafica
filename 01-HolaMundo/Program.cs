
using System;
using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;

namespace _01_HolaMundo
{
    class Program
    {
        static void Main(string[] args)
        {
            var nativeWindowSettings = new NativeWindowSettings()
            {
                Size = new Vector2i(400, 500),
                Title = "01-HolaMundo",
            };

            using (var window = new Window(GameWindowSettings.Default, nativeWindowSettings))
            {
                window.Run();
            }
        }

    }
}
