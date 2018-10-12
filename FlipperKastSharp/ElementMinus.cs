using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipperKastSharp
{
    class ElementMinus : Elements
    {
        /// <summary>
        /// Perform the appropriate action on the ball when it touches the '-' character
        /// 
        /// Decreases the value of the ball
        /// </summary>
        /// <param name="ball">The ball to perform the action on</param>
        public void doAction(Ball ball, Board board)
        {
            ball.decrease();
        }

        /// <summary>
        /// Get the representation for the element
        /// </summary>
        /// <returns>The character for the Minus element ('-')</returns>
        public char getCharacter()
        {
            return '-';
        }
    }
}

