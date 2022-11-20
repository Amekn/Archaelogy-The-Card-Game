using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Assignment_2___PreAlpha
{
    internal class Maps : TreasureCard
    {
        public static readonly int[] setValueArray = new int[] { 3 };
        public Maps(bool flipstate, int x, int y) : base(flipstate, x, y)
        {

        }

        public override void Draw(Graphics paper)
        {
            if (flipstate)
            {
                paper.DrawImage(Properties.Resources.map, x, y, width, height);
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
