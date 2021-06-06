using System;

namespace BlackJack
{
    class Deck
    {
        int[] deck = new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10 ,11,
                                   2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10 ,11,
                                   2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10 ,11,
                                   2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10 ,11};

        Random random = new Random();
        public int[] SuffleCards()
        {
            for (int i = 0; i < deck.Length / 2; i++)
            {
                for (int j = i + random.Next(1, deck.Length); j < deck.Length; j++)
                {
                    int temp = deck[i];
                    deck[i] = deck[j];
                    deck[j] = temp;
                }
            }
            for (int i = 0; i < deck.Length / 2; i++)
            {
                for (int j = i + random.Next(1, deck.Length); j < deck.Length; j++)
                {
                    int temp = deck[i];
                    deck[i] = deck[j];
                    deck[j] = temp;
                }
            }

            return deck;
        }
    }
}
