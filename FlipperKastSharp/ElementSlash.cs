using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipperKastSharp
{
    class ElementSlash : Elements
    {
        /// <summary>
        /// The mapping of the direction the ball bounces back to when encountering a '/' character
        /// </summary>
        private Dictionary<Direction, Direction> ballMappingFalse = new Dictionary<Direction, Direction>()
                {
                    { Direction.Down , Direction.Left },
                    { Direction.Left , Direction.Down },
                    { Direction.Up , Direction.Right },
                    { Direction.Right , Direction.Up },
                };
        
        /// <summary>
        /// The mapping of the direction the ball bounces back to when encountering a '\' character
        /// </summary>
        private Dictionary<Direction, Direction> ballMappingTrue = new Dictionary<Direction, Direction>()
                {
                    { Direction.Down , Direction.Right },
                    { Direction.Left , Direction.Up },
                    { Direction.Up , Direction.Left },
                    { Direction.Right , Direction.Down },
                };

        /// <summary>
        /// Whether it is in '/' or '\' mode
        /// </summary>
        private Boolean state;

        /// <summary>
        /// Creates a '/' or '\' element in the right state
        /// </summary>
        /// <param name="character">Its state... can be either '/' or '\'</param>
        public ElementSlash(Char character)
        {
            //  Set the slash to the right state according to its initializer
            if (character == '\\')
            {
                this.state = true;
            }
            else if(character == '/')
            {
                this.state = false;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Perform action on encountering a ball.
        /// 
        /// The role of the '/' is to bounce the ball 90 degrees upon encounter, then flip itself to '\'.
        /// </summary>
        /// <param name="ball">The ball we encountered</param>
        public void doAction(Ball ball, Board board)
        {
            if (this.state == true)  // if the slash is in the '\' position
            {
                ball.direction = ballMappingTrue[ball.direction];
            }
            else
            {
                ball.direction = ballMappingFalse[ball.direction];
            }

            // Flip the element from '/' to '\', and visa versa
            this.state = !this.state;
        }


        /// <summary>
        /// The character to represent the slash with
        /// </summary>
        /// <returns>The character to represent the slash with</returns>
        public char getCharacter()
        {
            if (this.state == true)
            {
                return '\\';
            }
            else
            {
                return '/';
            }
        }
    }
}
