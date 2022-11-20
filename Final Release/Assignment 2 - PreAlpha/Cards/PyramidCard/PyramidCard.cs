using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Assignment_2___PreAlpha
{
    internal class PyramidCard : Card
    {
        public PyramidCard(bool flipstate, int x, int y) : base(flipstate, x, y)
        {

        }

        public override void Draw(Graphics paper)
        {
            if (flipstate)
            {
                paper.DrawImage(Properties.Resources.pyramid, x, y, width, height);
            }
            else
            {
                paper.DrawImage(Properties.Resources.cardback, x, y, width, height);
            }
        }
    }
}
