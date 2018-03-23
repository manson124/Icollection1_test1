using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icollection1_test11
{
    public class Box: IEquatable<Box>
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }

        public Box(int height, int width, int lenth)
        {
            this.Height = height;
            this.Width = width;
            this.Length = Length;
        }

        // Defines equality using the
        // BoxSameDimensions equality comparer.
        public bool Equals(Box other)
        {
            if (new BoxSameDimensions().Equals(this, other))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();

        }
    }
}
