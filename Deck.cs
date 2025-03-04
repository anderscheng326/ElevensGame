/*
UML
Class: Deck
 Fields:
    -cards:List<Card>

 Properties:
    +Cards:List<Card>

 Methods:
    +TakeTopCard():Card
    +Shuffle():void
    +Cut(Index):int

 Constructor:
    +Deck()
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Deck
{
    List<Card> cards = new List<Card>();

    //Deck Constructor
    public Deck()
    {
        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
        {
            foreach (Rank rank in Enum.GetValues(typeof(Rank)))
            {
                //create a new card and add it to the deck
                cards.Add(new Card(rank, suit));
            }
        }
    }

    //Implement a property to get Cards
    public List<Card> Cards
    {
        get {return cards;}
    }

    //Takes top card from deck (if deck is not empty, otherwise return null)
    public Card TakeTopCard()
    {
        //implementation
        if (cards.Count > 0)
        {
            Card topCard = cards[0];
            cards.RemoveAt(0);
            return topCard;
        }
        return null;
    }

    //Shuffle Method
    //iterate through list
    //swapping current with random
    public void Shuffle()
    {
        Random rnd = new Random();
        int n = cards.Count;
        for(int i = 0; i < n; i++)
        {
            int k = rnd.Next(n);
            Card val = cards[k];
            cards[k] = cards[i];
            cards[i] = val;
        }
    }

    //Cut method
    //splitting deck in 2 at index
    //top half on bottom
    //bottom half on top
    public void Cut(int index)
    {
        if (index > 0 && index < cards.Count)
        {
            List<Card> top = cards.GetRange(0, index);
            List<Card> bot = cards.GetRange(index, cards.Count -index);
            cards.Clear();
            cards.AddRange(bot);
            cards.AddRange(top);
            
        }
    }
}

