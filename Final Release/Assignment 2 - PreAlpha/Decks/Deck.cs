using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2___PreAlpha
{
    /// <summary>
    /// A class allows for easy management of a pile of card as a deck.
    /// With property and method that works on cards within as a whole.
    /// </summary>
    public class Deck
    {
        private int xCor;

        private int yCor;

        private List<Card> cardList;

        private string orientation;

        public Deck(int xCor, int yCor)
        {
            cardList = new List<Card>();
            this.xCor = xCor;
            this.yCor = yCor;
            this.orientation = "Vertical";//Default to assume the card goes vertical.
        }

        /// <summary>
        /// This gives you access to the X coodinates of the deck of cards.
        /// The X coordinate represent the top left cornor of the deck.
        /// </summary>
        public int X
        { get { return xCor; } }
        
        /// <summary>
        /// This gives you access to the Y coodinates of the deck of cards.
        /// The Y coordinate represent the top left cornor of the deck.
        /// </summary>
        public int Y
        { get { return yCor; } }

        /// <summary>
        /// This gives you access to the cards in the cardlist of this deck.
        /// Read & Write enabled.
        /// </summary>
        public List<Card> CardList
        {
            get { return cardList; }
            set { cardList = value; }
        }

        /// <summary>
        /// This property is read & write enabled, it allows you get and set the orientation of what
        /// this deck of cards should be displayed, and arranged.
        /// </summary>
        public string Orientation
        {
            get { return orientation; }
            set
            {
                if (value == "Horizontal" || value == "Vertical")
                {
                    orientation = value;
                }
                else
                {
                    throw new Exception("Orientation must be either vertical or horizontal.");
                }
            }
        }

        /// <summary>
        /// This property is write only, it allows you to set a flipstate for all card in the deck.
        /// </summary>
        public bool FlipState
        {
            set
            {
                foreach (Card c in cardList)
                {
                    c.FlipState = value;
                }
            }
        }
        /// <summary>
        /// A deck must able to add a card
        /// </summary>
        /// <param name="c"></param>
        public void AddCard(Card c)
        {
            cardList.Add(c);
        }

        /// <summary>
        /// A deck must able to remove a card at a particular location. 
        /// </summary>
        /// <param name="index"></param>
        public void RemoveCard(int index)
        {
            cardList.RemoveAt(index);
        }

        /// <summary>
        /// Draw out every card inside of the cardlist of the deck. 
        /// </summary>
        /// <param name="paper"></param>
        public void Draw(Graphics paper)
        {
            foreach (Card c in cardList)
            {
                c.Draw(paper);
            }
        }
        /// <summary>
        /// This provide the deck functionality to remove card from its card list, where the card are contained 
        /// in the parameter throwed in.
        /// </summary>
        /// <param name="listOfCard"></param>
        public void RemoveRange(List<Card> listOfCard)
        {
            List<int> cardtoberemoved = new List<int>();
            //Get the index of the card need to be removed.
            for (int i = 0; i < CardList.Count; i++)
            {
                if (listOfCard.Contains(cardList[i]))
                {
                    cardtoberemoved.Add(i);
                }
            }
            //Remove the card from the list by removing in reverse order.
            //This avoids change the index of other elements that need to be removed).
            for (int i = cardtoberemoved.Count - 1; i >= 0; i--)
            {
                CardList.RemoveAt(cardtoberemoved[i]);
            }
            //The results is a cardlist with the same card removed(reference removed).            
        }

        /// <summary>
        /// A deck must able to suffle all of the card it contains.
        /// The process must be random, thus random class is used.
        /// </summary>
        public void SuffleCard()
        {
            if (cardList.Count == 0 || cardList.Count == 1)
            {
                throw new ArgumentException("Can not suffle deck with only 1 or 0 card.");
            }
            else
            {
                Random random = new Random();
                for (int j = 0; j < random.Next(15); j++)
                {
                    for (int i = 0; i < cardList.Count; i++)
                    {
                        Card c = cardList[i];
                        int index = random.Next(cardList.Count);
                        cardList[i] = cardList[index];
                        cardList[index] = c;
                    }
                }
            }
        }

        /// <summary>
        /// Used to sort out the list of cards.
        /// lgorithm used is copied from the lecture material in week 11 friday lecture on quick sort. 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        private void QuickSort(ref Card[] array, int start, int end)
        {
            if (start < end)
            {
                int l = start;
                int u = end;
                int pivot = (int)Enum.Parse(typeof(AllCardType), array[(l + u) / 2].ToString());
                do
                {
                    while ((int)Enum.Parse(typeof(AllCardType), array[l].ToString()) < pivot) l++;
                    while (pivot < (int)Enum.Parse(typeof(AllCardType), array[u].ToString())) u--;
                    if (l <= u)
                    {
                        Swap(ref array, l++, u--);
                    }
                } while (l <= u);

                QuickSort(ref array, start, u);
                QuickSort(ref array, l, end);
            }
        }

        /// <summary>
        /// Swap the card at two different position.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        private void Swap(ref Card[] array, int p1, int p2)
        {
            Card c = array[p1];
            array[p1] = array[p2];
            array[p2] = c;
            //Swap completed.
        }

        /// <summary>
        /// Rearrange the card using quick sort algorithms.
        /// Arrays are used in this algorithm below
        /// </summary>
        public void ArrangeByTypeQuickSort()
        {
            Card[] Arranged = new Card[CardList.Count];
            for(int i = 0; i < Arranged.Length; i++)
            {
                Arranged[i] = CardList[i];
            }
            QuickSort(ref Arranged, 0, Arranged.Length - 1);
            CardList.Clear();
            CardList.AddRange(Arranged);
            if (Orientation == "Vertical")
            {
                for (int i = 0; i < cardList.Count; i++)
                {
                    cardList[i].Move(X, Y + 20 * i);
                }
            }
            else if (Orientation == "Horizontal")
            {
                for (int i = 0; i < cardList.Count; i++)
                {
                    cardList[i].Move(X + 20 * i, Y);
                }
            }
        }

        /// <summary>
        /// Rearrange the card within the deck with regards to similar type
        /// Named radix sort in a sence that it doesn't evolve comparasion of cards. Each list is similar to a digit in decimal system,
        /// where the correct card with the 'digit' is put into the list, and laterwards all of the list combines in a particular order
        /// into arranged list.
        /// However it tooks a lots of space due to many list created.
        /// The reason I don't used anymore in my code is to reduce the amount of memory used. Otherwise in term of time complexity, 
        /// radix would be more efficient here.(However I used list in the radix sort, as you don't know how many card exist 
        /// for each time. While arrays are used in quick sort, so might be in 
        /// practical the quick sort above is more efficient).
        /// </summary>
        public void ArrangeByTypeRadixSort()
        {
            List<Card> Arranged = new List<Card>();
            List<Card> Mask = new List<Card>();
            List<Card> AllMaps = new List<Card>();
            List<Card> BrokenCups = new List<Card>();
            List<Card> Talismans = new List<Card>();
            List<Card> Coins = new List<Card>();
            List<Card> ParchmentScraps = new List<Card>();
            List<Card> PotShards = new List<Card>();
            List<Card> ThiefCards = new List<Card>();
            List<Card> SandstormCards = new List<Card>();

            foreach(Card c in cardList)
            {
                switch (c.ToString())
                {
                    case "Pharaoh_sMask":
                        Mask.Add(c);
                        break;
                    case "Maps":
                        AllMaps.Add(c);
                        break;
                    case "BrokenCup":
                        BrokenCups.Add(c);
                        break;
                    case "Talisman":
                        BrokenCups.Add(c);
                        break;
                    case "Coin":
                        Coins.Add(c);
                        break;
                    case "ParchmentScrap":
                        ParchmentScraps.Add(c);
                        break;
                    case "PotShard":
                        PotShards.Add(c);
                        break;
                    case "ThiefCard":
                        ThiefCards.Add(c);
                        break;
                    case "SandstormCard":
                        SandstormCards.Add(c);
                        break;
                    default:
                        throw new Exception("Invalid cards exit in the list.");
                }
            }
            Arranged.AddRange(Mask);
            Arranged.AddRange(AllMaps);
            Arranged.AddRange(Talismans);
            Arranged.AddRange(BrokenCups);
            Arranged.AddRange(Coins);
            Arranged.AddRange(ParchmentScraps);
            Arranged.AddRange(PotShards);
            Arranged.AddRange(ThiefCards);
            Arranged.AddRange(SandstormCards);
            cardList = Arranged;

            if (Orientation == "Vertical")
            {
                for (int i = 0; i < cardList.Count; i++)
                {
                    cardList[i].Move(X, Y + 20 * i);
                }
            }
            else if (Orientation == "Horizontal")
            {
                for (int i = 0; i < cardList.Count; i++)
                {
                    cardList[i].Move(X + 20 * i, Y);
                }
            }
        }

        /// <summary>
        /// Check if the mouse cliked on anywhere above the deck of cards.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool IsMouseOn(int x, int y)
        {
            int deckHeight = 0;
            int deckWidth = 0;

            if (Orientation == "Vertical")
            {
                if (cardList.Count != 0)
                {
                    deckHeight = cardList[cardList.Count - 1].Y + Card.height;
                }
                if (this.xCor <= x && x < this.xCor + Card.width
                    && this.yCor <= y && y < this.yCor + deckHeight)
                    return true;
                else
                    return false;
            }
            else if (Orientation == "Horizontal")
            {
                if (cardList.Count != 0)
                {
                    deckWidth = cardList[cardList.Count - 1].Y - Card.width;
                }
                if (this.xCor <= x && x < this.xCor - deckWidth
                    && this.yCor <= y && y < this.yCor + Card.height)
                    return true;
                else
                    return false;
            }
            throw new Exception("Orientation is not vertical neither horizontal!.");
        }
        
        /// <summary>
        /// Returns the trading value of all card within a deck of cards.
        /// </summary>
        public int TradeValue
        {
            get
            {
                int value = 0;
                foreach (Card c in cardList)
                {
                    if (c is TreasureCard)
                    {
                        value += TreasureCard.TreasureValueArray[(int)Enum.Parse(typeof(AllCardType), c.ToString())];                       
                    }
                }
                return value;
            }
        }

        /// <summary>
        /// Overrided to string method, return inefo of every card stored in the cardlist.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string allcardinfo = "";
            for (int i = 0; i < cardList.Count; i++)
            {
                allcardinfo += $"{cardList[i].ToString()}, index: {i}. \n\r";
            }
            return allcardinfo;
        }

        public string SaveToCSV()
        {
            string file = "";
            file += $"{xCor},{yCor}\n";
            foreach (Card c in CardList)
            {
                file += c.SaveToCSV() + "\n";
            }
            return file;
        }
    }
}
