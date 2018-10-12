using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipperKastSharp
{
    class ElementBar : Elements
    {
        private BarDirection direction;

        /// <summary>
        /// Map a direction to its inverse direction
        /// </summary>
        Dictionary<Direction, Direction> inverseDirection = new Dictionary<Direction, Direction>()
        {
            { Direction.Left , Direction.Right },
            { Direction.Right , Direction.Left },
            { Direction.Up , Direction.Down },
            { Direction.Down , Direction.Up },
        };

        public ElementBar(char character)
        {
            // match the direction to the character
            if (character == '=')
            {
                this.direction = BarDirection.Horizontal;
            }
            else if (character == '|')
            {
                this.direction = BarDirection.Vertical;
            }
            else
            {
                throw new NotImplementedException();
            }
        }


        /// <summary>
        /// Perform an action on the ball
        /// 
        /// Bounce the ball if needed
        /// </summary>
        /// <param name="ball">The ball to perform the action on</param>
        /// <param name="board"></param>
        public void doAction(Ball ball, Board board)
        {
            if (this.direction == BarDirection.Horizontal && (ball.direction == Direction.Up || ball.direction == Direction.Down))
            {
                ball.direction = inverseDirection[ball.direction];
            }
            if (this.direction == BarDirection.Vertical && (ball.direction == Direction.Left || ball.direction == Direction.Right))
            {
                ball.direction = inverseDirection[ball.direction];
            }
        }

        /// <summary>
        /// The character to represent the bar with
        /// </summary>
        /// <returns>The character to represent the bar with</returns>
        public char getCharacter()
        {
            if (this.direction == BarDirection.Horizontal)
            {
                return '=';
            }
            else if (this.direction == BarDirection.Vertical)
            {
                return '|';
            }
            throw new NotImplementedException();
        }
    }
}
