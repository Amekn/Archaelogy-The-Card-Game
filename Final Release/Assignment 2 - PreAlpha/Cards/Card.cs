using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Assignment_2___PreAlpha
{
    /// <summary>
    /// Createing a card object.
    /// Including location information (x, y), height and weight, and flipstate.
    /// </summary>
    public abstract class Card
    {

        /// <summary>
        /// The current x posiition of the card.
        /// </summary>
        protected int x;

        /// <summary>
        /// The current y position of the card.
        /// </summary>
        protected int y;

        public const int width = 100;
        public const int height = 166;

        /// <summary>
        /// Record the current flip state of the card
        /// </summary>
        protected bool flipstate;

        /// <summary>
        /// Set the initial card flip state
        /// </summary>
        /// <param name="flipstate"></param>
        public Card(bool flipstate, int x, int y)
        {
            this.flipstate = flipstate;
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Readonly return of value stored in x.
        /// </summary>
        public int X
        { get { return x; } }

        /// <summary>
        /// Readonly return of value stored in y.
        /// </summary>
        public int Y
        {
            get { return y; }
        }
        /// <summary>
        /// Control used to flip a card.
        /// </summary>
        public bool FlipState
        {
            get { return flipstate; }
            set { flipstate = value; }
        }

        /// <summary>
        /// Drawing the card
        /// </summary>
        /// <param name="paper"></param>
        public abstract void Draw(Graphics paper);

        /// <summary>
        /// Moving the card to a different location.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Move(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Return if a card has been click on or not. 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool IsMouseOn(int x, int y)//Reserve
        {
            if (this.x <= x && x < this.x + width
                && this.y <= y && y < this.y + height)
                return true;
            else
                return false;
        }

        public string SaveToCSV()
        {
            return $"{this.ToString()},{flipstate},{X},{Y}";
            //e.g. Coin, true, 1223, 2313
        }

        /// <summary>
        /// Print out the name of the card, only children class name included.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}
