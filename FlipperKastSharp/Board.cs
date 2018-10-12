using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipperKastSharp
{
    class Board
    {
        /// <summary>
        /// The list of balls that are currently on the board
        /// </summary>
        private List<Ball> balls;

        /// <summary>
        /// The list of balls to add next
        /// </summary>
        private List<Ball> addBalls = new List<Ball>();

        /// <summary>
        /// The list of elements that are on each position on the board
        /// </summary>
        private Dictionary<Tuple<int, int>, Elements> elements;

        /// <summary>
        /// The output of the running program
        /// </summary>
        private String outputString = "";

        /// <summary>
        /// Whether the program is done running
        /// </summary>
        public Boolean quit = false;

        /// <summary>
        /// Whether we are inputting or not
        /// </summary>
        public Boolean inputting = false;

        /// <summary>
        /// Add a ball to the board
        /// </summary>
        /// <param name="ball">The ball to add to the board</param>
        public void addBall(Ball ball)
        {
            // The balls to add are buffered in addBall for the next step, to prevent a conflict
            this.addBalls.Add(ball);
        }

        public void load(String path)
        {
            // Load data from file
            BoardLoader boardLoader = new BoardLoader(path);

            // Load tile view to render input
            this.elements = boardLoader.elements;
            this.balls = boardLoader.balls;

            // input balls
            boardLoader.inputBalls(this.displayInput);

            // load balls a final time
            this.balls = boardLoader.balls;
        }

        private char displayInput(Tuple<int, int> position)
        {
            // notify that we are buzy getting an input
            this.inputting = true;

            // clear the console
            Console.Clear();

            this.render();

            // show the position where we want to input the character
            Console.SetCursorPosition(position.Item1, position.Item2);

            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Cyan;

            // set the cursor character as a white hole
            Console.Write('?');
            Console.SetCursorPosition(position.Item1, position.Item2);

            // read the character
            char character = Console.ReadKey().KeyChar;

            // while the input is invalid, keep on asking
            while ((Convert.ToInt16(character) < Convert.ToInt16('0') || Convert.ToInt16(character) > Convert.ToInt16('9')) && (Convert.ToInt16(character) < Convert.ToInt16('A') && Convert.ToInt16(character) > Convert.ToInt16('Z')))
            {
                // set the cursor character as a white hole
                Console.Write('?');
                Console.SetCursorPosition(position.Item1, position.Item2);

                // read new character
                character = Console.ReadKey().KeyChar;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

            // notify we are done inputting
            this.inputting = false;

            return character;
        }

        /// <summary>
        /// Render a new state of the board
        /// </summary>
        public void render()
        {
            // clear the console
            Console.Clear();
            Console.SetCursorPosition(0, 0);

            foreach (Tuple<int, int> position in this.elements.Keys)
            {
                // move to where we want to output the element
                Console.SetCursorPosition(position.Item1, position.Item2);

                // write out the element's character
                Console.Write(this.elements[position].getCharacter());
            }

            // change the drawing color
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            foreach (Ball ball in this.balls)
            {
                // move to where we want to output the element
                Console.SetCursorPosition(ball.x, ball.y);

                // write out the element's character
                Console.Write(ball.character);
            }

            // Show prompt
            Console.SetCursorPosition(0, Console.WindowHeight-1);
            Console.BackgroundColor = ConsoleColor.Green;
            if (this.inputting) // if we are inputting a string, prompt for it in the command line
            {
                Console.Write("Please input value for ball");
            }
            else
            {
                Console.Write("Output: "); // else, show our output
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write(this.outputString);
            }
            // revert the drawing color
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        /// <summary>
        /// Update the board to a new state
        /// </summary>
        public void update()
        {
            List<Ball> toRemove = new List<Ball>();

            foreach(Ball ball in this.balls)
            {
                // Update ball
                ball.update();

                // Update tile under ball
                Tuple<int, int> ballposition = new Tuple<int, int>(ball.x, ball.y);
                if (elements.ContainsKey(ballposition)) // ...if there is an element under the ball on the board
                {
                    // then let element perform action on ball
                    elements[ballposition].doAction(ball,this);
                }

                // If the ball needs removing, add it to the waiting list for getting removed
                if (ball.toRemove)
                {
                    toRemove.Add(ball);
                }
            }

            // Remove all the balls on the removing list
            foreach(Ball ball in toRemove)
            {
                this.balls.Remove(ball);
            }

            // Add all new balls
            foreach(Ball ball in addBalls)
            {
                this.balls.Add(ball);
            }
            addBalls=new List<Ball>();

            // If there are no balls left, stop the program
            if (this.balls.Count == 0)
            {
                this.quit = true;
            }
        }

        /// <summary>
        /// Add a character to the output buffer
        /// </summary>
        /// <param name="character">The character to add</param>
        public void output(char character)
        {
            // add string to output to the output string
            this.outputString += character;
        }
    }
}
