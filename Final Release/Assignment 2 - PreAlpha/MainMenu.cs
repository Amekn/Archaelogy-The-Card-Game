using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_2___PreAlpha
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        public static void button2Player_Click(object sender, EventArgs e)
        {
            Match match = new Match(2);
            PVC pvc = new PVC(match);
            match.DeckHeightAjustMent = 50;
            pvc.Match.Players[0] = new Person(new Deck(20, pvc.Match.DeckHeightAjustMent), 0, 0, pvc.Match);
            pvc.Match.Players[1] = new Person(new Deck(pvc.Width - Card.width - 40, pvc.Match.DeckHeightAjustMent), 0, 0, pvc.Match);
            pvc.Text = "PVP";
            pvc.Initialisation();
            pvc.Show();
        }

        public static void buttonPlayerVSComputer_Click(object sender, EventArgs e)
        {
            Match match = new Match(2);
            PVC pvc = new PVC(match);
            match.DeckHeightAjustMent = 50;
            pvc.Match.Players[0] = new Person(new Deck(20, pvc.Match.DeckHeightAjustMent), 0, 0, pvc.Match);
            pvc.Match.Players[1] = new Robot(new Deck(pvc.Width - Card.width - 40, pvc.Match.DeckHeightAjustMent), 0, 0, pvc.Match);
            pvc.Initialisation();
            pvc.Show();
        }

        public static void buttonComputerVSComputer_Click(object sender, EventArgs e)
        {
            Match match = new Match(2);
            PVC pvc = new PVC(match);
            match.DeckHeightAjustMent = 50;
            pvc.Match.Players[0] = new Robot(new Deck(20, pvc.Match.DeckHeightAjustMent), 0, 0, pvc.Match);
            pvc.Match.Players[1] = new Robot(new Deck(pvc.Width - Card.width - 40, pvc.Match.DeckHeightAjustMent), 0, 0, pvc.Match);
            pvc.Text = "CVC";
            pvc.Initialisation();
            pvc.Show();
        }

        public static void buttonPlayerVs2Computer_Click(object sender, EventArgs e)
        {
            Match match = new Match(3);
            PVPP pvpp = new PVPP(match);
            match.DeckHeightAjustMent = 50;
            pvpp.Match.Players[0] = new Person(new Deck(20, pvpp.Match.DeckHeightAjustMent), 0, 0, pvpp.Match);
            pvpp.Match.Players[1] = new Robot(new Deck(20, pvpp.Height - 2 * Card.height + pvpp.Match.DeckHeightAjustMent - 80), 0, 0, pvpp.Match);
            pvpp.Match.Players[1].PlayerDeck.Orientation = "Horizontal";
            pvpp.Match.Players[2] = new Robot(new Deck(pvpp.Width - Card.width - 40, pvpp.Match.DeckHeightAjustMent), 0, 0, pvpp.Match);
            pvpp.Text = "PVCC";
            pvpp.Initialisation();
            pvpp.Show();
        }

        public static void button3Player_Click(object sender, EventArgs e)
        {
            Match match = new Match(3);
            PVPP pvpp = new PVPP(match);
            match.DeckHeightAjustMent = 50;
            pvpp.Match.Players[0] = new Person(new Deck(20, pvpp.Match.DeckHeightAjustMent), 0, 0, pvpp.Match);
            pvpp.Match.Players[1] = new Person(new Deck(20, pvpp.Height - 2 * Card.height + pvpp.Match.DeckHeightAjustMent - 80), 0, 0, pvpp.Match);
            pvpp.Match.Players[1].PlayerDeck.Orientation = "Horizontal";
            pvpp.Match.Players[2] = new Person(new Deck(pvpp.Width - Card.width - 40, pvpp.Match.DeckHeightAjustMent), 0, 0, pvpp.Match);
            pvpp.Initialisation();
            pvpp.Show();
        }

        private static void loadToolStripMenuItem_Click(object sender, EventArgs e)
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
    }
}
