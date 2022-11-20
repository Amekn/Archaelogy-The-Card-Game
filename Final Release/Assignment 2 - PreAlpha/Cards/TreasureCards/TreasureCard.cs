using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Assignment_2___PreAlpha
{
    internal abstract class TreasureCard : Card
    {
        /// <summary>
        /// Used to locate the value of a particular treasure.
        /// Index of treasure can be found using Enum in TreasureeValueEnum.cs
        /// </summary>
        public static int[] TreasureValueArray = {4, 3, 3, 2, 2, 1, 1 };

        public TreasureCard(bool flipstate, int x, int y) : base(flipstate, x, y)
        {

        }

        public abstract int[] SetValueArray
        {
            get;
        }
    }
}
