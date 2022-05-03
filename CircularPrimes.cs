// Project Euler number 35: https://projecteuler.net/problem=35

namespace ProjectEuler
{
    public static class CircularPrimes
    {
        private static readonly HashSet<int> circularPrimesSet;

        static CircularPrimes()
        {
            circularPrimesSet = new HashSet<int> { 2 };
        }
        public static int CountBelow(int limit)
        {
            for (int i = 3; i < limit; i += 2)
            {
                if (Primes.IsPrime(i))
                {
                    ValidateRotations(i);
                }
            }
            return circularPrimesSet.Count();
        }

        private static void ValidateRotations(int prime)
        {
            List<int> digits = GetDigits(prime);
            HashSet<int> rotations = new HashSet<int> { GetNumber(digits) };
            for (int i = 0; i < digits.Count(); i++)
            {
                int hold = digits.First();
                digits.RemoveAt(0);
                digits.Add(hold);
                int number = GetNumber(digits);
                if (!Primes.IsPrime(number))
                {
                    return;
                }
                rotations.Add(number);
            }
            // Build each rotation and validate that it is prime. If it isn't, return

            circularPrimesSet.UnionWith(rotations);
        }

        private static List<int> GetDigits(int number)
        {
            List<int> digits = new List<int>();
            while (number >= 1)
            {
                digits.Add(number % 10);
                number /= 10;
            }
            digits.Reverse();
            return digits;
        }

        private static int GetNumber(List<int> digits)
        {
            int number = 0;
            foreach (int digit in digits)
            {
                number = number * 10 + digit;
            }
            return number;
        }
    }
}