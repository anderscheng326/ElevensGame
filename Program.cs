using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Elevens Card Game!");

        List<Card> initialHand = new List<Card>(new Card[9]); // intizialize game with card capacity of 9
        ElevensGame game = new ElevensGame(initialHand);

        Console.WriteLine("Dealing cards...");
        game.Deal(); //start game by dealing intial hand 
        Console.WriteLine("Your current hand:");
        DisplayHand(game.Hand); //display hand (static method implemented at end)

        while (!game.CheckWin())  //main gameplay loop - playermove, displayhand, checkwin
        {
            Console.WriteLine("\nIt's your turn to play.");
            game.PlayerMove();

            Console.WriteLine("Your updated hand:");
            DisplayHand(game.Hand);

            if (game.CheckWin())
            {
                break;
            }
        }

        Console.WriteLine("Thank you for playing Elevens!");
    }

    static void DisplayHand(List<Card> hand)  //display hand method
    {
        for (int i = 0; i < hand.Count; i++)
        {
            string rank = hand[i].Rank.ToString();
            string suit = hand[i].Suit.ToString();
            Console.WriteLine($"[{i}] {rank} of {suit}");
        }
    }
}