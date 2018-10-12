using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipperKastSharp
{
    class ElementArrow : Elements
    {
        /// <summary>
        /// The current direction
        /// </summary>
        Direction direction;

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

        public ElementArrow(char character)
        {
            // Map a character to a direction
            if (character == '<')
            {
                this.direction = Direction.Left;
            }
            else if (character == '>')
            {
                this.direction = Direction.Right;
            }
            else if (character == '^')
            {
                this.direction = Direction.Up;
            }
            else if (character == 'v')
            {
                this.direction = Direction.Down;
            }

            // If we have a unmapped direction, throw an exception
            else
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Perform an action on the ball
        /// 
        /// Move the ball to the direction specified with the arrow
        /// </summary>
        /// <param name="ball">The ball to change the direction for</param>
        /// <param name="board"></param>
        public void doAction(Ball ball, Board board)
        {
            if(ball.direction != inverseDirection[this.direction]) // If the ball is heading straight in the arrow, let it pass. 
            {
                ball.direction = this.direction; //Else, direct it towards the direction of the arrow
            }
        }

        /// <summary>
        /// The character to represent the arrow with
        /// </summary>
        /// <returns>The character to represent the arrow with</returns>
        public char getCharacter()
        {
            // Map a character to a direction
            if (this.direction == Direction.Left)
            {
                return '<';
            }
            else if (this.direction == Direction.Right)
            {
                return '>';
            }
            else if (this.direction == Direction.Up)
            {
                return '^';
            }
            else if (this.direction == Direction.Down)
            {
                return 'v';
            }

            // If we have a unmapped direction, throw an exception
            throw new NotImplementedException();
        }
    }
}
