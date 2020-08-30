using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Model
{
    /// <summary>
    /// Represents one of the two players in the game
    /// </summary>
    public abstract class Player
    {
        /// <summary>
        /// The cards in this player's hand
        /// </summary>
        public List<Card> Hand { get; private set; }

        /// <summary>
        /// The amount of flavor points this player has
        /// </summary>
        public int Points { get; private set; }

        /// <summary>
        /// The selected card in the player's hand
        /// </summary>
        public Card Selection { get; set; }

        /// <summary>
        /// Constructs a new player
        /// </summary>
        public Player()
        {
            Hand = new List<Card>();
            Points = 0;
            Selection = null;
        }

        /// <summary>
        /// This player draws a card from the inputed deck
        /// </summary>
        public void DrawCard(Deck deck)
        {
            if (deck.Size == 0)
                deck.ShuffleDiscardIntoDeck();

            Hand.Add(deck.GetTopOfDeck());
        }

        /// <summary>
        /// Increases this player's points by the specified value and
        /// reports whether they have 30 or more points
        /// </summary>
        public bool IncreasePoints(int i)
        {
            Points += i;
            return Points >= 30;
        }

        public abstract void SelectCard();
    }

    public class ComputerPlayer : Player
    {
        // The difficulty of the A.I.
        private int difficulty;

        /// <summary>
        /// Creates a new computer player with the specified difficulty
        /// </summary>
        public ComputerPlayer(int _difficulty) : base()
        {
            if (difficulty < 0 || difficulty > 3)
            {
                Debug.WriteLine("Invalid difficulty! Picking easiest difficulty instead.");
                difficulty = 0;
            }
            else
                difficulty = _difficulty;
        }

        /// <summary>
        /// Selects a card based on the difficulty of this player
        /// </summary>
        public override void SelectCard()
        {
            if (difficulty == 0)
                EasiestCardSelect();
            else if (difficulty == 1)
                EasyCardSelect();
            else if (difficulty == 2)
                MediumCardSelect();
            else if (difficulty == 3)
                HardCardSelect();
        }

        /// <summary>
        /// Selects the first card in the computer's hand
        /// </summary>
        private void EasiestCardSelect()
        {
            Selection = Hand[0];
        }

        /// <summary>
        /// Selects the card with the highest point value
        /// </summary>
        private void EasyCardSelect()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Selects a random combo if possible
        /// </summary>
        private void MediumCardSelect()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Selects highest point combo if possible
        /// </summary>
        private void HardCardSelect()
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// FINISH
    /// </summary>
    public class HumanPlayer : Player
    {
        /// <summary>
        /// FINISH
        /// </summary>
        public HumanPlayer() : base()
        {
            throw new NotImplementedException();
        }

        public override void SelectCard()
        {
            throw new NotImplementedException();
        }
    }
}
