using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipperKastSharp
{
    interface Elements
    {
        /// <summary>
        /// Get the character for the display output
        /// </summary>
        /// <returns>Char - output character</returns>
        Char getCharacter();

        /// <summary>
        /// Perform an action when a ball rolls over the element
        /// </summary>
        /// <param name="ball">The ball to perform the action on</param>
        void doAction(Ball ball, Board board);
    }
}
