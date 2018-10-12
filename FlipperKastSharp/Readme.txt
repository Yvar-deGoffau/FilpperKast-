FlipperKast# --- A language where everything bounces!
-----------------------------------------------------

Welcome to FlipperKast#. We are here to provide entertainment whilst we calculate your result.
For this, you can design multiple 2-dimensional boards, and the program is going to bounce some alphanumeric pinballs around to calculate their value.

You have to your disposition the following commands:

 ________ _____________________________________________________________________________
| 0 to 9 |           | These are the different balls. 
| A to Z | Balls     | They have a value of '0' to '9' and 'A' to 'Z', and will automatically start rolling to the right upon starting the program
|________|___________|_________________________________________________________________
|        |           | This is a ball the user can input its own value for!
|   ?    | Input     | Other than that, their behaviour is exactly the same as the regular pinballs
|________|___________|_________________________________________________________________
|        |           | These increase or decrease the value of every ball that rolls over them.
| +   -  | Bumpers   | If a ball become smaller than '0' or larger than 'Z', it will automatically evaporate!
|________|___________|_________________________________________________________________
|   ^    |           | These force the ball to head into one direction, 
| < v >  | Slopes    |  unless a ball is heading straight in the opposite direction, in which case they let it pass.
|________|___________|_________________________________________________________________
|        |           | These will let a ball bounce, 
|  /  \  | Flippers  |  then will flip themself to face the other direction.
|________|___________|_________________________________________________________________
|        |           | These will let balls bounce that come straight in the opposite direction.
|  =  |  | Walls     | Those that follow their path will continue straight on.
|________|___________|_________________________________________________________________
|        |           |
|   *    | Splitters | This will split the ball into 2, letting them head the opposite direction.
|________|___________|_________________________________________________________________
|        |           |
|   #    | Output    | This will output the value of the ball to the console, then destroy it.
|________|___________|_________________________________________________________________

The program ends when there are no balls left.

Don't forget to check out the demo's in the .\Demo folder!

=======================================================================================

.\Demo\add.txt
*===========*
|      >?v  |  Input 2 numbers, and this program will add them together!
| ? >  v    | 
|        -  |  Output: The sum of the 2 numbers
|   ^+ \ <# |
*===========*

=======================================================================================

.\Demo\duplicate.txt
*===========*
|      >?v  |  Input a number, and this program will multiply it by 2!
| 0 >  v    | 
|   +    -  |  Output: Twice the number you had
|   ^+ \ <# |
*===========*
 
=======================================================================================

.\Demo\helloworld.txt
*=========================*
|      >8v                |
| 8 >  v                  | Prints a Hello World message for you
|        - #              |
|   ^+ \ <+*              | Output: HELLOWORLD
|    #v++++*---#          |
|    **+++     */\/\/\/\  |
|    #                    |
|                         |
|      >Gv                |
| G >  v                  |
|        -                |
|   ^+ \ <#    \/\/\/\/ # |
|                  #+++** |
|                  *--- < | 
|         #--------<      |
*=========================*