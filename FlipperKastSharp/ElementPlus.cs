using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipperKastSharp
{
    class ElementPlus : Elements
    {
        /// <summary>
        /// Perform the appropriate action on the ball when it touches the '+' character
        /// 
        /// Increases the value of the ball
        /// </summary>
        /// <param name="ball">The ball to perform the action on</param>
        public void doAction(Ball ball, Board board)
        {
            ball.increase();
        }

        /// <summary>
        /// Get the representation for the element
        /// </summary>
        /// <returns>The character for the Plus element ('+')</returns>
        public char getCharacter()
        {
            return '+';
        }
    }
}
