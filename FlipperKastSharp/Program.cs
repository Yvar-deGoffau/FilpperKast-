using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipperKastSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            // create a new board
            Board board = new Board();

            // load in the file
            board.load(args[0]);

            // execute the program
            while (!board.quit)
            {
                board.update();
                board.render();
                System.Threading.Thread.Sleep(250);
            }
            System.Threading.Thread.Sleep(2000);
        }
    }
}
