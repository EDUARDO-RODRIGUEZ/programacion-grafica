using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Casa
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Game game = new Game(800, 600, "03-Casa"))
            {
                game.Run(30.0);
            }
        }
    }
}
