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
      if (SelectCard.Count == 2) //check for 2 card adding up to 11
      {
         int sum = (int)hand[SelectCard[0]].Rank + (int)hand[SelectCard[1]].Rank;
         if (sum == 11)
         {
            return true;
         }
      }
      if (SelectCard.Count == 3) //check for 3 face cards
      {
        List<Rank> selectedRanks = SelectCard.Select(index => hand[index].Rank).ToList();
        //list of ranks of selected cards

         bool hasJack = selectedRanks.Contains(Rank.Jack);
         bool hasQueen = selectedRanks.Contains(Rank.Queen);
         bool hasKing = selectedRanks.Contains(Rank.King);
         //bools for checking if theres one Jack, Queen, King

         if (hasJack && hasQueen && hasKing)
         {
            return true;
         }
      }
      return false;
   }

   public Card Replace(int index)
   {
      Card newCard = gameDeck.TakeTopCard();
      hand[index] = newCard;
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
      if (gameDeck.Cards.Count == 0) //check if deck is empty
      {
         isGameOver = true; 
         Console.WriteLine("Congratulations! You've Won! No cards left in deck!");
         return true; //game is won
      }

      for(int i = 0; i < hand.Count; i++) //check for valid 2 card moves
      {
         for (int j = i + 1; j < hand.Count; j++)
         {
            if ((int)hand[i].Rank + (int)hand[j].Rank == 11) //if any cards add up to 11
            {
               return false; //valid move exists, game not over
            }
         }
      } 

      for(int i = 0; i < hand.Count; i++) //check for valid 3 card moves
      {
         for (int j = i + 1; j < hand.Count; j++)
         {
            for (int k = j + 1; k < hand.Count; k++)
            {
               bool hasJack = hand[i].Rank == Rank.Jack || hand[j].Rank == Rank.Jack || hand[k].Rank == Rank.Jack;
               bool hasQueen = hand[i].Rank == Rank.Queen || hand[j].Rank == Rank.Queen || hand[k].Rank == Rank.Queen;
               bool hasKing = hand[i].Rank == Rank.King || hand[j].Rank == Rank.King || hand[k].Rank == Rank.King;
               
               if (hasJack && hasQueen && hasKing) //if has all 3 faces 
               {
                  return false; //valid move exists, game not over
               }
            }
         }
      } 
      isGameOver=true; 
      Console.WriteLine("Game Over! No valid moves remain.");
      return true; //game is lost
   }


}

