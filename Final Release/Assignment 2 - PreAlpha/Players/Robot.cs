using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text; 
using System.Threading.Tasks;

namespace Assignment_2___PreAlpha
{
    internal class Robot : Player
    {
        public Robot(Deck deck, int playervalue, int cardSold, Match match) : base(deck, playervalue, cardSold, match)
        {
            
        }

        /// <summary>
        /// Return a index of the card will be stolen from another player.
        /// In robot the first value is use to represent the index of the stolen player.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public override void ThiefAction(int StolenPlayer, int MouseY)
        {
            Random r = new Random();
            Player p = match.Players[StolenPlayer];
            int cardindex = r.Next(p.PlayerDeck.CardList.Count);
            Card c = p.PlayerDeck.CardList[cardindex];
            c.FlipState = true;
            this.PlayerDeck.AddCard(c);
            this.PlayerDeck.ArrangeByTypeQuickSort();
            p.PlayerDeck.CardList.RemoveAt(cardindex);
            p.PlayerDeck.ArrangeByTypeQuickSort();
        }

        /// <summary>
        /// Loss 1 card from the index altomatically, and move the card to the deck(marketplace), throw in.
        /// </summary>
        public override void SandStormAction(int MouseX, int MouseY)
        {
            Random r = new Random();
            int cardindex = r.Next(this.PlayerDeck.CardList.Count);
            Card c = this.PlayerDeck.CardList[cardindex];
            this.PlayerDeck.CardList.RemoveAt(cardindex);
            c.FlipState = true;
            match.MarketPlace.AddCard(c);
            this.PlayerDeck.ArrangeByTypeQuickSort();
            match.MarketPlace.ArrangeByTypeQuickSort();
        }

        /// <summary>
        /// The following deals with when a/some map card could be used by a robot.
        /// It will check if the action is valid, and if is valid, move & rearrange the cards.
        /// </summary>
        public override void PyramidAction(int x, int y, Form form)
        {
            if (match.PyramidSmall.CardList.Count != 0)
            {
                if (match.PyramidPile.CardList.Count == 1)
                //If the small treasure pile is click on, with treasure left, and only 1 card selected.
                {
                    match.Players[match.PlayerIndex].PlayerDeck.RemoveRange(match.PyramidPile.CardList);
                    match.Players[match.PlayerIndex].PlayerDeck.CardList.AddRange(match.PyramidSmall.CardList);
                    match.Players[match.PlayerIndex].PlayerDeck.ArrangeByTypeQuickSort();
                    match.PyramidSmall.CardList.Clear();                 
                }
            }

            if (match.PyramidMedium.CardList.Count != 0)
            {
                if (match.PyramidPile.CardList.Count == 2)
                //If the medium treasure pile is click on, with treasure left, and only 1 card selected.
                {
                    match.Players[match.PlayerIndex].PlayerDeck.RemoveRange(match.PyramidPile.CardList);
                    match.Players[match.PlayerIndex].PlayerDeck.CardList.AddRange(match.PyramidMedium.CardList);
                    match.Players[match.PlayerIndex].PlayerDeck.ArrangeByTypeQuickSort();
                    match.PyramidMedium.CardList.Clear();
                }
            }

            if (match.PyramidLarge.CardList.Count != 0)
            {
                if (match.PyramidPile.CardList.Count == 3)
                //If the large treasure pile is click on, with treasure left, and only 1 card selected.
                {
                    match.Players[match.PlayerIndex].PlayerDeck.RemoveRange(match.PyramidPile.CardList);
                    match.Players[match.PlayerIndex].PlayerDeck.CardList.AddRange(match.PyramidLarge.CardList);
                    match.Players[match.PlayerIndex].PlayerDeck.ArrangeByTypeQuickSort();
                    match.PyramidLarge.CardList.Clear();
                }
            }
        }

        /// <summary>
        /// The function find the set of treasures with the most values.
        /// </summary>
        /// <returns>A list containing the most valuable sets</returns>
        public List<Card> FindMostValuableSet()
        {
            int oldsetvalue = 0;
            int newsetvalue = 0;
            List<TreasureCard> OldMostValueableSet = new List<TreasureCard>();
            List<TreasureCard> NewMostValueableSet = new List<TreasureCard>();
            List<TreasureCard> UniqueList = new List<TreasureCard>();
            foreach (TreasureCard c in this.PlayerDeck.CardList)
            {
                bool unique = true;
                foreach (TreasureCard U in UniqueList)
                {
                    if (U.GetType() == c.GetType())
                    {
                        unique = false;
                    }
                }
                if (unique)
                {
                    UniqueList.Add(c);
                }
            }


            int currentcount = 0;
            foreach (TreasureCard U in UniqueList)
            {
                NewMostValueableSet.Clear();
                currentcount = 0;
                foreach (TreasureCard C in this.PlayerDeck.CardList)
                {
                    if (U.GetType() == C.GetType())
                    {
                        NewMostValueableSet.Add(C);
                        currentcount++;
                    }
                }
                //First is to find the quotient(how many maximum set exist).
                int quotient = currentcount / U.SetValueArray.Count();
                //Second is to find any reminder using modulus.
                int reminder = currentcount % U.SetValueArray.Count();
                //Third is to find the total value;
                //quotient will be 0 if the number of treasure card of the same type does not meet a whole maximum set.
                //Reminder also can be used to find the index of the set value, as set value = reminder - 1.
                //If a maximum set is 4, and there are 5 card in hands. 5 % 4 give 1 card left, and the value for 1 card is stored at setvaluearray index 0.
                if (reminder == 0)
                {
                    newsetvalue = quotient * U.SetValueArray[U.SetValueArray.Count() - 1];
                }
                else
                {
                    newsetvalue = quotient * U.SetValueArray[U.SetValueArray.Count() - 1] + U.SetValueArray[reminder - 1];
                }


                if (newsetvalue > oldsetvalue)
                {
                    oldsetvalue = newsetvalue;
                    OldMostValueableSet.AddRange(NewMostValueableSet);
                }
            }
            List<Card> MostValueableSet = new List<Card>();
            //After the nested for loop, the list of card with the highest set value will be stored in the OldMostValueableSet.
            if (OldMostValueableSet.Count <= OldMostValueableSet[0].SetValueArray.Length)
            {
                //if there is only 1 maximum set or less than 1 maximum set, then return it directly.                
                MostValueableSet.AddRange(OldMostValueableSet);
            }
            else
            {
                //This occurs when there are more than 1 maximum set.
                //Required it to be trimmed down, then return.
                for (int i = 0; i < OldMostValueableSet[0].SetValueArray.Length; i++)
                {
                    MostValueableSet.Add(OldMostValueableSet[i]);
                }
            }
            return MostValueableSet;
        }
    }
}
