using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipperKastSharp
{
    class ElementSharp : Elements
    {

        /// <summary>
        /// Perform an action on the ball
        /// 
        /// Output the ball to the standard output, then remove it from the board
        /// </summary>
        /// <param name="ball">The ball to output and to remove</param>
        /// <param name="board"></param>
        public void doAction(Ball ball, Board board)
        {
            // Output character for ball
            board.output(ball.character);

            // And delete ball
            ball.toRemove = true;
        }


        /// <summary>
        /// The character to represent the sharp with
        /// </summary>
        /// <returns>The character to represent the sharp with</returns>
        public char getCharacter()
        {
            return '#';
        }
    }
}
