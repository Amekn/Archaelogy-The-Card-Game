using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Assignment_2___PreAlpha
{
    internal class Pharaoh_sMask : TreasureCard
    {
        public static readonly int[] setValueArray = new int[] { 4, 12, 26, 50 };
        public Pharaoh_sMask(bool flipstate, int x, int y) : base(flipstate, x, y)
        {

        }

        public override void Draw(Graphics paper)
        {
            if (flipstate)
            {
                paper.DrawImage(Properties.Resources.mask, x, y, width, height);
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
