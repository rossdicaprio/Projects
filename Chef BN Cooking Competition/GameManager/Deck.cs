using System;
using System.Collections.Generic;

namespace Model
{
    /// <summary>
    /// Represents the shared deck in the current game
    /// </summary>
    class Deck
    {
        // The internal structure holding the cards
        private List<Card> cards;

        // The internal structure holding the discarded cards
        private List<Card> discardedCards;

        /// <summary>
        /// The number of cards currently in the deck
        /// </summary>
        public int Size { get { return cards.Count; } }

        /// <summary>
        /// Creates and shuffles a new Deck with 2 of each card
        /// </summary>
        public Deck()
        {
            cards = new List<Card>();
            discardedCards = new List<Card>();

            AddXOfEachCard(2);

            ShuffleDeck();
        }

        /// <summary>
        /// Adds x of each of the different cards to the deck
        /// </summary>
        private void AddXOfEachCard(int x)
        {
            /* for each card type
             *     add X of those cards to 'cards'
             */

            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes and returns the top card of the deck
        /// 
        /// - throws InvalidOperationException if the deck is empty
        /// </summary>
        public Card GetTopOfDeck()
        {
            if (cards.Count == 0)
                throw new InvalidOperationException();

            Card c = cards[cards.Count - 1];
            cards.RemoveAt(cards.Count - 1);
            return c;
        }

        /// <summary>
        /// Adds the specified card to the discard pile
        /// </summary>
        public void AddToDiscardedPile(Card card)
        {
            discardedCards.Add(card);
        }

        /// <summary>
        /// Shuffles the discard pile into the deck
        /// </summary>
        public void ShuffleDiscardIntoDeck()
        {
            foreach (Card c in discardedCards)
                cards.Add(c);

            discardedCards.Clear();
            ShuffleDeck();
        }

        /// <summary>
        /// Shuffles the deck based on the Fisher–Yates shuffle algorithm found here: https://en.wikipedia.org/wiki/Fisher-Yates_shuffle#The_modern_algorithm
        /// </summary>
        private void ShuffleDeck()
        {
            Random rand = new Random();

            for (int i = cards.Count - 1; i > 1; i--)
            {
                int j = rand.Next(i + 1);
                Card temp = cards[j];
                cards[j] = cards[i];
                cards[i] = temp;
            }
        }
    }
}
