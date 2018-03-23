using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icollection1_test11
{
    public class BoxCollection : ICollection<Box>
    {
        // The generic enumerator obtained from IEnumerator<Box>
        // by GetEnumerator can also be used with the non-generic IEnumerator.
        // To avoid a naming conflict, the non-generic IEnumerable method
        // is explicitly implemented.

        public IEnumerator<Box> GetEnumerator()
        {
            return new BoxEnumerator(this);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new BoxEnumerator(this);
        }

        // The inner collection to store objects.
        private List<Box> innerCol;

        public BoxCollection()
        {
            innerCol = new List<Box>();
        }

        // Adds an index to the collection.
        public Box this[int index]
        {
            get { return (Box)innerCol[index]; }
            set { innerCol[index] = value; }
        }

        // Determines if an item is in the collection
        // by using the BoxSameDimensions equality comparer.
        public bool Contains(Box item)
        {
            bool found = false;

            foreach (Box bx in innerCol)
            {
                // Equality defined by the Box
                // class's implmentation of IEquitable<T>.
                if (bx.Equals(item))
                {
                    found = true;
                }
            }

            return found;
        }

        // Determines if an item is in the 
        // collection by using a specified equality comparer.
        public bool Contains(Box item, EqualityComparer<Box> comp)
        {
            bool found = false;

            foreach (Box bx in innerCol)
            {
                if (comp.Equals(bx, item))
                {
                    found = true;
                }
            }

            return found;
        }

        // Adds an item if it is not already in the collection
        // as determined by calling the Contains method.
        public void Add(Box item)
        {

            if (!Contains(item))
            {
                innerCol.Add(item);
            }
            else
            {
                Console.WriteLine("A box with {0}x{1}x{2} dimensions was already added to the collection.",
                    item.Height.ToString(), item.Length.ToString(), item.Width.ToString());
            }
        }

        public void Clear()
        {
            innerCol.Clear();
        }

        public void CopyTo(Box[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException("The array cannot be null.");
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException("The starting array index cannot be negative.");
            if (Count > array.Length - arrayIndex + 1)
                throw new ArgumentException("The destination array has fewer elements than the collection.");

            for (int i = 0; i < innerCol.Count; i++)
            {
                array[i + arrayIndex] = innerCol[i];
            }
        }

        public int Count
        {
            get
            {
                return innerCol.Count;
            }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(Box item)
        {
            bool result = false;

            // Iterate the inner collection to 
            // find the box to be removed.
            for (int i = 0; i < innerCol.Count; i++)
            {

                Box curBox = (Box)innerCol[i];

                if (new BoxSameDimensions().Equals(curBox, item))
                {
                    innerCol.RemoveAt(i);
                    result = true;
                    break;
                }
            }
            return result;
        }
    }
}
