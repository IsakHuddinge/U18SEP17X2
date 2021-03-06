﻿using System;
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

            // Prompt for user input.
            var prompt = ">";
            var sum_of_cards = 0;
            // Card that is going to be drawn.
            var current_card = 0;
            // Draw cards.
            while (true)
            {
                Console.WriteLine("Draw a card? (Y/n)");
                Console.Write(prompt);
                var user_answer = Console.ReadLine();
                if (user_answer.ToLower() != "y")
                {
                    Console.WriteLine("Ok! You have {0} points", sum_of_cards);
                    break;
                }

                string temp_card = card_deck[current_card++];
                // Add the value of the drawn card to the sum.
                switch (temp_card[1])
                {
                    case 'T':
                    case 'J':
                    case 'Q':
                    case 'K':
                        sum_of_cards += 10;
                        break;
                    default:
                        sum_of_cards += (int) Char.GetNumericValue(temp_card, 1);
                        break;
                }

                // Get the name of the card
                var card_name = "";
                switch (temp_card[1])
                {
                    case '1':
                        card_name += "ace";
                        break;
                    case '2':
                        card_name += "two";
                        break;
                    case '3':
                        card_name += "three";
                        break;
                    case '4':
                        card_name += "four";
                        break;
                    case '5':
                        card_name += "five";
                        break;
                    case '6':
                        card_name += "six";
                        break;
                    case '7':
                        card_name += "seven";
                        break;
                    case '8':
                        card_name += "eight";
                        break;
                    case '9':
                        card_name += "nine";
                        break;
                    case 'T':
                        card_name += "ten";
                        break;
                    case 'J':
                        card_name += "jack";
                        break;
                    case 'Q':
                        card_name += "queen";
                        break;
                    case 'K':
                        card_name += "king";
                        break;
                }
                card_name += " of ";
                switch (temp_card[0])
                {
                    case 'S':
                        card_name += "spades";
                        break;
                    case 'H':
                        card_name += "hearts";
                        break;
                    case 'D':
                        card_name += "diamonds";
                        break;
                    case 'C':
                        card_name += "clubs";
                        break;
                }
                Console.WriteLine("You drew a {0} and you have {1} points", card_name, sum_of_cards);

                if (sum_of_cards == 21)
                {
                    Console.WriteLine("Congrats! You got 21 points!");
                    break;
                }
                else if(sum_of_cards > 21)
                {
                    Console.WriteLine("You lost!");
                    break;
                }
            }

            Console.WriteLine("Press any key to continue. . .");
            Console.ReadKey();
        }
    }
}
