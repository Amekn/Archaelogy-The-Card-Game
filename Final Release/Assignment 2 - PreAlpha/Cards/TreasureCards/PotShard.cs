using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Assignment_2___PreAlpha
{
    internal class PotShard : TreasureCard
    {
        public static readonly int[] setValueArray = new int[] { 1, 2, 3, 4, 15 };
        public PotShard(bool flipstate, int x, int y) : base(flipstate, x, y)
        {

        }

        public override void Draw(Graphics paper)
        {
            if (flipstate)
            {
                paper.DrawImage(Properties.Resources.shard, x, y, width, height);
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
