using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Assignment_2___PreAlpha
{
    /// <summary>
    /// A single match could have multiple players exist.
    /// </summary>
    public class Match
    {
        private Player[] players;
        /// <summary>
        /// digSite stores the card pile that's going to be 'digged' out.
        /// </summary>
        private Deck digSite;

        /// <summary>
        /// marketplace stores all the card that belongs to the market.
        /// </summary>
        private Deck marketplace;

        /// <summary>
        /// museum stored all the card that has been sold from the players.
        /// </summary>
        private Deck museum;

        /// <summary>
        /// PyramidSamll stores all the card that belongs to the small pile in pyramid (3 cards).
        /// </summary>
        private Deck pyramidSmall;

        /// <summary>
        /// PyramidSamll stores all the card that belongs to the medium pile in pyramid (5 cards).
        /// </summary>
        private Deck pyramidMedium;

        /// <summary>
        /// PyramidSamll stores all the card that belongs to the large pile in pyramid (7 cards).
        /// </summary>
        private Deck pyramidLarge;

        /// <summary>
        /// Card trade to the player from the market are stored here.
        /// </summary>
        private Deck marketTradePile;

        /// <summary>
        /// Temperarily store the items that might/would be sell to the museum.
        /// </summary>
        private Deck museumPile;

        /// <summary>
        /// Card trade to the market from the player are stored here.
        /// </summary>
        private Deck playerTradePile;

        /// <summary>
        /// Temperarily store the number of maps card used.
        /// </summary>
        private Deck pyramidPile;

        /// <summary>
        /// Where used up sandstorm cards are collected.
        /// </summary>
        private Deck sandStormPile;

        /// <summary>
        /// Where used up thief cards are collected.
        /// </summary>
        private Deck thiefPile;

        /// <summary>
        /// A representation of the pyramid card.
        /// </summary>
        private Card pyramidCard;

        /// <summary>
        /// Current selected card stored here.
        /// </summary>
        private Card selectedCard;

        /// <summary>
        /// Used in sandstorm events to determine when all players discarded.
        /// </summary>
        private bool[] sandStormEnd;

        /// <summary> 
        /// After settings up, first phase is where a player need to dig a card. firstPhase will be set to true.
        /// </summary>
        private bool firstPhase = false;

        /// <summary>
        /// After the first phase, player are alled to trade at marketplace, explore the pyramid, or sell to the museum.
        /// For which the second Phase will be set to true.
        /// /// </summary>
        private bool secondPhase = false;

        /// <summary>
        /// Turn true when thief card is pulled from dig site.
        /// </summary>
        private bool thiefPulled = false;

        /// <summary>
        /// Turn true when sandstorm card is puleed from dig site.
        /// </summary>
        private bool sandStormPulled = false;

        /// <summary>
        /// Used in sandstorm events to store half of the original number of card players hold in hand.
        /// </summary>
        private int[] originalCardNumberByHalf;

        /// <summary>
        /// The index of the player inturn will be store in playerindex.
        /// </summary>
        private int playerindex;

        /// <summary>
        /// A switch use to controll the height ajustment of all deck of card on a table.
        /// </summary>
        private int deckHeightAjustMent = 0;

        /// <summary>
        /// The directory will be used to save a file (save button).
        /// </summary>
        private string saveDirectory = "";

        /// <summary>
        /// Constructor here creates a new match with a new player list initialised.
        /// </summary>
        public Match(int numberofPlayer)
        {
            players = new Player[numberofPlayer];
        }
        /// <summary>
        /// Property allows only read access to who is the players.
        /// </summary>
        public Player[] Players
        {
            get { return players; }
            set { players = value; }
        }

        /// <summary>
        /// The property below return the number of cards each players hold in their deck as a int array.
        /// </summary>
        public int[] PlayerCard
        {
            get
            {
                int[] result = new int[players.Length];
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = players[i].PlayerDeck.CardList.Count;
                }
                return result;
            }
        }

        public Deck DigSite
        {
            get { return digSite; }
            set { digSite = value; }
        }

        public Deck MarketPlace
        {
            get { return marketplace; }
            set { marketplace = value; }
        }

        public Deck Museum
        {
            get { return museum; }
            set { museum = value; }
        }

        public Deck PyramidSmall
        {
            get { return pyramidSmall; }
            set { pyramidSmall = value; }
        }

        public Deck PyramidMedium
        {
            get { return pyramidMedium; }
            set { pyramidMedium = value; }
        }

        public Deck PyramidLarge
        {
            get { return pyramidLarge; }
            set { pyramidLarge = value; }
        }


        public Deck MarketTradePile
        {
            get { return marketTradePile; }
            set { marketTradePile = value; }
        }

        public Deck MuseumPile
        {
            get { return museumPile; }
            set { museumPile = value; }
        }

        public Deck PyramidPile
        {
            get { return pyramidPile; }
            set { pyramidPile = value; }
        }

        public Deck PlayerTradePile
        {
            get { return playerTradePile; }
            set { playerTradePile = value; }
        }

        public Deck SandStormPile
        {
            get { return sandStormPile; }
            set { sandStormPile = value; }
        }

        public Deck ThiefPile
        {
            get { return thiefPile; }
            set { thiefPile = value; }
        }

        public Card PyramidCard
        {
            get { return pyramidCard; }
            set { pyramidCard = value; }
        }

        public Card SelectedCard
        {
            get { return selectedCard; }
            set { selectedCard = value; }
        }

        public bool[] SandStormEnd
        {
            get { return sandStormEnd; }
            set { sandStormEnd = value; }
        }

        public bool FirstPhase
        {
            get { return firstPhase; }
            set { firstPhase = value; }
        }

        public bool SecondPhase
        {
            get { return secondPhase; }
            set { secondPhase = value; }
        }

        public bool ThiefPulled
        {
            get { return thiefPulled; }
            set { thiefPulled = value; }
        }

        public bool SandStormPulled
        {
            get { return sandStormPulled; }
            set { sandStormPulled = value; }
        }

        public int[] OriginalCardNumberByHalf
        {
            get { return originalCardNumberByHalf; }
            set { originalCardNumberByHalf = value; }
        }

        public int PlayerIndex
        {
            get { return playerindex; }
            set { playerindex = value; }
        }

        public int DeckHeightAjustMent
        {
            get { return deckHeightAjustMent; }
            set { deckHeightAjustMent = value; }
        }

        public string SaveDirectory
        {
            get { return saveDirectory; }
            set { saveDirectory = value; }
        }
        /// <summary>
        /// Return the index of the player in the next turn. 
        /// </summary>
        public int TurnRotation()
        {
            if (PlayerIndex >= 0 && Players.Length > 1 && PlayerIndex != Players.Length - 1)
            {
                return PlayerIndex + 1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// See if there are card available to be steal.
        /// </summary>
        /// <returns></returns>
        public bool CheckThief()
        {
            for (int i = 0; i < players.Length; i++)
            {
                if (i != PlayerIndex && players[i].PlayerDeck.CardList.Count != 0)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Check and return if sandstorm has ended (each player has discarded hard of their card).
        /// </summary>
        /// <returns></returns>
        public bool CheckSandStorm()
        {
            foreach (bool S in SandStormEnd)
            {
                if (S is false)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Check when the game end, occurs where player had no more card in their hand and digsite is empty.
        /// </summary>
        /// <param name="playercards"></param>
        /// <returns></returns>
        public bool CheckGameEnd()
        {
            foreach (int g in PlayerCard)
            {
                if (g != 0)
                {
                    return false;
                }
            }
            if (digSite.CardList.Count > 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Check who is the winner at the end of a game, and return the winner index.
        /// </summary>
        /// <returns></returns>
        public int FindWinner()
        {
            if (players.Length < 2 && players != null)
            {
                //First step is to find out the highest score
                int highest = players[0].Value;
                foreach (Player p in players)
                {
                    if (p.Value > highest)
                    {
                        highest = p.Value;
                    }
                }

                //Second step is to check if there are more than 1 highest score.
                int numberOfHighest = 0;
                //Also store the index of those players;
                List<int> highestplayersindex = new List<int>();

                for (int i = 0; i < players.Length; i++)
                {
                    if (players[i].Value == highest)
                    {
                        numberOfHighest++;
                        highestplayersindex.Add(i);
                    }
                }

                //Third step is to branch, decide what do if there are\n't more than 1 highest.
                if (numberOfHighest == 1)//So only 1 player with the highest score.
                {
                    //There would be expected only 1 elements in the integer list 'highestplayersindex' -- the player with the highest score.
                    return highestplayersindex[0];
                }
                else //So more than 1 player with the highest score.
                {
                    int lowestcardsold = players[highestplayersindex[0]].CardSold;
                    int lowestcardsoldplayerindex = highestplayersindex[0];
                    foreach (int i in highestplayersindex)
                    {
                        if (players[highestplayersindex[i]].CardSold < lowestcardsold)
                        {
                            lowestcardsold = players[highestplayersindex[i]].CardSold;
                            lowestcardsoldplayerindex = highestplayersindex[i];//The player index with the lowest number of card sold & highest value of sold artifacts.
                        }
                    }
                    return lowestcardsoldplayerindex;
                }
            }
            else
            {
                throw new Exception("Cannot find winner when no players added.");
            }
        }

        /// <summary>
        /// Button used to evulate if a tride should occur.
        /// If so switch the cards used in trade(from marketplace to player's deck, and from player's deck to marketplace).
        /// </summary>
        /// <param name="form"></param>
        
        public void Trade(Form form)
        {
            if (this.SecondPhase && this.PlayerTradePile != null && this.MarketTradePile != null)
            {
                if (this.PlayerTradePile.CardList.Count == 0)
                {
                    MessageBox.Show("No card in player's trade pile.");
                }
                else if (this.MarketTradePile.CardList.Count == 0)
                {
                    MessageBox.Show("No card in market's trade pile.");
                }
                else if (this.PlayerTradePile.TradeValue >= this.MarketTradePile.TradeValue)
                {
                    //First is to remove the cards being traded from the player and market.
                    this.Players[this.PlayerIndex].PlayerDeck.RemoveRange(this.PlayerTradePile.CardList);
                    this.MarketPlace.RemoveRange(this.MarketTradePile.CardList);

                    //Second is to add those card into player's hand and market.
                    this.Players[this.PlayerIndex].PlayerDeck.CardList.AddRange(this.MarketTradePile.CardList);
                    this.MarketPlace.CardList.AddRange(this.PlayerTradePile.CardList);

                    //Third is to arrange the decks.
                    this.Players[this.PlayerIndex].PlayerDeck.ArrangeByTypeQuickSort();
                    this.MarketPlace.ArrangeByTypeQuickSort();
                }
                else if (Players[PlayerIndex] is Person)
                {
                    MessageBox.Show("Could not trade, trade value does not meet!");
                }
                Cancel(form);
            }
        }


        /// <summary>
        /// Function called, when a player tries to sell.
        /// Check are doen before trade could occur.
        /// Function tested.
        /// </summary>
        /// <param name="form"></param>
        public void Sell(Form form)
        {
            if (this.SecondPhase && this.MuseumPile != null)
            {
                if (this.MuseumPile.CardList.Count == 0)
                {
                    MessageBox.Show("No artifact set to be sold.");
                }
                else
                {
                    this.Players[this.PlayerIndex].PlayerDeck.RemoveRange(this.MuseumPile.CardList);
                    this.Museum.CardList.AddRange(this.MuseumPile.CardList);
                    this.Museum.ArrangeByTypeQuickSort();
                    this.Players[this.PlayerIndex].PlayerDeck.ArrangeByTypeQuickSort();
                    TreasureCard t = (TreasureCard)this.MuseumPile.CardList[this.museumPile.CardList.Count - 1];
                    this.Players[this.PlayerIndex].Value += t.SetValueArray[this.MuseumPile.CardList.Count - 1];
                    this.Players[this.PlayerIndex].CardSold += this.MuseumPile.CardList.Count;
                }
                Cancel(form);
            }
        }


        /// <summary>
        /// Clear the card piles used in second phase.
        /// Used to reset.
        /// </summary>
        /// <param name="form"></param>
        public void Cancel(Form form)
        {
            if (this.SecondPhase)
            {
                this.PlayerTradePile.CardList.Clear();
                this.MarketTradePile.CardList.Clear();
                this.PyramidPile.CardList.Clear();
                this.MuseumPile.CardList.Clear();
                form.Invalidate();
            }
        }

        /// <summary>
        /// This function is used to check if a game reaches its end.
        /// If so the game terminates
        /// else the game continues, and turn rotation occur.
        /// </summary>
        /// <param name="form"></param>
        public void CheckEnd(Form form)
        {
            if (this.SecondPhase)
            {
                this.Players[this.PlayerIndex].PlayerDeck.FlipState = false;
                this.PlayerIndex = this.TurnRotation();
                bool gameEnd = this.CheckGameEnd();
                Cancel(form);

                if (this.DigSite.CardList.Count != 0)
                {
                    this.FirstPhase = true;
                    this.SecondPhase = false;
                }
                else if (gameEnd)
                {
                    this.FirstPhase = false;
                    this.SecondPhase = false;
                    int winner = this.FindWinner();
                    MessageBox.Show($"Game end! Winner is player {winner + 1}.");
                }

                form.Invalidate();
            }
        }

        /// <summary>
        /// Draw all static elements in the match (digsite, current player in turn, etc...)
        /// Label will be updated in the form's parint function.
        /// </summary>
        /// <param name="paper"></param>
        public void Draw(Graphics paper)
        {
            this.Players[this.PlayerIndex].PlayerDeck.FlipState = true;

            if (this.DigSite != null && this.DigSite.CardList.Count != 0)
            {
                this.DigSite.CardList[0].Draw(paper);
            }
            if (this.Museum != null && this.Museum.CardList.Count != 0)
            {
                this.Museum.CardList[0].Draw(paper);
            }
            if (this.PyramidSmall != null && this.PyramidSmall.CardList.Count != 0)
            {
                this.PyramidSmall.CardList[0].Draw(paper);
            }
            if (this.PyramidMedium != null && this.PyramidMedium.CardList.Count != 0)
            {
                this.PyramidMedium.CardList[0].Draw(paper);
            }
            if (this.PyramidLarge != null && this.PyramidLarge.CardList.Count != 0)
            {
                this.PyramidLarge.CardList[0].Draw(paper);
            }
            if (this.PyramidCard != null)
            {
                this.PyramidCard.Draw(paper);
            }
            if (this.SandStormPile != null && this.SandStormPile.CardList.Count != 0)
            {
                SandStormPile.Draw(paper);
            }
            if (this.ThiefPile != null && this.ThiefPile.CardList.Count != 0)
            {
                ThiefPile.Draw(paper);
            }
            if (this.MarketPlace != null && this.MarketPlace.CardList.Count != 0)
            {
                MarketPlace.Draw(paper);
            }
            foreach (Player p in this.Players)
            {
                if (p.PlayerDeck != null && p.PlayerDeck.CardList.Count != 0)
                {
                    p.PlayerDeck.Draw(paper);
                }
            }
        }

        /// <summary>
        /// Used when loading a new match, use to load the card.
        /// </summary>
        public static Deck LoadCard(Deck d, string[] split)
        {
            switch(split[0])
            {
                case "Pharaoh_sMask":
                    d.AddCard(new Pharaoh_sMask(bool.Parse(split[1]), int.Parse(split[2]), int.Parse(split[3])));
                    break;
                case "Talisman":
                    d.AddCard(new Talisman(bool.Parse(split[1]), int.Parse(split[2]), int.Parse(split[3])));
                    break;
                case "Coin":
                    d.AddCard(new Coin(bool.Parse(split[1]), int.Parse(split[2]), int.Parse(split[3])));
                    break;
                case "ParchmentScrap":
                    d.AddCard(new ParchmentScrap(bool.Parse(split[1]), int.Parse(split[2]), int.Parse(split[3])));
                    break;
                case "PotShard":
                    d.AddCard(new PotShard(bool.Parse(split[1]), int.Parse(split[2]), int.Parse(split[3])));
                    break;
                case "Maps":
                    d.AddCard(new Maps(bool.Parse(split[1]), int.Parse(split[2]), int.Parse(split[3])));
                    break;
                case "BrokenCup":
                    d.AddCard(new BrokenCup(bool.Parse(split[1]), int.Parse(split[2]), int.Parse(split[3])));
                    break;
                case "ThiefCard":
                    d.AddCard(new ThiefCard(bool.Parse(split[1]), int.Parse(split[2]), int.Parse(split[3])));
                    break;
                case "SandstormCard":
                    d.AddCard(new SandstormCard(bool.Parse(split[1]), int.Parse(split[2]), int.Parse(split[3])));
                    break;
            }
            return d;
        }
            

        /// <summary>
        /// Used to load a deck of card when loading a new match.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="sr"></param>
        public static Deck LoadDeck(Deck d, ref StreamReader sr)
        {
            string line;
            string[] split;
            line = sr.ReadLine();//This should give us the digsite's x and y coordinates.
            Console.WriteLine(line);
            if (line.Trim() == "null")//So the deck was null, such as the pyramid small after being pulled.
            {
                d = null;
                line = sr.ReadLine();//Escape the next ++.
                return null;
            }
            else//So the deck was not null, so we need to load.
            {
                split = line.Split(',');
                d = new Deck(int.Parse(split[0]), int.Parse(split[1]));
                line = sr.ReadLine();//First Card
                while (line.Trim() != "++")//This allows us to load the cards inside deck, before no more card left.
                {
                    split = line.Split(',');
                    d = LoadCard(d, split);
                    line = sr.ReadLine();
                }
            }
            return d;
        }

        /// <summary>
        /// This one is used to load the reference card in trade piles, so no new card will be created.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="g"></param>
        /// <param name="split"></param>
        public static Deck LoadReferenceCard(Deck d, Deck g, string[] split)
        {
            foreach (Card c in g.CardList)
            {
                string line = c.SaveToCSV();
                string[] split2 = line.Split(',');
                if (split[0] == split2[0] && split[1] == split2[1] && split[2] == split2[2] && split[3] == split2[3])
                {
                    d.AddCard(c);
                    break;
                }
            }
            return d;
        }

        /// <summary>
        /// This one is used to load a deck of reference card (refers to card in another deck), instead of creating new card for the deck.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="g"></param>
        /// <param name="sr"></param>
        public static Deck LoadReferenceDeck(Deck d, Deck r, ref StreamReader sr)
        {
            string line;
            string[] split;

            line = sr.ReadLine();//This should give us the digsite's x and y coordinates.

            if (line.Trim() == "null")
            {
                d = null;
                line = sr.ReadLine();//Escape the next ++.
                return null;
            }
            else//So the deck was not null, so we need to load.
            {
                split = line.Split(',');
                d = new Deck(int.Parse(split[0]), int.Parse(split[1]));
                line = sr.ReadLine();//First Card
                while (line.Trim() != "++")//This allows us to load the cards inside deck, before no more card left.
                {
                    split = line.Split(',');
                    d = LoadReferenceCard(d, r, split);
                    line = sr.ReadLine();
                }
            }
            return d;
        }
        /// <summary>
        /// Return a string with all the game data stored.
        /// Allows for immplementing save function.
        /// The code is dynamic, it should be able to save multiple player.
        /// </summary>
        /// <returns></returns>
        public string SaveToCSV()
        {
            string returnString;
            //First Line stored the number of players involved in a match.
            returnString = players.Length.ToString() + "\n";

            //PlayerIndex (Which won't be null)
            returnString += playerindex.ToString() + "\n";

            //DeckHeightAjustMent (Which won't be null
            returnString += deckHeightAjustMent + "\n";

            //Now we first need to store all of the field in match
            //First are the players.
            foreach (Player p in this.Players)
            {
                //Player data include: playervalue, card sold, match, deck location, and all of the cards in the deck.
                returnString += $"{p.PlayerDeck.Orientation},{p.PlayerDeck.X},{p.PlayerDeck.Y},{p.Value},{p.CardSold},{p.ToString()}\n";//A new match instance will be created with the player's information inject in.
                //A new deck instance will be created with all of the cards information player have.
                returnString += p.PlayerDeck.SaveToCSV();//This stores all of the card information in players deck, also include the deck's information (Position).
                returnString += "++\n";
            }
            //The for loop above should able to write out all player's information in an organised format.

            //Second are the decks of cards used during a match.

            //DigSite Deck
            if (DigSite != null)
            {
                returnString += DigSite.SaveToCSV();//This stores all of the cards information in digsite, also include the digsite's information (position).
            }
            else
            {
                returnString += "null\n";
            }
            returnString += "++\n";

            //Market Place
            if (MarketPlace != null)
            {
                returnString += MarketPlace.SaveToCSV();//This stores all of the cards information in digsite, also include the digsite's information (position).
            }
            else
            {
                returnString += "null\n";
            }
            returnString += "++\n";

            //Museum
            if (Museum != null)
            {
                returnString += Museum.SaveToCSV();//This stores all of the cards information in digsite, also include the digsite's information (position).
            }
            else
            {
                returnString += "null\n";
            }
            returnString += "++\n";

            //PyramidSmall
            if (PyramidSmall != null)
            {
                returnString += PyramidSmall.SaveToCSV();//This stores all of the cards information in digsite, also include the digsite's information (position).
            }
            else
            {
                returnString += "null\n";
            }
            returnString += "++\n";

            //PyramidMedium
            if (PyramidMedium != null)
            {
                returnString += PyramidMedium.SaveToCSV();//This stores all of the cards information in digsite, also include the digsite's information (position).
            }
            else
            {
                returnString += "null\n";
            }
            returnString += "++\n";

            //PyramidLarge
            if (PyramidLarge != null)
            {
                returnString += PyramidLarge.SaveToCSV();//This stores all of the cards information in digsite, also include the digsite's information (position).
            }
            else
            {
                returnString += "null\n";
            }
            returnString += "++\n";

            //SandStormPile
            if (SandStormPile != null)
            {
                returnString += SandStormPile.SaveToCSV();
            }
            else
            {
                returnString += "null\n";
            }
            returnString += "++\n";

            //ThiefPile
            if (ThiefPile != null)
            {
                returnString += ThiefPile.SaveToCSV();
            }
            else
            {
                returnString += "null\n";
            }
            returnString += "++\n";

            //MarketTradePile
            if (MarketTradePile != null)
            {
                returnString += MarketTradePile.SaveToCSV();//This stores all of the cards information in digsite, also include the digsite's information (position).
            }
            else
            {
                returnString += "null\n";
            }
            returnString += "++\n";

            //MuseumTradePile
            if (MuseumPile != null)
            {
                returnString += MuseumPile.SaveToCSV();//This stores all of the cards information in digsite, also include the digsite's information (position).
            }
            else
            {
                returnString += "null\n";
            }
            returnString += "++\n";

            //PlayerTradePile
            if (PlayerTradePile != null)
            {
                returnString += PlayerTradePile.SaveToCSV();//This stores all of the cards information in digsite, also include the digsite's information (position).
            }
            else
            {
                returnString += "null\n";
            }
            returnString += "++\n";

            //PyramidPile
            if (PyramidPile != null)
            {
                returnString += PyramidPile.SaveToCSV();//This stores all of the cards information in digsite, also include the digsite's information (position).
            }
            else
            {
                returnString += "null\n";
            }
            returnString += "++\n";

            //Next is to store the pyramidcard.
            returnString += pyramidCard.SaveToCSV() + "\n";

            //Next step is to store all of the boolean variables (including boolean array).
            //sandStormEnd Array;
            if (sandStormEnd != null)
            {
                foreach (bool b in sandStormEnd)
                {
                    returnString += $"{b.ToString()},";
                }
                returnString = returnString.Remove(returnString.Length - 1);//This would remove the last comma.                
            }
            else
            {
                returnString += "null";
            }
            returnString += "\n";

            //firstPhase 
            returnString += firstPhase.ToString() + "\n";

            //SecondPhase 
            returnString += SecondPhase.ToString() + "\n";

            //thiefPulled
            returnString += ThiefPulled.ToString() + "\n";

            //sandStormPulled
            returnString += sandStormPulled.ToString() + "\n";

            //Next step is to store all of the integer variabels (including integer array).

            //OriginalCardNumberByHalf
            if (OriginalCardNumberByHalf != null)
            {
                foreach (int i in OriginalCardNumberByHalf)
                {
                    returnString += $"{i.ToString()},";
                }
                returnString = returnString.Remove(returnString.Length - 1);//This would remove the last comma.   
            }
            else
            {
                returnString += "null";
            }
            //Then at the last return the string;
            return returnString;
        }

        public static void Load(String FileName)
        {
            StreamReader sr = File.OpenText(FileName);
            //The First Line Should be the number of player.
            string line = sr.ReadLine();
            string[] split;
            Match newMatch = new Match(int.Parse(line.Trim()));

            PVC pvc = null;
            PVPP pvpp = null;
            if (newMatch.Players.Length == 2)
            {
                pvc = new PVC(newMatch);
            }
            else if (newMatch.Players.Length == 3)
            {
                pvpp = new PVPP(newMatch);
            }

            //The Second Line Should be the selected player index.
            line = sr.ReadLine();
            newMatch.PlayerIndex = int.Parse(line.Trim());

            //The third line is the deckHeightAjustMent
            line = sr.ReadLine();
            newMatch.DeckHeightAjustMent = int.Parse(line.Trim());

            //In the next section we have to keep reading all the players data.
            //Since we adlready know the number of players, we will use that to determine how many times we have to read.
            for (int i = 0; i < newMatch.Players.Length; i++)
            {
                line = sr.ReadLine();
                //The first line of a player include:deck orientation, deck.X, deck.Y, player value, card sold, and type;
                split = line.Split(',');

                if (split[split.Length - 1].Trim() == "Person")
                {
                    newMatch.Players[i] = new Person(new Deck(int.Parse(split[1]), int.Parse(split[2])), int.Parse(split[3]), int.Parse(split[4]), newMatch);                 
                }
                else if (split[split.Length - 1].Trim() == "Robot")
                {
                    newMatch.Players[i] = new Robot(new Deck(int.Parse(split[1]), int.Parse(split[2])), int.Parse(split[3]), int.Parse(split[4]), newMatch);
                }
                newMatch.Players[i].PlayerDeck.Orientation = split[0].ToString();
                newMatch.Players[i].PlayerDeck.CardList = Match.LoadDeck(newMatch.Players[i].PlayerDeck, ref sr).CardList;
                //newMatch.Players[i].PlayerDeck.ArrangeByType();
            }
            //After the for loop above, all of the player should be successuflly created and loaded.
            //Next step is to loading the decks

            Form f = null;

            if (pvc != null)
            {
                f = pvc;
            }
            else if (pvpp != null)
            {
                f = pvpp;
            }
            newMatch.DigSite = new Deck((f.Width / 2) + 2 * Card.width, (f.Height / 2) - 2 * Card.height + newMatch.DeckHeightAjustMent);
            newMatch.MarketPlace = new Deck((f.Width / 2) - 3 * Card.width, (f.Height / 2) - 2 * Card.height + newMatch.DeckHeightAjustMent);
            newMatch.Museum = new Deck(f.Width - 2 * Card.width, f.Height - (int)(1.5 * Card.height) + newMatch.DeckHeightAjustMent);
            newMatch.MarketTradePile = new Deck(0, 0);
            newMatch.PlayerTradePile = new Deck(0, 0);
            newMatch.PyramidPile = new Deck(0, 0);
            newMatch.PyramidCard = new PyramidCard(true, (f.Width / 2) - (int)(0.5 * Card.width), f.Height / 2 - (int)(0.5 * Card.height) + newMatch.DeckHeightAjustMent);
            newMatch.MuseumPile = new Deck(0, 0);
            newMatch.PyramidSmall = new Deck((f.Width / 2) - (int)(4.5 * Card.width), f.Height / 2 - (int)(0.5 * Card.height) + newMatch.DeckHeightAjustMent);
            newMatch.PyramidMedium = new Deck((f.Width / 2) - (int)(0.5 * Card.width), (f.Height / 2) - 2 * Card.height + newMatch.DeckHeightAjustMent);
            newMatch.PyramidLarge = new Deck((f.Width / 2) + (int)(3.5 * Card.width), f.Height / 2 - (int)(0.5 * Card.height) + newMatch.DeckHeightAjustMent);
            newMatch.SandStormPile = new Deck((f.Width / 2) - (int)(2 * Card.width), f.Height / 2 - (int)(0.5 * Card.height) + newMatch.DeckHeightAjustMent);
            newMatch.ThiefPile = new Deck((f.Width / 2) + (int)(1 * Card.width), f.Height / 2 - (int)(0.5 * Card.height) + newMatch.DeckHeightAjustMent);

            //Loading DigSite.
            newMatch.DigSite.CardList = Match.LoadDeck(newMatch.DigSite, ref sr).CardList;
            //Loding Complete

            //Loding MarketPlace
            newMatch.MarketPlace.CardList = Match.LoadDeck(newMatch.MarketPlace, ref sr).CardList;
            //Loding Complete

            //Loding Museum
            newMatch.Museum.CardList = Match.LoadDeck(newMatch.Museum, ref sr).CardList;
            //Loding Complete

            //Loding PyramidSmall
            newMatch.PyramidSmall.CardList = Match.LoadDeck(newMatch.PyramidSmall, ref sr).CardList;
            //Loding Complete

            //Loding PyramidMedium
            newMatch.PyramidMedium.CardList = Match.LoadDeck(newMatch.PyramidMedium, ref sr).CardList;
            //Loding Complete

            //Loding PyramidLarge
            newMatch.PyramidLarge.CardList = Match.LoadDeck(newMatch.PyramidLarge, ref sr).CardList;
            //Loading Complete

            //Loding SandStormPile
            newMatch.SandStormPile.CardList = Match.LoadDeck(newMatch.SandStormPile, ref sr).CardList;
            //Loading Complete

            //Loding ThiefLarge
            newMatch.ThiefPile.CardList = Match.LoadDeck(newMatch.ThiefPile, ref sr).CardList;
            //Loading Complete

            //Loding MarketTradePile
            newMatch.MarketTradePile.CardList = Match.LoadReferenceDeck(newMatch.MarketTradePile, newMatch.MarketPlace, ref sr).CardList;
            //Loding Complete

            //Loding MuseumPIle
            newMatch.MuseumPile.CardList = Match.LoadReferenceDeck(newMatch.MuseumPile, newMatch.Players[newMatch.PlayerIndex].PlayerDeck, ref sr).CardList;
            //Loding Complete

            //Loding PlayerTradePile
            newMatch.PlayerTradePile.CardList = Match.LoadReferenceDeck(newMatch.PlayerTradePile, newMatch.Players[newMatch.PlayerIndex].PlayerDeck, ref sr).CardList;
            //Loding Complete

            //Loding PyramidPile
            newMatch.PyramidPile.CardList = Match.LoadReferenceDeck(newMatch.PyramidPile, newMatch.Players[newMatch.PlayerIndex].PlayerDeck, ref sr).CardList;
            //Loding Complete

            //After the operations above, all deck should be loaded.
            //Next is the pyramid.
            line = sr.ReadLine();
            split = line.Split(',');
            newMatch.PyramidCard = new PyramidCard(bool.Parse(split[1]), int.Parse(split[2]), int.Parse(split[3]));

            //Next is the SandStormEnd Array, but We have to check if it is null or not.
            line = sr.ReadLine();
            if (!(line.Trim() == "null"))//if the sandstormend array is not null.
            {
                split = line.Split(',');
                newMatch.SandStormEnd = new bool[split.Length];
                for (int i = 0; i < split.Length; i++)
                {
                    newMatch.SandStormEnd[i] = bool.Parse(split[i]);
                }
            }

            //Next is the FirstPhase boolean.
            line = sr.ReadLine();
            newMatch.FirstPhase = bool.Parse(line.Trim());

            //Next is the SecondPhase boolean.
            line = sr.ReadLine();
            newMatch.SecondPhase = bool.Parse(line.Trim());

            //Next is the thiefPolled boolean.
            line = sr.ReadLine();
            newMatch.ThiefPulled = bool.Parse(line.Trim());

            //Next is the SandStormPulled Boolean
            line = sr.ReadLine();
            newMatch.SandStormPulled = bool.Parse(line.Trim());

            //Next is the OriginalNumberByHalf Array, we also have to check if it is null or not.
            line = sr.ReadLine();
            if (!(line.Trim() == "null"))//if the originalNumberByHalf array is not null.
            {
                split = line.Split(',');
                newMatch.OriginalCardNumberByHalf = new int[split.Length];
                for (int i = 0; i < split.Length; i++)
                {
                    newMatch.OriginalCardNumberByHalf[i] = int.Parse(split[i]);
                }
            }

            sr.Close();
            //After all the variables loaded we should be ready to go.


            if (pvc != null)
            {
                if (newMatch.Players[0] is Person && newMatch.Players[1] is Person)
                {
                    pvc.Text = "PVP";
                }
                if (newMatch.Players[0] is Person && newMatch.Players[1] is Robot)
                {
                    pvc.Text = "PVC";
                }
                if (newMatch.Players[0] is Robot && newMatch.Players[1] is Robot)
                {
                    pvc.Text = "CVC";
                }
                pvc.Show();

                pvc.Invalidate();
            }
            else if (pvpp != null)
            {
                if (newMatch.Players[0] is Person && newMatch.Players[1] is Person && newMatch.Players[2] is Person)
                {
                    pvpp.Text = "PVPP";
                }
                if (newMatch.Players[0] is Person && newMatch.Players[1] is Robot && newMatch.Players[2] is Robot)
                {
                    pvpp.Text = "PVCC";
                }
                pvpp.Show();
                pvpp.Invalidate();
            }
            newMatch.SaveDirectory = FileName;
        }

        public void Save()//If this is called then the save file directory is not empty.
        {
            StreamWriter sw = new StreamWriter(SaveDirectory);
            sw.Write(SaveToCSV());
            sw.Close();
        }
    }
}
