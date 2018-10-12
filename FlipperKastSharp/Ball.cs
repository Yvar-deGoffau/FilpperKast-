using System;

namespace FlipperKastSharp
{
    public class Ball
    {
        /// <summary>
        /// The current direction the ball is heading to
        /// </summary>
        public Direction direction;

        /// <summary>
        /// The current character the ball holds
        /// </summary>
        public char character { get; private set; }

        /// <summary>
        /// The current position of the ball
        /// </summary>
        public int x { get; private set; }
        public int y { get; private set; }

        /// <summary>
        /// Whether it is time to remove this object from the board
        /// </summary>
        public Boolean toRemove = false;

        /// <summary>
        /// Initialize a new ball on the board, with a default value of '0' for its character
        /// </summary>
        /// <param name="x">The horizontal position for the ball</param>
        /// <param name="y">The vertical position for the ball</param>
        public Ball(int x, int y)
        {
            // Initialize the position of the ball
            this.x = x;
            this.y = y;

            // Initialize the character
            this.character = '0';

            // Initialize the direction to go to the right by default
            this.direction = Direction.Right;
        }

        /// <summary>
        /// Initialize a new ball on the board, with a supplied character
        /// </summary>
        /// <param name="x">The horizontal position for the ball</param>
        /// <param name="y">The vertical position for the ball</param>
        /// <param name="character">The character to initialize the ball with</param>
        public Ball(int x, int y, char character) : this(x, y)
        {
            // Initialize the character to the supplied character
            this.character = character;
        }

        /// <summary>
        /// Initialize a new ball on the board, with a supplied character and directino
        /// </summary>
        /// <param name="x">The horizontal position for the ball</param>
        /// <param name="y">The vertical position for the ball</param>
        /// <param name="character">The character to initialize the ball with</param>
        public Ball(int x, int y, char character, Direction direction) : this(x, y, character)
        {
            // Initialize the character to the supplied character
            this.direction = direction;
        }

        public void update()
        {
            // move the ball depending on its direction
            switch (this.direction)
            {
                case Direction.Left:
                    this.x -= 1;
                    break;
                case Direction.Right:
                    this.x += 1;
                    break;
                case Direction.Up:
                    this.y -= 1;
                    break;
                case Direction.Down:
                    this.y += 1;
                    break;
                default:
                    break;

            }
        }

        /// <summary>
        /// Increase the value for the ball
        /// </summary>
        public void increase()
        {
            // increase the character
            this.character = Convert.ToChar(Convert.ToInt16(this.character) + 1);

            // if the character was '9', then make it 'A'
            if (this.character == Convert.ToChar(Convert.ToInt16('9') + 1))
            {
                this.character = 'A';
            }

            // if the character increases pass 'Z', discard it
            if (this.character == Convert.ToChar(Convert.ToInt16('Z') + 1))
            {
                this.toRemove = true;
            }
        }

        /// <summary>
        /// Decrease the value for the ball
        /// </summary>
        public void decrease()
        {
            // decrease the character
            this.character = Convert.ToChar(Convert.ToInt16(this.character) - 1);

            // if the character was 'A', then make it '9'
            if (this.character == Convert.ToChar(Convert.ToInt16('A') - 1))
            {
                this.character = '9';
            }

            // if the character decreases pass '0', discard it
            if (this.character == Convert.ToChar(Convert.ToInt16('0') - 1))
            {
                this.toRemove = true;
            }
        }
    }
}