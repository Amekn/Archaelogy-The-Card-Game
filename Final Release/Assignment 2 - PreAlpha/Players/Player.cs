using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Assignment_2___PreAlpha
{
    public abstract class Player
    {
        protected Deck playerDeck;

        protected int playervalue;

        protected int cardsold;

        protected Match match;

        public Player(Deck playerDeck, int playervalue, int cardsold, Match match)
        {
            this.playerDeck = playerDeck;
            this.playervalue = playervalue;
            this.cardsold = cardsold;
            this.match = match;
        }

        public Deck PlayerDeck
        { get { return playerDeck; } }

        public int Value
        {
            get { return playervalue; }
            set { this.playervalue = value; }
        }

        public int CardSold
        {
            get { return cardsold; }
            set { cardsold = value; }
        }


        /// <summary>
        /// The function below determine the branch occurs in phase 1 where a player pulls a card from digsite.
        /// Depending on the type of the card pulled, initialisation for each action is different.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void PullCard(Form form)
        {
            match.SelectedCard = match.DigSite.CardList[0];
            if (match.SelectedCard is TreasureCard)
            {
                TreasureAction();
            }
            else if (match.SelectedCard is ThiefCard)
            {
                match.ThiefPile.AddCard(match.SelectedCard);
                match.ThiefPile.ArrangeByTypeQuickSort();
                match.SelectedCard.FlipState = true;
                match.SelectedCard = null;
                match.ThiefPulled = true;
            }
            else if (match.SelectedCard is SandstormCard)
            {
                match.SandStormPile.AddCard(match.SelectedCard);
                match.SandStormPile.ArrangeByTypeQuickSort();
                match.SelectedCard.FlipState = true;
                match.SelectedCard = null;
                match.OriginalCardNumberByHalf = new int[match.Players.Length];
                match.SandStormEnd = new bool[match.Players.Length];
                for (int i = 0; i < match.SandStormEnd.Length; i++)
                {
                    match.SandStormEnd[i] = false;
                }
                for (int i = 0; i < match.Players.Length; i++)
                {
                    match.OriginalCardNumberByHalf[i] = match.Players[i].PlayerDeck.CardList.Count / 2;
                }
                match.SandStormPulled = true;
            }
        }

        /// <summary>
        /// Action performed when a treasure card is pulled.
        /// </summary>
        public virtual void TreasureAction()
        {
            match.SelectedCard.FlipState = true;
            match.Players[match.PlayerIndex].PlayerDeck.AddCard(match.SelectedCard);
            match.Players[match.PlayerIndex].PlayerDeck.ArrangeByTypeQuickSort();
            match.DigSite.CardList.RemoveAt(0);
            match.SelectedCard = null;
            match.FirstPhase = false;
            match.SecondPhase = true;
        }

        /// <summary>
        /// Performe the action when a thief card is pulled.
        /// Method tested
        /// </summary>
        public abstract void ThiefAction(int MouseX, int MouseY);

        /// <summary>
        /// Performe the action when a sandstorm card is pulled.
        /// Tested
        /// </summary>
        /// <param name="MouseX"></param>
        /// <param name="MouseY"></param>
        public abstract void SandStormAction(int MouseX, int MouseY);

        /// <summary>
        /// Determines the action after a pile of pyramid card clicked on.
        /// This function below is called every time in second phase
        /// until all pyramid piles has been pulled.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public abstract void PyramidAction(int X, int Y, Form form);

        /// <summary>
        /// Return the name of the type of players only.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}
