using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace deck_of_cards
{
    class Program
    {
        static void Main(string[] args)
        {
            // Generate a randomized deck of card.
            // This is a ineffective way of doing it.
            // A better way would be to use a shuffling function
            // to shuffle an array.
            var card_deck = new string[52];
            var random = new Random();
            var index = 0;
            while (index < 52)
            {
                var suit = random.Next(0,4);
                var value = random.Next(1,14);
                var generated_card = "";

                switch (suit)
                {
                    case 0:
                        generated_card += "C";
                        break;
                    case 1:
                        generated_card += "D";
                        break;
                    case 2:
                        generated_card += "H";
                        break;
                    case 3:
                        generated_card += "S";
                        break;
                }

                switch (value)
                {
                    case 10:
                        generated_card += "T";
                        break;
                    case 11:
                        generated_card += "J";
                        break;
                    case 12:
                        generated_card += "Q";
                        break;
                    case 13:
                        generated_card += "K";
                        break;
                    default:
                        generated_card += value.ToString();
                        break;
                }

                // Checks if card is in deck.
                var no_card_in_deck = true;
                foreach(string card in card_deck)
                {
                    if(card == generated_card)
                    {
                        no_card_in_deck = false;
                        break;
                    }
                }
                // Adds generated card to deck.
                if (no_card_in_deck)
                {
                    card_deck[index++] = generated_card;
                }
            }
            // Writes out randomized card deck.
            foreach (string card in card_deck)
            {
                Console.WriteLine(card);
            }
        }
    }
}
