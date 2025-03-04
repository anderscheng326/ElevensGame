/*
UML
Class: Card
 Fields:
    -rank:Rank
    -suit:Suit
    -faceUp:bool

 Properties:
    +Rank:Rank
    +Suit:Suit
    +FaceUp:bool

 Methods:
    +FlipOver():void

 Constructor:
    Card(){rank:Rank, suit:Suit}
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Card
{
    //Fields, example: Rank rank;
    //check the help documentation for the fields
    Rank rank;
    Suit suit;
    bool faceUp;

    //Card Constructor
    public Card(Rank rank, Suit suit)
    {
        this.suit = suit;
        this.rank = rank;
        this.faceUp = false;
    }
  
    //Define properties for all above fields
    //code example: public Suit Suit { get { return suit; } }

    public Rank Rank
    {
        get {return rank;}
    }

    public Suit Suit
    {
        get {return suit;}
    }

    public bool FaceUp
    {
        get {return faceUp;}
    }

    public void FlipOver()
    {
        faceUp = !faceUp;
    }
        
} 