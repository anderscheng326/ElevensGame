/*
UML
Class: ElevensGame
 Fields:
    -hand:List<Card>
    -isGameOver:bool
   

 Properties:
    +Hand:List<Card>
    +SelectCard:List<int> //for list of index for selecting which cards


 Methods:
    +Deal():List<Card>   //deals the card to the hand
    +PlayerMove():void  //player selects cards 
    +SystemCheck():bool  //system checks the selected cards 
    +Replace():Card     //replaces card based on system check
    +Reset():void        //reset the game 
    +CheckWin():bool        //system check for if game is over 

 Constructor:
   +Elevens(hand:List<Card>):void
*/

