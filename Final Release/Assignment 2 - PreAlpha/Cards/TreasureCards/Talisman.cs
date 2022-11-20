using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Assignment_2___PreAlpha
{
    internal class Talisman : TreasureCard
    {
        public static readonly int[] setValueArray = new int[] { 3, 7, 14, 24, 40 };
        public Talisman(bool flipstate, int x, int y) : base(flipstate, x, y)
        {

        }

        public override void Draw(Graphics paper)
        {
            if (flipstate)
            {
                paper.DrawImage(Properties.Resources.talisman, x, y, width, height);
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
