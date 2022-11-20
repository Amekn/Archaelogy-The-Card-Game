using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_2___PreAlpha
{
    public partial class PVC : Form
    {
        /// <summary>
        /// A match object stored the information about the players during a match.
        /// </summary>
        private Match match;

        public Match Match
        {
            get { return match; }
            set { match = value; }
        }


        /// <summary>
        /// Called when a new 2 player game started.
        /// </summary>
        public PVC(Match match)
        {
            this.match = match;
            InitializeComponent();
        }

        /// <summary>
        /// Set up the start point of the game, initialise the set up for a game.
        /// </summary>
        public void Initialisation()
        {
            //Second step is to initialise the treasure deck, and match.MarketPlace.
            match.DigSite = new Deck((this.Width / 2) + 2 * Card.width, (this.Height / 2) - 2 * Card.height + match.DeckHeightAjustMent);
            match.MarketPlace = new Deck((this.Width / 2) - 3 * Card.width, (this.Height / 2) - 2 * Card.height + match.DeckHeightAjustMent);
            match.Museum = new Deck(this.Width - 2 * Card.width, this.Height - (int)(1.5 * Card.height) + match.DeckHeightAjustMent);
            match.MarketTradePile = new Deck(0, 0);
            match.PlayerTradePile = new Deck(0, 0);
            match.PyramidPile = new Deck(0, 0);
            match.MuseumPile = new Deck(0, 0);
            match.PyramidCard = new PyramidCard(true, (this.Width / 2) - (int)(0.5 * Card.width), this.Height / 2 - (int)(0.5 * Card.height) + match.DeckHeightAjustMent);
            match.SandStormPile = new Deck((this.Width / 2) - (int)(2 * Card.width), this.Height / 2 - (int)(0.5 * Card.height) + match.DeckHeightAjustMent);
            match.ThiefPile = new Deck((this.Width / 2) + (int)(1 * Card.width), this.Height / 2 - (int)(0.5 * Card.height) + match.DeckHeightAjustMent);
            labelMarket.Location = new Point(match.MarketPlace.X - labelMarket.Text.Length * 13, match.MarketPlace.Y);
            labelDigSite.Location = new Point(match.DigSite.X - labelMarket.Text.Length * 13, match.DigSite.Y);
            //Third step is to adding card into the digsite.
            for (int i = 0; i < 18; i++)
            {
                match.DigSite.AddCard(new PotShard(false, match.DigSite.X, match.DigSite.Y));
            }
            for (int i = 0; i < 16; i++)
            {
                match.DigSite.AddCard(new ParchmentScrap(false, match.DigSite.X, match.DigSite.Y));
            }
            for (int i = 0; i < 14; i++)
            {
                match.DigSite.AddCard(new Coin(false, match.DigSite.X, match.DigSite.Y));
            }
            for (int i = 0; i < 8; i++)
            {
                match.DigSite.AddCard(new Talisman(false, match.DigSite.X, match.DigSite.Y));
            }
            for (int i = 0; i < 6; i++)
            {
                match.DigSite.AddCard(new BrokenCup(false, match.DigSite.X, match.DigSite.Y));
            }
            for (int i = 0; i < 4; i++)
            {
                match.DigSite.AddCard(new Pharaoh_sMask(false, match.DigSite.X, match.DigSite.Y));
            }
            //Fourth step is to shuffle the deck.
            match.DigSite.SuffleCard();//Test passed
            //Fifth step is to disribute the cards.
            //Test passed.
            for (int i = 0; i < 4; i++)
            {
                match.Players[0].PlayerDeck.AddCard(match.DigSite.CardList[i]);
            }
            match.Players[0].PlayerDeck.ArrangeByTypeQuickSort();
            for (int i = 4; i < 8; i++)
            {
                match.Players[1].PlayerDeck.AddCard(match.DigSite.CardList[i]);
            }
            match.Players[1].PlayerDeck.ArrangeByTypeQuickSort();
            for (int i = 8; i < 13; i++)
            {
                match.DigSite.CardList[i].FlipState = true;
                match.MarketPlace.AddCard(match.DigSite.CardList[i]);
            }
            
            match.MarketPlace.ArrangeByTypeQuickSort();
            for (int i = 0; i < 13; i++)
            {
                match.DigSite.CardList.RemoveAt(0);
            }
            //Sixth step is to form treasure pile.
            match.PyramidSmall = new Deck((this.Width / 2) - (int)(4.5 * Card.width), this.Height / 2 - (int)(0.5 * Card.height) + match.DeckHeightAjustMent);
            match.PyramidMedium = new Deck((this.Width / 2) - (int)(0.5 * Card.width), (this.Height / 2) - 2 * Card.height + match.DeckHeightAjustMent);
            match.PyramidLarge = new Deck((this.Width / 2) + (int)(3.5 * Card.width), this.Height / 2 - (int)(0.5 * Card.height) + match.DeckHeightAjustMent);
            for (int i = 0; i < 3; i++)
            {
                match.PyramidSmall.AddCard(match.DigSite.CardList[i]);
            }
            match.PyramidSmall.ArrangeByTypeQuickSort();
            for (int i = 3; i < 8; i++)
            {
                match.PyramidMedium.AddCard(match.DigSite.CardList[i]);
            }
            match.PyramidMedium.ArrangeByTypeQuickSort();
            for (int i = 8; i < 15; i++)
            {
                match.PyramidLarge.AddCard(match.DigSite.CardList[i]);
            }
            match.PyramidLarge.ArrangeByTypeQuickSort();
            for (int i = 0; i < 15; i++)
            {
                match.DigSite.CardList.RemoveAt(0);
            }
            /*Testing passed
            TestingTextBox.Text += digSite.ToString();
            TestingTextBox.Text += "-------------------------------------------------------------------------------\n\r";
            TestingTextBox.Text += PyramidSmall.ToString();
            TestingTextBox.Text += "-------------------------------------------------------------------------------\n\r";
            TestingTextBox.Text += PyramidMedium.ToString();
            TestingTextBox.Text += "-------------------------------------------------------------------------------\n\r";
            TestingTextBox.Text += PyramidLarge.ToString();
            */

            //Seventh step is to add in other cards (sandstorm, thief, and map) into the digset, and then resuffle the deck.
            for (int i = 0; i < 6; i++)
            {
                match.DigSite.AddCard(new Maps(false, match.DigSite.X, match.DigSite.Y));
            }
            for (int i = 0; i < 8; i++)
            {
                match.DigSite.AddCard(new ThiefCard(false, match.DigSite.X, match.DigSite.Y));
            }
            for (int i = 0; i < 6; i++)
            {
                match.DigSite.AddCard(new SandstormCard(false, match.DigSite.X, match.DigSite.Y));
            }
            match.DigSite.SuffleCard();

            //Last step here is to randomly pick a starting player and set it to the player in turn.
            Random r = new Random();
            match.PlayerIndex = r.Next(match.Players.Length);//So either index be 0 or 1, indicates player 1 or player 2.
            match.FirstPhase = true;
            GameTime.Enabled = true;
            //Call first phase to start the game.
            this.Invalidate();
        }

        /// <summary>
        /// Enables external timer controll from the main menu when loding a previous game.
        /// </summary>
        public Timer TimeControl
        {
            get { return GameTime; }
            set { GameTime = value; }
        }

        /// <summary>
        /// Function called every 1000 miliseconds (1 second), to trigger robot behavior.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameTime_Tick(object sender, EventArgs e)
        {
            if (match.Players[match.PlayerIndex] is Person)
            {
                buttonEndTurn.Enabled = true;
                buttonCancel.Enabled = true;
                buttonSell.Enabled = true;
                buttonTrade.Enabled = true;
            }
            if (match.Players[match.PlayerIndex] is Robot)
            {
                buttonEndTurn.Enabled = false;
                buttonCancel.Enabled = false;
                buttonSell.Enabled = false;
                buttonTrade.Enabled = false;
                Robot R = (Robot)match.Players[match.PlayerIndex];
                if (match.FirstPhase)
                {
                    if (match.SandStormPulled == false && match.ThiefPulled == false)
                    {
                        match.Players[match.PlayerIndex].PullCard(this);
                        //If a treasure card is pulled, the rest of the code will be escaped.
                        //Else depends on the card pulled excute the rest.
                    }
                    else if (match.ThiefPulled)
                    {
                        //First is to check there are card available for steal.
                        if (match.CheckThief())
                        {
                            //create new integer variable to store the random generated index of the player going to be stolen.
                            int stealindex = 0;
                            Random r = new Random();
                            //If the stealindex == match.PlayerIndex, mean the current player is selected, then re pick a player.
                            //If a selected player does have card in their card, repick a player.
                            while (stealindex == match.PlayerIndex || match.Players[stealindex].PlayerDeck.CardList.Count == 0)
                            {
                                stealindex = r.Next(match.Players.Length);
                            }
                            //Call the thiefaction function in robot class to steal, add, remove, and rearrange the cards.
                            R.ThiefAction(stealindex, 0);
                        }
                        match.ThiefPulled = false;
                        match.SelectedCard = null;
                        match.DigSite.CardList.RemoveAt(0);
                        match.FirstPhase = false;
                        match.SecondPhase = true;
                        //The thief action for robot ends here.
                    }
                    else if (match.SandStormPulled)
                    {
                        bool terminate;
                        //While the robot has more card than half of the original card count, remove 1 card everytime.
                        while (match.Players[match.PlayerIndex].PlayerDeck.CardList.Count > match.OriginalCardNumberByHalf[match.PlayerIndex])
                        {
                            R.SandStormAction(0, 0);
                        }

                        //Need to be checked every time.
                        for (int i = 0; i < match.Players.Length; i++)
                        {
                            if (match.Players[i].PlayerDeck.CardList.Count <= match.OriginalCardNumberByHalf[i])
                            {
                                match.SandStormEnd[i] = true;
                            }
                        }

                        match.Players[match.PlayerIndex].PlayerDeck.FlipState = false;
                        match.PlayerIndex = match.TurnRotation();
                        //Check if Sandstorm has ended or not.
                        if (terminate = match.CheckSandStorm())
                        {
                            match.DigSite.CardList.RemoveAt(0);
                            match.SandStormPulled = false;
                            match.FirstPhase = false;
                            match.SecondPhase = true;
                        }

                    }
                    this.Invalidate();
                }
                else if (match.SecondPhase && match.DigSite.CardList.Count != 0 && match.Players[match.PlayerIndex].PlayerDeck.CardList.Count != 0)
                {
                    //In the second Phase, robot will randomly pick a action to do. 
                    Random r = new Random();
                    int action = r.Next(10);//So the possible generated number will be 0, 1, 2, 3, 4, 5.
                    if (action == 0 || action == 1)//Robot will try to trade. (33% chance).
                    {
                        //first is to add few random card into the player trade pile.
                        for (int i = match.Players[match.PlayerIndex].PlayerDeck.CardList.Count - 1; i >= r.Next(match.Players[match.PlayerIndex].PlayerDeck.CardList.Count); i--)
                        {
                            //The for loop here will random move few card from the buttom of the deck to the player trade pile.
                            match.PlayerTradePile.AddCard(match.Players[match.PlayerIndex].PlayerDeck.CardList[i]);
                            labelPlayerTrade.Text = $"Player Trade Value: {match.PlayerTradePile.TradeValue}";
                            //No repeated card will be added, so there is no need to check for repeated card in playertradepile.
                        }
                        //Second is to add few random card into the robot trade pile.
                        for (int i = match.MarketPlace.CardList.Count - 1; i >= r.Next(match.MarketPlace.CardList.Count); i--)
                        {
                            match.MarketTradePile.AddCard(match.MarketPlace.CardList[i]);
                            labelMarketTrade.Text = $"Market Trade Value: {match.MarketTradePile.TradeValue}";
                        }
                        //Third is to call the function of the trade button, to trade/not trade(if the value does not meet).
                        buttonTrade_Click(sender, e);
                    }
                    else if (action == 2 || action == 3)//Robot will try to use their map. (16.6% chance).
                    {
                        //For each map card present, there are a certain chance for it to be added into the pyramid pile.
                        for (int i = 0; i < match.Players[match.PlayerIndex].PlayerDeck.CardList.Count; i++)
                        {
                            if (match.Players[match.PlayerIndex].PlayerDeck.CardList[i] is Maps && ((i % 3) <= r.Next(3)) && match.PyramidPile.CardList.Count < 3)
                            {
                                match.PyramidPile.CardList.Add(match.Players[match.PlayerIndex].PlayerDeck.CardList[i]);
                                labelMapsUsed.Text = $"Number Of Maps Used: {match.PyramidPile.CardList.Count}";
                            }
                        }
                        //Now call the the function of the pyramid button events, to use the map (checks will be done in the pyramid button click events).
                        R.PyramidAction(0, 0, this);
                        buttonCancel_Click(sender, e);
                    }
                    else if (action == 4 || action == 5 || action == 6)//Robot will try to sell to the museum. (16.6 chance).
                    {
                        //Robot will find the most Valueable Set and return them to here.
                        match.MuseumPile.CardList.AddRange(R.FindMostValuableSet());
                        string line = match.MuseumPile.CardList[0].GetType().ToString();
                        string[] split = line.Split('.');
                        labelCurrentSell.Text = $"Current Sell Item: {split[split.Length - 1]}";
                        labelCurrentSellNumber.Text = $"Number of Items: {match.MuseumPile.CardList.Count}";
                        buttonSell_Click(sender, e);
                    }
                    else if (action == 7 || action == 8 || action == 9)//When action = 3, let the robot end the current half (33% chance to end the current turn).
                    {
                        buttonEndTurn_Click(sender, e);
                    }
                    this.Invalidate();
                }
                else if (match.SecondPhase && match.DigSite.CardList.Count != 0 && match.Players[match.PlayerIndex].PlayerDeck.CardList.Count == 0)
                {
                    //If there is no card in hand. Such as after a sandstorm occurred, there is really nothing the robot can do, so end the turn.
                    buttonEndTurn_Click(sender, e);
                    this.Invalidate();
                }
                else if (match.SecondPhase && match.DigSite.CardList.Count == 0)
                {
                    //This occurs when no more card in the digSite, robot will be command to sell all their cards in sets.
                    //After which end their turn. 
                    if (match.Players[match.PlayerIndex].PlayerDeck.CardList.Count != 0)
                    //If there are still cards left in the robot hand, sell them all.
                    {
                        int cardindex = match.Players[match.PlayerIndex].PlayerDeck.CardList.Count - 1;
                        TreasureCard t = (TreasureCard)match.Players[match.PlayerIndex].PlayerDeck.CardList[cardindex];
                        for (int i = 0; i < match.Players[match.PlayerIndex].PlayerDeck.CardList.Count; i++)
                        {
                            if (match.Players[match.PlayerIndex].PlayerDeck.CardList[i].GetType() == match.Players[match.PlayerIndex].PlayerDeck.CardList[cardindex].GetType() && match.MuseumPile.CardList.Count < t.SetValueArray.Length)
                            //If the card are the same type as the randomly selected card.
                            //If currently there are less card store in selling pile than the maximum number of card for a set.
                            //Then add this card into the set, and sell.
                            {
                                match.MuseumPile.AddCard(match.Players[match.PlayerIndex].PlayerDeck.CardList[i]);
                            }
                        }
                        string line = match.MuseumPile.CardList[0].GetType().ToString();
                        string[] split = line.Split('.');
                        labelCurrentSell.Text = $"Current Sell Item: {split[split.Length - 1]}";
                        labelCurrentSellNumber.Text = $"Number of Items: {match.MuseumPile.CardList.Count}";
                        buttonSell_Click(sender, e);
                        //As the results of the timer events, a loop is not needed here to sell all the sets of card. 
                        //For every 10 milisecond, as set of card will be sold, until not more card left where the Count == 0;
                    }
                    if (match.Players[match.PlayerIndex].PlayerDeck.CardList.Count == 0)
                    //If there are no cards left, end their turn.
                    {
                        buttonEndTurn_Click(sender, e);
                    }
                    this.Invalidate();
                }
            }
        }

        private void PVP_MouseClick(object sender, MouseEventArgs e)
        {

            //If the game currently stays in firstphase, all relevant functions will be checked, and can be triggered.
            if (match.FirstPhase)//Section tested.                           
            {
                if (match.DigSite.CardList.Count != 0)
                {
                    if (match.DigSite.CardList[0].IsMouseOn(e.X, e.Y) && match.ThiefPulled == false && match.SandStormPulled == false)//The action here                                                                                                                    //allows the player to pick a card from the dig site at the start of their turn.
                    {
                        match.Players[match.PlayerIndex].PullCard(this);
                    }
                    else if (match.ThiefPulled)//The action here allows the player in turn to steal card from another player.
                    {
                        match.Players[match.PlayerIndex].ThiefAction(e.X, e.Y);
                    }
                    else if (match.SandStormPulled)
                    {
                        match.Players[match.PlayerIndex].SandStormAction(e.X, e.Y);
                    }
                }
            }
            else if (match.SecondPhase)
            {
                for (int j = match.Players[match.PlayerIndex].PlayerDeck.CardList.Count - 1; j >= 0; j--)
                {
                    if (match.Players[match.PlayerIndex].PlayerDeck.CardList[j].IsMouseOn(e.X, e.Y))
                    {
                        if (!match.PlayerTradePile.CardList.Contains(match.Players[match.PlayerIndex].PlayerDeck.CardList[j]))
                        {
                            match.PlayerTradePile.AddCard(match.Players[match.PlayerIndex].PlayerDeck.CardList[j]);
                            labelPlayerTrade.Text = $"Player Trade Value: {match.PlayerTradePile.TradeValue}";
                        }

                        if (match.Players[match.PlayerIndex].PlayerDeck.CardList[j] is Maps && !match.PyramidPile.CardList.Contains(match.Players[match.PlayerIndex].PlayerDeck.CardList[j]) && match.PyramidPile.CardList.Count < 3)
                        {
                            match.PyramidPile.AddCard(match.Players[match.PlayerIndex].PlayerDeck.CardList[j]);
                            labelMapsUsed.Text = $"Number Of Maps Used: {match.PyramidPile.CardList.Count}";
                        }

                        if (!match.MuseumPile.CardList.Contains(match.Players[match.PlayerIndex].PlayerDeck.CardList[j]))
                        {
                            if (match.MuseumPile.CardList.Count > 0 && match.MuseumPile.CardList[0].GetType() == match.Players[match.PlayerIndex].PlayerDeck.CardList[j].GetType())
                            {
                                TreasureCard c = (TreasureCard)match.MuseumPile.CardList[0];
                                if (match.MuseumPile.CardList.Count < c.SetValueArray.Length)
                                {
                                    match.MuseumPile.AddCard(match.Players[match.PlayerIndex].PlayerDeck.CardList[j]);
                                }
                            }
                            else if (match.MuseumPile.CardList.Count == 0)
                            {
                                match.MuseumPile.AddCard(match.Players[match.PlayerIndex].PlayerDeck.CardList[j]);
                            }
                            string line = match.MuseumPile.CardList[0].GetType().ToString(); 
                            string[] split = line.Split('.');
                            labelCurrentSell.Text = $"Current Sell Item: {split[split.Length - 1]}";
                            labelCurrentSellNumber.Text = $"Number of Items: {match.MuseumPile.CardList.Count}";
                        }
                        break;
                    }
                }

                for (int j = match.MarketPlace.CardList.Count - 1; j >= 0; j--)
                {
                    if (match.MarketPlace.CardList[j].IsMouseOn(e.X, e.Y))
                    {
                        if (!match.MarketTradePile.CardList.Contains(match.MarketPlace.CardList[j]))
                        {
                            match.MarketTradePile.AddCard(match.MarketPlace.CardList[j]);
                            labelMarketTrade.Text = $"Market Trade Value: {match.MarketTradePile.TradeValue}";
                        }
                        break;
                    }
                }

                match.Players[match.PlayerIndex].PyramidAction(e.X, e.Y, this);
            }
            this.Invalidate();

        }

        /// <summary>
        /// Performe the action when a treasure card is pulled.
        /// Method tested
        /// </summary>

        /// <summary>
        /// This function trigger the trade action.
        /// Move the card from player's deck to market deck.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonTrade_Click(object sender, EventArgs e)
        {
            match.Trade(this);
        }

        /// <summary>
        /// Button used to sell a set to museum.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSell_Click(object sender, EventArgs e)
        {
            match.Sell(this);
        }

        /// <summary>
        /// This button is used to clear all the datas stored for match.SecondPhase controled
        /// Clear allows the player to start a new round (Trade / Explore the pyramid / Sell to the Museum).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            match.Cancel(this);
        }

        /// <summary>
        /// Player would click this button to end their turn
        /// Only work if they are in second phase.
        /// The other player will start their turn (clockwise).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEndTurn_Click(object sender, EventArgs e)
        {
            match.CheckEnd(this);
        }

        /// <summary>
        /// Used to print out all of the cards.
        /// Checks has been done to ensure decks are neither null or empty.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PVP_Paint(object sender, PaintEventArgs e)
        {
            //Table updating
            if (match.FirstPhase || match.SecondPhase)
            {
                if (match.FirstPhase)
                {
                    label4.Text = "Phase: 1";
                }
                else if (match.SecondPhase)
                {
                    label4.Text = "Phase: 2";
                }
            }
            labelPlayer.Text = $"Player {match.PlayerIndex + 1}";

            labelPlayer1Value.Text = match.Players[0].Value.ToString();
            labelPlayer2Value.Text = match.Players[1].Value.ToString();

            labelPlayerTrade.Text = $"Player Trade Value: {match.PlayerTradePile.TradeValue}";
            labelMarketTrade.Text = $"Market Trade Value: {match.MarketTradePile.TradeValue}";
            labelMapsUsed.Text = $"Number Of Maps: {match.PyramidPile.CardList.Count()}";
            if (match.MuseumPile.CardList.Count() != 0)
            {
                string line = match.MuseumPile.CardList[0].GetType().ToString();
                string[] split = line.Split('.');
                labelCurrentSell.Text = $"Current Sell Item: {split[split.Length - 1]}";
            }
            else
            {
                labelCurrentSell.Text = $"Current Sell Item: null";
            }
            labelCurrentSellNumber.Text = $"Number of Items: {match.MuseumPile.CardList.Count}";

            match.Draw(e.Graphics);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV Files | *.csv";
            saveFileDialog.Title = "Save Game";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.DefaultExt = "csv";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog.FileName);
                sw.Write(match.SaveToCSV());
                match.SaveDirectory = saveFileDialog.FileName;
                sw.Close();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (match.SaveDirectory != "")
            {
                match.Save();
            }
            else
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }
        }

        public void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV Files | *.csv";
            openFileDialog.Title = "Load Game";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.DefaultExt = "csv";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Match.Load(openFileDialog.FileName);
            }
        }

        private void playersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainMenu.button2Player_Click(sender, e);
        }

        private void playerVsComputerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainMenu.buttonPlayerVSComputer_Click(sender, e);
        }

        private void computerVsComputerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainMenu.buttonComputerVSComputer_Click(sender, e);
        }

        private void computerVs2ComputerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainMenu.button3Player_Click(sender, e);
        }

        private void playerVs2ComputerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainMenu.buttonPlayerVs2Computer_Click(sender, e);
        }
    }
}
