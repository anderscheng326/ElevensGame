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

using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ElevensGame
{

//fields
List<Card> hand = new List<Card>();
bool isGameOver = false;

//properties
public List<Card> Hand
{
   get {return hand;}
}

public List<int> SelectCard 
{
   get; set;
}

public ElevensGame(List<Card> hand)
{
   this.hand = hand;
   this.isGameOver = false;
}

public List<Card> Deal()
{
   //to be implemented
   Deck deck = new Deck();
   deck.Shuffle();
   for(int x = 0; x<9; x++)
   {
      hand[x] = deck.TakeTopCard();
   }
   return hand;
}

public void PlayerMove()
{
   //to be implemented
}

public bool SystemCheck()
{
   //to be implemented
   return true;
}

public Card Replace()
{
   //to be implemented
   return newcard; //placeholder
}

public void Reset()
{
   //to be implemented
}

public bool CheckWin()
{
   //to be implemented
   return isGameOver;
}


}

