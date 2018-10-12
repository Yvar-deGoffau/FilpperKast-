using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FlipperKastSharp
{
    class BoardLoader
    {
        /// <summary>
        /// Map the input character to an output element creation lambda
        /// </summary>
        Dictionary<char, Expression<Func<char, Elements>>> mapKeyToElement = new Dictionary<char, Expression<Func<char, Elements>>>()
        {
            {'<', character => new ElementArrow(character) },
            {'>', character => new ElementArrow(character) },
            {'^', character => new ElementArrow(character) },
            {'v', character => new ElementArrow(character) },
            {'=', character => new ElementBar(character) },
            {'|', character => new ElementBar(character) },
            {'*', character => new ElementCross() },
            {'-', character => new ElementMinus() },
            {'+', character => new ElementPlus() },
            {'#', character => new ElementSharp() },
            {'/', character => new ElementSlash(character) },
            {'\\', character => new ElementSlash(character) },
        };


        /// <summary>
        /// The list of elements that are on each position on the board
        /// </summary>
        public Dictionary<Tuple<int, int>, Elements> elements;

        /// <summary>
        /// The list of balls
        /// </summary>
        public List<Ball> balls;

        /// <summary>
        /// The list of balls to input
        /// </summary>
        public List<Tuple<int, int>> ballsToInput; 

        /// <summary>
        /// Load board from file at path
        /// </summary>
        /// <param name="path">The path to the board file</param>
        public BoardLoader(String path) : this(File.OpenRead(path)) { }

        /// <summary>
        /// Load board from FileStream
        /// </summary>
        /// <param name="file">The FileStream to load the board from</param>
        public BoardLoader(FileStream file)
        {
            // containers for the newly loaded elements
            this.elements = new Dictionary<Tuple<int, int>, Elements>();
            this.balls = new List<Ball>();
            this.ballsToInput = new List<Tuple<int, int>>();

            // position counters
            int x = 0;
            int y = 0;

            // Read in the file in chunks of 1024
            byte[] b = new byte[1024];
            UTF8Encoding temp = new UTF8Encoding(true);
            while (file.Read(b, 0, b.Length) > 0)
            {
                foreach(char character in b)
                {
                    // If we encounter a new line, return to the next line
                    if (character == '\n')
                    {
                        x = 0;
                        y += 1;
                        continue;
                    }

                    // If the character is a space, skip it
                    if (character == ' ')
                    {
                        // increase column counter
                        x += 1;
                        continue;
                    }

                    // If the character is a line return, ignore it
                    if (character == '\r')
                    {
                        continue;
                    }

                    // If the character we encountered is a key
                    else if (mapKeyToElement.ContainsKey(character))
                    {
                        // Extract and initialize the object from the dictionnary
                        Expression<Func<char, Elements>> expression = mapKeyToElement[character];
                        Elements newElement = expression.Compile()(character);

                        // Safe the object in the dictionnary
                        this.elements[new Tuple<int, int>(x, y)] = newElement;
                    }

                    // If the character we encountered is a ball from 0 to 9
                    else if (Convert.ToInt16(character) >= Convert.ToInt16('0') && Convert.ToInt16(character) <= Convert.ToInt16('9'))
                    {
                        Ball ball = new Ball(x, y, character);
                        this.balls.Add(ball);
                    }

                    // If the character we encountered is a ball from A to Z
                    else if (Convert.ToInt16(character) >= Convert.ToInt16('A') && Convert.ToInt16(character) <= Convert.ToInt16('Z'))
                    {
                        Ball ball = new Ball(x, y, character);
                        this.balls.Add(ball);
                    }

                    // If the character we encountered is a ball to input
                    else if (character == '?')
                    {
                        ballsToInput.Add(new Tuple<int, int>(x, y));
                    }

                    // If it is an unknown character, raise an error
                    else
                    {
                        //throw new NotImplementedException("Unknown character '"+character+"' in file");
                        continue;
                    }

                    // increase column counter
                    x += 1;
                }
            }
        }

        /// <summary>
        /// Show the prompt for each ball that we need to input
        /// </summary>
        /// <param name="displayInput">The function to call to get an input for a ball at position 'int,int' as a char</param>
        public void inputBalls(Func<Tuple<int,int>,char> displayInput)
        {
            foreach(Tuple<int,int> ballPosition in ballsToInput)
            {
                // input a character for the next ball
                char character = displayInput(ballPosition);
                
                // while the input is invalid, repeat the input
                while ((Convert.ToInt16(character) < Convert.ToInt16('0') || Convert.ToInt16(character) > Convert.ToInt16('9')) && (Convert.ToInt16(character) < Convert.ToInt16('A') && Convert.ToInt16(character) > Convert.ToInt16('Z')))
                {
                    character = displayInput(ballPosition);
                }

                // initialize the ball
                Ball newBall = new Ball(ballPosition.Item1, ballPosition.Item2, character);

                // add it to list of current balls
                this.balls.Add(newBall);
            }

            ballsToInput = new List<Tuple<int, int>>();
        }
    }
}
