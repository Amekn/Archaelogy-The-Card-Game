using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Assignment_2___PreAlpha
{
    internal class Person : Player
    {
        public Person(Deck deck, int playervalue, int cardSold, Match match) : base(deck, playervalue, cardSold, match)
        {
            
        }


        
        public override void ThiefAction(int MouseX, int MouseY)
        {
            if (match.CheckThief())//If this return true, it means there are cards available from card player to be stealed.
            {
                int stolenplayer = -1;
                int stolencard = -1;
                for (int i = 0; i < match.Players.Length; i++)
                {
                    if (i != match.PlayerIndex)
                    {
                        if (match.Players[i].PlayerDeck.IsMouseOn(MouseX, MouseY))
                        {
                            Random random = new Random();
                            stolencard = random.Next(match.Players[i].PlayerDeck.CardList.Count);
                            match.SelectedCard = match.Players[i].PlayerDeck.CardList[stolencard];
                            stolenplayer = i;
                        }
                    }

                    if (stolenplayer >= 0 && stolencard >= 0)
                    //If a stoleplayer exist, and a stolencard exist.
                    {
                        match.SelectedCard.FlipState = true;
                        match.Players[match.PlayerIndex].PlayerDeck.AddCard(match.SelectedCard);
                        match.Players[match.PlayerIndex].PlayerDeck.ArrangeByTypeQuickSort();
                        match.Players[stolenplayer].PlayerDeck.CardList.RemoveAt(stolencard);
                        match.Players[stolenplayer].PlayerDeck.ArrangeByTypeQuickSort();
                        match.ThiefPulled = false;
                        match.SelectedCard = null;
                        match.DigSite.CardList.RemoveAt(0);
                        match.FirstPhase = false;
                        match.SecondPhase = true;
                        break;
                    }
                }
            }
            else//If there are no card available to be stealed, skip this thief.
            {
                match.ThiefPulled = false;
                match.SelectedCard = null;
                match.DigSite.CardList.RemoveAt(0);
                match.FirstPhase = false;
                match.SecondPhase = true;
            }
        }

        public override void SandStormAction(int MouseX, int MouseY)
        {
            int losscard = -1;
            bool terminate;
            if (match.Players[match.PlayerIndex].PlayerDeck.CardList.Count > match.OriginalCardNumberByHalf[match.PlayerIndex])
            {
                for (int j = match.Players[match.PlayerIndex].PlayerDeck.CardList.Count - 1; j >= 0; j--)
                {
                    if (match.Players[match.PlayerIndex].PlayerDeck.CardList[j].IsMouseOn(MouseX, MouseY))
                    {
                        match.SelectedCard = match.Players[match.PlayerIndex].PlayerDeck.CardList[j];
                        losscard = j;
                        break;
                    }
                }
            }

            if (losscard >= 0)
            {
                match.Players[match.PlayerIndex].PlayerDeck.CardList.RemoveAt(losscard);
                match.SelectedCard.FlipState = true;
                match.MarketPlace.AddCard(match.SelectedCard);
                match.Players[match.PlayerIndex].PlayerDeck.ArrangeByTypeQuickSort();
                match.MarketPlace.ArrangeByTypeQuickSort();
                match.SelectedCard = null;
            }

            if (match.Players[match.PlayerIndex].PlayerDeck.CardList.Count <= match.OriginalCardNumberByHalf[match.PlayerIndex])
            {
                match.SandStormEnd[match.PlayerIndex] = true;
                match.Players[match.PlayerIndex].PlayerDeck.FlipState = false;
                match.PlayerIndex = match.TurnRotation();
            }

            if (terminate = match.CheckSandStorm())
            {
                match.DigSite.CardList.RemoveAt(0);
                match.SandStormPulled = false;
                match.FirstPhase = false;
                match.SecondPhase = true;
            }
        }

        public override void PyramidAction(int X, int Y, Form form)
        {
            bool ClickedOn = false;
            if (match.PyramidSmall.CardList.Count != 0)
            {
                if (match.PyramidSmall.IsMouseOn(X, Y))
                {
                    if (match.PyramidPile.CardList.Count == 1)
                    //If the small treasure pile is click on, with treasure left, and only 1 card selected.
                    {
                        match.Players[match.PlayerIndex].PlayerDeck.RemoveRange(match.PyramidPile.CardList);
                        match.Players[match.PlayerIndex].PlayerDeck.CardList.AddRange(match.PyramidSmall.CardList);
                        match.Players[match.PlayerIndex].PlayerDeck.ArrangeByTypeQuickSort();
                        match.PyramidSmall.CardList.Clear();
                    }
                    ClickedOn = true;
                }         
            }
                
            if (match.PyramidMedium.CardList.Count != 0)
            {
                if (match.PyramidMedium.IsMouseOn(X, Y))
                {
                    if (match.PyramidPile.CardList.Count == 2)
                    //If the medium treasure pile is click on, with treasure left, and only 1 card selected.
                    {
                        match.Players[match.PlayerIndex].PlayerDeck.RemoveRange(match.PyramidPile.CardList);
                        match.Players[match.PlayerIndex].PlayerDeck.CardList.AddRange(match.PyramidMedium.CardList);
                        match.Players[match.PlayerIndex].PlayerDeck.ArrangeByTypeQuickSort();
                        match.PyramidMedium.CardList.Clear();                    
                    }
                    ClickedOn = true;
                }               
            }
                
            if (match.PyramidLarge.CardList.Count != 0)
            {
                if (match.PyramidLarge.IsMouseOn(X, Y))
                {
                    if (match.PyramidPile.CardList.Count == 3)
                    //If the large treasure pile is click on, with treasure left, and only 1 card selected.
                    {
                        match.Players[match.PlayerIndex].PlayerDeck.RemoveRange(match.PyramidPile.CardList);
                        match.Players[match.PlayerIndex].PlayerDeck.CardList.AddRange(match.PyramidLarge.CardList);
                        match.Players[match.PlayerIndex].PlayerDeck.ArrangeByTypeQuickSort();
                        match.PyramidLarge.CardList.Clear();                 
                    }
                    ClickedOn = true;
                }    
            }      

            if (ClickedOn)
            {
                match.Cancel(form);
            }
        }
    }
}
