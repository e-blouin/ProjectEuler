namespace ProjectEuler
{
    public static class Utils
    {
        public static readonly Dictionary<int, List<int>> factors;
        public static readonly HashSet<int> primes;
        private static readonly HashSet<int> oddComposites;
        private static readonly HashSet<int> pandigitals;
        static Utils()
        {
            primes = new HashSet<int> { 2, 3 };
            oddComposites = new HashSet<int>();
            factors = new Dictionary<int, List<int>>();
            pandigitals = new HashSet<int>();
        }

        public static bool IsPrime(int number)
        {
            if (number < 2)
            {
                return false;
            }
            if (number % 2 == 0)
            {
                return false;
            }
            if (primes.Contains(number))
            {
                return true;
            }
            if (oddComposites.Contains(number))
            {
                return false;
            }
            for (int i = 3; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    oddComposites.Add(number);
                    return false;
                }
            }
            primes.Add(number);
            return true;
        }

        public static bool IsRightTriangle(List<int> sides)
        {
            if (sides.Count() != 3)
            {
                throw new ArgumentException("Sides must be a list of 3 integers");
            }
            sides.Sort();
            return Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2) == Math.Pow(sides[2], 2);
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