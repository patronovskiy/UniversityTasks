using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackJack
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //масти 
        internal enum Suit
        {
            hearts,
            clubs,
            spades,
            diamonds
        }

        //значения карт 2-10, валет, дама, король, туз
        internal enum Cost
        {
            Two = 0,
            Three = 1,
            Four = 2,
            Five = 3,
            Six = 4,
            Seven = 5,
            Eight = 6,
            Nine = 7,
            Ten = 8,
            Jack = 9,
            Queen = 10,
            King = 11,
            Ace = 12
        }

        //класс карты
        internal class Card
        {
            int cardValue;
            Suit cardSuit;

            int rest;

            string image;
            Cost cost;

            internal Card(int value, Suit suit, int decks)
            {
                this.cardValue = value;
                this.cardSuit = suit;
                this.rest = decks;
            }

            internal Card(int value, Suit suit, int decks, Cost cost)
            {
                this.cardValue = value;
                this.cardSuit = suit;
                this.rest = decks;
                this.cost = cost;
            }

            public override string ToString()
            {
                return "Card: " + this.cardValue + " " + this.cardSuit + ", " + this.cost + ", rest: " + this.rest;
            }
        }

        //класс колоды карт
        internal class Deck
        {
            Card[] cards;

            public Deck(int decksQuantity)
            {
                cards = new Card[52];
                int currentCard = 0;
                for (int i = 0; i < 9; i++)
                {
                    cards[currentCard] = new Card(i + 2, Suit.clubs, decksQuantity, (Cost)i);
                    currentCard++;

                    cards[currentCard] = new Card(i + 2, Suit.diamonds, decksQuantity, (Cost)i);
                    currentCard++;

                    cards[currentCard] = new Card(i + 2, Suit.hearts, decksQuantity, (Cost)i);
                    currentCard++;

                    cards[currentCard] = new Card(i + 2, Suit.spades, decksQuantity, (Cost)i);
                    currentCard++;
                }

                for (int i = 9; i < 12; i++)
                {

                    cards[currentCard] = new Card(10, Suit.clubs, decksQuantity, (Cost)i);
                    currentCard++;

                    cards[currentCard] = new Card(10, Suit.diamonds, decksQuantity, (Cost)i);
                    currentCard++;

                    cards[currentCard] = new Card(10, Suit.hearts, decksQuantity, (Cost)i);
                    currentCard++;

                    cards[currentCard] = new Card(10, Suit.spades, decksQuantity, (Cost)i);
                    currentCard++;
                }

                for (int i = 0; i < 1; i++)
                {
                    cards[currentCard] = new Card(11, Suit.clubs, decksQuantity, Cost.Ace);
                    currentCard++;

                    cards[currentCard] = new Card(11, Suit.diamonds, decksQuantity, Cost.Ace);
                    currentCard++;

                    cards[currentCard] = new Card(11, Suit.hearts, decksQuantity, Cost.Ace);
                    currentCard++;

                    cards[currentCard] = new Card(11, Suit.spades, decksQuantity, Cost.Ace);
                    currentCard++;
                }
            }

            public void Show()
            {
                foreach (Card card in this.cards)
                {
                    Console.WriteLine(card.ToString());
                }
            }

        }

        //класс бокса ("руки")
        internal class Box
        {
            Card[] boxCards = new Card[11];
            int points = 0;
            int cardsQuantity = 0;

            internal void addCard(Card card)
            {
                boxCards[cardsQuantity] = card;
                if (card.)
            }
        }
    }

    
}
