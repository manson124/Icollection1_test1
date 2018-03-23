using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icollection1_test11
{
    // Defines two boxes as equal if they have the same dimensions.
    public class BoxSameDimensions : EqualityComparer<Box>
    {

        public override bool Equals(Box b1, Box b2)
        {
            if (b1.Height == b2.Height && b1.Length == b2.Length
                                && b1.Width == b2.Width)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode(Box bx)
        {
            int hCode = bx.Height ^ bx.Length ^ bx.Width;
            return hCode.GetHashCode();
        }

    }

}
