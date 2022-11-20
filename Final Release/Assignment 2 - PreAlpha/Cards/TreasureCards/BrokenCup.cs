using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Assignment_2___PreAlpha
{
    internal class BrokenCup : TreasureCard
    {
        private static int[] setValueArray = new int[] { 2, 15 };

        public BrokenCup(bool flipstate, int x, int y) : base(flipstate, x, y)
        {

        }

        public override void Draw(Graphics paper)
        {
            if (flipstate)
            {
                paper.DrawImage(Properties.Resources.cup, x, y, width, height);
            }
            else
            {
                paper.DrawImage(Properties.Resources.cardback, x, y, width, height);
            }
        }

        public override int[] SetValueArray
        {
            get { return setValueArray; }
        }
    }
}
