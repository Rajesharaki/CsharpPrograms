using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectOrientedPrograms.DeckOfCards
{
    class DeckOfCard
    {
        public DeckOfCard()
        {
            //Play();
        }
        public string [] Play()
        {
            string[] suits = { "C", "D", "H", "S" };//C-->Clubs,D-->Diamonds,H-->Hearts,S-->Spades
            string[] Rank = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            string[] Deck = new string[52];
            int k = 0, l = 0;
            ///Add all card into Deck . each rank have 4 suits like (2C,2D,2H,2S  So on....)
            for (int i = 0; i < Deck.Length; i++)
            {
                int j = 0;
                while (j < 4 && l < 4)
                {
                    Deck[i++] = Rank[k] + suits[l++];
                    j++;
                }
                i--;
                k++;
                l = 0;
            }
            return Deck;
            //CardShuffle(Deck); CardShuffle Methid call
        }
        //Shuffle all 52 cards
        public string[] CardShuffle(string[] Deck)
        {
            Random randomNumber = new Random();
            for (int i = 0; i < Deck.Length; i++)
            {
                int Index = randomNumber.Next(52);
                String temp = Deck[i];
                Deck[i] = Deck[Index];
                Deck[Index] = temp;
            }
            return Deck;
            // DistrubuteCard(Deck);  Distbute method call
        }
        //Card Distrubution
       public  void DistrubuteCard(String[] Deck)
        {
            string[,] CardDistubute = new string[4, 9];//4 Players and Distrubute 9 card for each player
            /// Distrubute 9 Card for each Player  
            for (int i = 0, k = 0; i < CardDistubute.GetLength(0); i++)
            {
                for (int j = 0; j < CardDistubute.GetLength(1); j++)
                {
                    CardDistubute[i, j] = Deck[k++];
                }
            }
            ///Display Players card
            int Player = 1;
            for (int i = 0, k = 0; i < CardDistubute.GetLength(0); i++)
            {
                Console.WriteLine("Player" + (Player++));
                for (int j = 0; j < CardDistubute.GetLength(1); j++)
                {
                    Console.Write(CardDistubute[i, j]);
                    if (j < CardDistubute.GetLength(1) - 1)
                    {
                        Console.Write(" , ");
                    }
                }
                Console.WriteLine();
                Console.WriteLine("______________________________________________________________________");
            }
        }
    }
}
