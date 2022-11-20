namespace Assignment_2___PreAlpha
{
    partial class PVC
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelPlayer = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonTrade = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelPlayerTrade = new System.Windows.Forms.Label();
            this.labelMarketTrade = new System.Windows.Forms.Label();
            this.labelMapsUsed = new System.Windows.Forms.Label();
            this.buttonEndTurn = new System.Windows.Forms.Button();
            this.labelPlayer1Value = new System.Windows.Forms.Label();
            this.labelPlayer2Value = new System.Windows.Forms.Label();
            this.buttonSell = new System.Windows.Forms.Button();
            this.labelCurrentSell = new System.Windows.Forms.Label();
            this.labelCurrentSellNumber = new System.Windows.Forms.Label();
            this.GameTime = new System.Windows.Forms.Timer(this.components);
            this.labelPulled = new System.Windows.Forms.Label();
            this.labelMarket = new System.Windows.Forms.Label();
            this.labelDigSite = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playerVsComputerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.computerVsComputerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.computerVs2ComputerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playerVs2ComputerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Player 1: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1050, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Player 2:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(655, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Player in turn: ";
            // 
            // labelPlayer
            // 
            this.labelPlayer.AutoSize = true;
            this.labelPlayer.BackColor = System.Drawing.Color.Transparent;
            this.labelPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayer.Location = new System.Drawing.Point(828, 24);
            this.labelPlayer.Name = "labelPlayer";
            this.labelPlayer.Size = new System.Drawing.Size(79, 25);
            this.labelPlayer.TabIndex = 4;
            this.labelPlayer.Text = "Player";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(375, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Phase: ";
            // 
            // buttonTrade
            // 
            this.buttonTrade.BackColor = System.Drawing.Color.Tomato;
            this.buttonTrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTrade.ForeColor = System.Drawing.Color.White;
            this.buttonTrade.Location = new System.Drawing.Point(17, 548);
            this.buttonTrade.Name = "buttonTrade";
            this.buttonTrade.Size = new System.Drawing.Size(116, 58);
            this.buttonTrade.TabIndex = 6;
            this.buttonTrade.Text = "Trade";
            this.buttonTrade.UseVisualStyleBackColor = false;
            this.buttonTrade.Click += new System.EventHandler(this.buttonTrade_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.Tomato;
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.ForeColor = System.Drawing.Color.White;
            this.buttonCancel.Location = new System.Drawing.Point(139, 548);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(119, 58);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Clear";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelPlayerTrade
            // 
            this.labelPlayerTrade.AutoSize = true;
            this.labelPlayerTrade.BackColor = System.Drawing.Color.Transparent;
            this.labelPlayerTrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayerTrade.ForeColor = System.Drawing.Color.White;
            this.labelPlayerTrade.Location = new System.Drawing.Point(12, 609);
            this.labelPlayerTrade.Name = "labelPlayerTrade";
            this.labelPlayerTrade.Size = new System.Drawing.Size(221, 25);
            this.labelPlayerTrade.TabIndex = 8;
            this.labelPlayerTrade.Text = "Player Trade Value:";
            // 
            // labelMarketTrade
            // 
            this.labelMarketTrade.AutoSize = true;
            this.labelMarketTrade.BackColor = System.Drawing.Color.Transparent;
            this.labelMarketTrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMarketTrade.ForeColor = System.Drawing.Color.White;
            this.labelMarketTrade.Location = new System.Drawing.Point(339, 609);
            this.labelMarketTrade.Name = "labelMarketTrade";
            this.labelMarketTrade.Size = new System.Drawing.Size(226, 25);
            this.labelMarketTrade.TabIndex = 9;
            this.labelMarketTrade.Text = "Market Trade Value:";
            // 
            // labelMapsUsed
            // 
            this.labelMapsUsed.AutoSize = true;
            this.labelMapsUsed.BackColor = System.Drawing.Color.Transparent;
            this.labelMapsUsed.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMapsUsed.ForeColor = System.Drawing.Color.White;
            this.labelMapsUsed.Location = new System.Drawing.Point(655, 609);
            this.labelMapsUsed.Name = "labelMapsUsed";
            this.labelMapsUsed.Size = new System.Drawing.Size(195, 25);
            this.labelMapsUsed.TabIndex = 11;
            this.labelMapsUsed.Text = "Number Of Maps:";
            // 
            // buttonEndTurn
            // 
            this.buttonEndTurn.BackColor = System.Drawing.Color.Tomato;
            this.buttonEndTurn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEndTurn.ForeColor = System.Drawing.Color.White;
            this.buttonEndTurn.Location = new System.Drawing.Point(264, 548);
            this.buttonEndTurn.Name = "buttonEndTurn";
            this.buttonEndTurn.Size = new System.Drawing.Size(250, 58);
            this.buttonEndTurn.TabIndex = 12;
            this.buttonEndTurn.Text = "End Turn";
            this.buttonEndTurn.UseVisualStyleBackColor = false;
            this.buttonEndTurn.Click += new System.EventHandler(this.buttonEndTurn_Click);
            // 
            // labelPlayer1Value
            // 
            this.labelPlayer1Value.AutoSize = true;
            this.labelPlayer1Value.BackColor = System.Drawing.Color.Transparent;
            this.labelPlayer1Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayer1Value.Location = new System.Drawing.Point(119, 24);
            this.labelPlayer1Value.Name = "labelPlayer1Value";
            this.labelPlayer1Value.Size = new System.Drawing.Size(72, 25);
            this.labelPlayer1Value.TabIndex = 13;
            this.labelPlayer1Value.Text = "Value";
            // 
            // labelPlayer2Value
            // 
            this.labelPlayer2Value.AutoSize = true;
            this.labelPlayer2Value.BackColor = System.Drawing.Color.Transparent;
            this.labelPlayer2Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayer2Value.Location = new System.Drawing.Point(1162, 24);
            this.labelPlayer2Value.Name = "labelPlayer2Value";
            this.labelPlayer2Value.Size = new System.Drawing.Size(72, 25);
            this.labelPlayer2Value.TabIndex = 14;
            this.labelPlayer2Value.Text = "Value";
            // 
            // buttonSell
            // 
            this.buttonSell.BackColor = System.Drawing.Color.Tomato;
            this.buttonSell.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSell.ForeColor = System.Drawing.Color.White;
            this.buttonSell.Location = new System.Drawing.Point(520, 548);
            this.buttonSell.Name = "buttonSell";
            this.buttonSell.Size = new System.Drawing.Size(250, 58);
            this.buttonSell.TabIndex = 15;
            this.buttonSell.Text = "Sell";
            this.buttonSell.UseVisualStyleBackColor = false;
            this.buttonSell.Click += new System.EventHandler(this.buttonSell_Click);
            // 
            // labelCurrentSell
            // 
            this.labelCurrentSell.AutoSize = true;
            this.labelCurrentSell.BackColor = System.Drawing.Color.Transparent;
            this.labelCurrentSell.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrentSell.ForeColor = System.Drawing.Color.White;
            this.labelCurrentSell.Location = new System.Drawing.Point(12, 647);
            this.labelCurrentSell.Name = "labelCurrentSell";
            this.labelCurrentSell.Size = new System.Drawing.Size(195, 25);
            this.labelCurrentSell.TabIndex = 16;
            this.labelCurrentSell.Text = "Current Sell Item:";
            // 
            // labelCurrentSellNumber
            // 
            this.labelCurrentSellNumber.AutoSize = true;
            this.labelCurrentSellNumber.BackColor = System.Drawing.Color.Transparent;
            this.labelCurrentSellNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrentSellNumber.ForeColor = System.Drawing.Color.White;
            this.labelCurrentSellNumber.Location = new System.Drawing.Point(339, 647);
            this.labelCurrentSellNumber.Name = "labelCurrentSellNumber";
            this.labelCurrentSellNumber.Size = new System.Drawing.Size(190, 25);
            this.labelCurrentSellNumber.TabIndex = 17;
            this.labelCurrentSellNumber.Text = "Number of Items:";
            // 
            // GameTime
            // 
            this.GameTime.Tick += new System.EventHandler(this.GameTime_Tick);
            // 
            // labelPulled
            // 
            this.labelPulled.AutoSize = true;
            this.labelPulled.BackColor = System.Drawing.Color.Transparent;
            this.labelPulled.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPulled.ForeColor = System.Drawing.Color.White;
            this.labelPulled.Location = new System.Drawing.Point(655, 647);
            this.labelPulled.Name = "labelPulled";
            this.labelPulled.Size = new System.Drawing.Size(142, 25);
            this.labelPulled.TabIndex = 18;
            this.labelPulled.Text = "Card Pulled:";
            // 
            // labelMarket
            // 
            this.labelMarket.AutoSize = true;
            this.labelMarket.BackColor = System.Drawing.Color.Transparent;
            this.labelMarket.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMarket.Location = new System.Drawing.Point(245, 89);
            this.labelMarket.Name = "labelMarket";
            this.labelMarket.Size = new System.Drawing.Size(91, 25);
            this.labelMarket.TabIndex = 19;
            this.labelMarket.Text = "Market:";
            // 
            // labelDigSite
            // 
            this.labelDigSite.AutoSize = true;
            this.labelDigSite.BackColor = System.Drawing.Color.Transparent;
            this.labelDigSite.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDigSite.Location = new System.Drawing.Point(696, 89);
            this.labelDigSite.Name = "labelDigSite";
            this.labelDigSite.Size = new System.Drawing.Size(95, 25);
            this.labelDigSite.TabIndex = 20;
            this.labelDigSite.Text = "DigSite:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1264, 24);
            this.menuStrip1.TabIndex = 21;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.newToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save...";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadToolStripMenuItem.Text = "Load...";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playersToolStripMenuItem,
            this.playerVsComputerToolStripMenuItem,
            this.computerVsComputerToolStripMenuItem,
            this.computerVs2ComputerToolStripMenuItem,
            this.playerVs2ComputerToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newToolStripMenuItem.Text = "New...";
            // 
            // playersToolStripMenuItem
            // 
            this.playersToolStripMenuItem.Name = "playersToolStripMenuItem";
            this.playersToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.playersToolStripMenuItem.Text = "2 Players";
            this.playersToolStripMenuItem.Click += new System.EventHandler(this.playersToolStripMenuItem_Click);
            // 
            // playerVsComputerToolStripMenuItem
            // 
            this.playerVsComputerToolStripMenuItem.Name = "playerVsComputerToolStripMenuItem";
            this.playerVsComputerToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.playerVsComputerToolStripMenuItem.Text = "Player Vs Computer";
            this.playerVsComputerToolStripMenuItem.Click += new System.EventHandler(this.playerVsComputerToolStripMenuItem_Click);
            // 
            // computerVsComputerToolStripMenuItem
            // 
            this.computerVsComputerToolStripMenuItem.Name = "computerVsComputerToolStripMenuItem";
            this.computerVsComputerToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.computerVsComputerToolStripMenuItem.Text = "Computer Vs Computer";
            this.computerVsComputerToolStripMenuItem.Click += new System.EventHandler(this.computerVsComputerToolStripMenuItem_Click);
            // 
            // computerVs2ComputerToolStripMenuItem
            // 
            this.computerVs2ComputerToolStripMenuItem.Name = "computerVs2ComputerToolStripMenuItem";
            this.computerVs2ComputerToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.computerVs2ComputerToolStripMenuItem.Text = "3 Players";
            this.computerVs2ComputerToolStripMenuItem.Click += new System.EventHandler(this.computerVs2ComputerToolStripMenuItem_Click);
            // 
            // playerVs2ComputerToolStripMenuItem
            // 
            this.playerVs2ComputerToolStripMenuItem.Name = "playerVs2ComputerToolStripMenuItem";
            this.playerVs2ComputerToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.playerVs2ComputerToolStripMenuItem.Text = "Player Vs 2 Computer";
            this.playerVs2ComputerToolStripMenuItem.Click += new System.EventHandler(this.playerVs2ComputerToolStripMenuItem_Click);
            // 
            // PVC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.BackgroundImage = global::Assignment_2___PreAlpha.Properties.Resources.TableTexture;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.labelDigSite);
            this.Controls.Add(this.labelMarket);
            this.Controls.Add(this.labelPulled);
            this.Controls.Add(this.labelCurrentSellNumber);
            this.Controls.Add(this.labelCurrentSell);
            this.Controls.Add(this.buttonSell);
            this.Controls.Add(this.labelPlayer2Value);
            this.Controls.Add(this.labelPlayer1Value);
            this.Controls.Add(this.buttonEndTurn);
            this.Controls.Add(this.labelMapsUsed);
            this.Controls.Add(this.labelMarketTrade);
            this.Controls.Add(this.labelPlayerTrade);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonTrade);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelPlayer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PVC";
            this.Text = "PVC";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PVP_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PVP_MouseClick);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelPlayer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonTrade;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelPlayerTrade;
        private System.Windows.Forms.Label labelMarketTrade;
        private System.Windows.Forms.Label labelMapsUsed;
        private System.Windows.Forms.Button buttonEndTurn;
        private System.Windows.Forms.Label labelPlayer1Value;
        private System.Windows.Forms.Label labelPlayer2Value;
        private System.Windows.Forms.Button buttonSell;
        private System.Windows.Forms.Label labelCurrentSell;
        private System.Windows.Forms.Label labelCurrentSellNumber;
        private System.Windows.Forms.Timer GameTime;
        private System.Windows.Forms.Label labelPulled;
        private System.Windows.Forms.Label labelMarket;
        private System.Windows.Forms.Label labelDigSite;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playerVsComputerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem computerVsComputerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem computerVs2ComputerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playerVs2ComputerToolStripMenuItem;
    }
}