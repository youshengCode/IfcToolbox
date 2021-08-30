using System.Collections.Generic;

namespace IfcToolbox.Core.Utilities
{
    public static class HashCodeGenerator
    {
        public static int AdditionHashCode<T>(IEnumerable<T> source)
        {
            int hash = 0;
            foreach (var element in source)
                hash = unchecked(hash + element.GetHashCode());
            return hash;
        }

        public static int OrderIndependentHashCode<T>(IEnumerable<T> source)
        {
            int hash = 0;
            int curHash;
            int bitOffset = 0;
            // Stores number of occurences so far of each value.
            var valueCounts = new Dictionary<T, int>();

            foreach (T element in source)
            {
                curHash = EqualityComparer<T>.Default.GetHashCode(element);
                if (valueCounts.TryGetValue(element, out bitOffset))
                    valueCounts[element] = bitOffset + 1;
                else
                    valueCounts.Add(element, bitOffset);

                // The current hash code is shifted (with wrapping) one bit
                // further left on each successive recurrence of a certain
                // value to widen the distribution.
                // 37 is an arbitrary low prime number that helps the
                // algorithm to smooth out the distribution.
                hash = unchecked(hash + ((curHash << bitOffset) |
                    (curHash >> (32 - bitOffset))) * 37);
            }

            return hash;
        }
    }
}
