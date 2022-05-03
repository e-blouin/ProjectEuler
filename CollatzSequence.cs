namespace ProjectEuler
{
    public static class CollatzSequence
    {
        static Dictionary<int, int> collatzSequences;

        public static Dictionary<int, int> CollatzSequences { get => collatzSequences; set => collatzSequences = value; }

        static CollatzSequence()
        {
            collatzSequences = new Dictionary<int, int>();
        }

        public static int FindLargest(int limit)
        {
            int val = 1;
            int longest = 1;
            int largest = 1;
            while (val < limit)
            {
                int length = GetSequenceLength(val);
                if (length >= longest)
                {
                    longest = length;
                    largest = val;
                }
                val++;
            }
            return largest;
        }

        private static int GetSequenceLength(int num)
        {
            int counter = 0;
            int val = num;
            while (val > 1)
            {
                if (CollatzSequences.TryGetValue(val, out int value))
                {
                    int total = counter + value;
                    CollatzSequences.TryAdd(num, total);
                    return total;
                }
                val = val % 2 == 0 ? HandleEven(val) : HandleOdd(val);
                counter++;
            }
            CollatzSequences.TryAdd(num, counter);
            return counter;
        }

        private static int HandleOdd(int num)
        {
            return (3 * num + 1);
        }

        private static int HandleEven(int num)
        {
            return (num / 2);
        }
    }
}