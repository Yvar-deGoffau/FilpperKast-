using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipperKastSharp
{
    class ElementCross : Elements
    {
        /// <summary>
        /// Perform an action on the ball
        /// 
        /// Duplicates a ball whilst bouncing it
        /// </summary>
        /// <param name="ball">The ball to duplicate and/or to bounce</param>
        /// <param name="board"></param>
        public void doAction(Ball ball, Board board)
        {
            // bounce ball whilst duplicating it
            if (ball.direction == Direction.Left || ball.direction == Direction.Right)
            {
                // bounce the current ball *up*
                ball.direction = Direction.Up;

                // bounce a next ball *down*
                Ball newBall = new Ball(ball.x, ball.y, ball.character, Direction.Down);
                board.addBall(newBall);
            }

            else if (ball.direction == Direction.Up || ball.direction == Direction.Down)
            {
                // bounce the current ball *left*
                ball.direction = Direction.Left;

                // bounce a next ball *right*
                Ball newBall = new Ball(ball.x, ball.y, ball.character, Direction.Right);
                board.addBall(newBall);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
        
        /// <summary>
        /// The character to represent the cross with
        /// </summary>
        /// <returns>The character to represent the cross with</returns>
        public char getCharacter()
        {
            return '*';
        }
    }
}
