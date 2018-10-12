# FlipperKast# --- A language where everything bounces!

Welcome to FlipperKast#. We are here to provide entertainment whilst we calculate your result.
For this, you can design multiple 2-dimensional boards, and the program is going to bounce some alphanumeric pinballs around to calculate their value.

You have to your disposition the following commands:

| Command        | Name           | Description  |
|:-------------:|:-------------:| ----- |
| `0` to `9` & `A` to `Z` | Balls | They have a value of '0' to '9' and 'A' to 'Z', and will automatically start rolling to the right upon starting the program |
| `?` | Input | This is a ball the user can input its own value for |
| `+` and `-` | Bumpers | These increase or decrease the value of every ball that rolls over them. If a ball become smaller than '0' or larger than 'Z', it will automatically evaporate! |
| `<`, `^`, `>`, `v` | Slopes | These force the ball to head into one direction, unless a ball is heading straight in the opposite direction, in which case they let it pass. |
| `/`, `\` | Flippers | These will let a ball bounce, then will flip themself to face the other direction. |
| `=`, `¦` | Walls | These will let balls bounce that come straight in the opposite direction. Those that roll over them will continue straight on. |
| `*` | Splitters | This will split the ball into two, letting them head the opposite direction. |
| `#` | Output | This will output the value of the ball to the console, then destroy it. |

The program ends when there are no balls left.

Don't forget to check out the demo's in the .\Demo folder!

___

.\Demo\add.txt - *Input 2 numbers, and this program will add them together!*
```
      >?v    
 ? >  v     
        -    
   ^+ \ <# 
```

___

.\Demo\duplicate.txt - *Input a number, and this program will multiply it by 2!*
```
      >?v    
 0 >  v     
   +    -    
   ^+ \ <# 
```

___

.\Demo\helloworld.txt - *Prints a Hello World message for you*
```
      >8v                
 8 >  v                   
        - #              
   ^+ \ <+*               
    #v++++*---#          
    **+++     */\/\/\/\  
    #                    
                         
      >Gv                
 G >  v                  
        -                
   ^+ \ <#    \/\/\/\/ # 
                  #+++** 
                  *--- < 
         #--------<      
```
