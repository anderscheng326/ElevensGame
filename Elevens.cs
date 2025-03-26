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

private static Deck gameDeck = new Deck(); //static shared deck

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
   gameDeck.Shuffle();
   for(int x = 0; x<9; x++)
   {
      hand[x] = gameDeck.TakeTopCard();
   }
   return hand;
}

public void PlayerMove()
{
   Console.WriteLine("Select cards by index separated by space: ");
   string input = Console.ReadLine();
   SelectCard = input.Split(' ').Select(int.Parse).ToList();

   if (SelectCard.Count > 0 && SystemCheck())
   {
      foreach (int index in SelectCard)
      {
         Replace(index);
      }
      Console.WriteLine("Match made!");
   }
   else
   {
      Console.WriteLine("Invalid Move. Try again.");
   }
}

public bool SystemCheck()
{
   int sum = 0;
   foreach (int index in SelectCard)
   {
      sum += (int)hand[index].Rank;
   }
   return (sum == 11 || sum == 36 );  //11 for pairs, 36 for triple face for now
}

public Card Replace(int index)
{
   Card newCard = gameDeck.TakeTopCard();
   return newCard;
}

public void Reset()
{
   gameDeck = new Deck();
   gameDeck.Shuffle();

   hand.Clear();
   for(int x = 0; x<9; x++)
   {
      hand[x] = gameDeck.TakeTopCard();
   }
   
   isGameOver = false;
   SelectCard = new List<int>();
}

public bool CheckWin()
{
   //to be implemented
   return isGameOver;
}


}

