namespace ProjectEuler
{
    public static class Primes
    {
        private static readonly HashSet<int> primes;

        static Primes()
        {
            primes = new HashSet<int> { 2, 3 };
        }

        public static bool IsPrime(int num)
        {
            // If it's less than 2 or even it isn't prime
            if (num < 2)
            {
                return false;
            }
            // If we've already found it for a previous number it is prime
            if (primes.Contains(num))
            {
                return true;
            }
            // We only need to check if it is divisibile by prime numbers since all composite numbers
            // are the product of some combination of primes, so first we check against all the primes we've already cached
            foreach (int prime in primes)
            {
                if (num % prime == 0)
                {
                    return false;
                }
                // If any of the primes are ever higher than our input, then our input is also prime
                if (prime > num)
                {
                    return true;
                }
            }
            // Now we can start at the highest prime we've previously cached
            int i = primes.Max();
            // We only need to check for odds >= highestPrime because the modulus on line 28 will always include 2
            while (i <= Math.Sqrt(num))
            {
                if (num % i == 0)
                {
                    return false;
                }
                i += 2;
            }
            primes.Add(num);
            return true;
        }

        public static HashSet<int> GenerateNPrimes(int limit)
        {
            for (int i = 5; i < limit; i += 2)
            {
                IsPrime(i);
            }
            return primes;
        }
    }
}