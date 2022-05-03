namespace ProjectEuler
{
    public static class PandigitalNumbers
    {
        private static readonly HashSet<int> pandigitals;

        static PandigitalNumbers()
        {
            pandigitals = new HashSet<int>();
        }

        public static bool IsPandigital(int number)
        {
            if (pandigitals.Contains(number))
            {
                return true;
            }
            HashSet<int> digits = new HashSet<int>();
            int num = number;
            while (num >= 1)
            {
                // If any digits are duplicated this will return false since that means it isn't a pandigital number
                if (!digits.Add(num % 10))
                {
                    return false;
                }
                num /= 10;
            }
            // The digits should be <= the count and nonzero in order for the number to be pandigital
            if (digits.Any(d => d == 0 || d > digits.Count()))
            {
                return false;
            }
            pandigitals.Add(number);
            return true;
        }
    }
}