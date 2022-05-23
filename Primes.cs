namespace ProjectEuler
{
    public static class Primes
    {
        public static readonly HashSet<int> primes;
        private static readonly HashSet<int> oddComposites;
        private static int highestCached;
        private static bool hasCached;

        static Primes()
        {
            primes = new HashSet<int> { 2, 3 };
            oddComposites = new HashSet<int>();
            hasCached = false;
            highestCached = 3;
        }

        public static bool IsPrimeCached(int number)
        {
            if(!hasCached)
            {
                GeneratePrimesTo(number / 2 + 1);
                return IsPrime(number);
            }
            // If it's less than 2 or even it isn't prime
            if (number < 2 || number % 2 == 0)
            {
                return false;
            }
            // If we've already found it for a previous number it is prime
            if (primes.Contains(number))
            {
                return true;
            }
            if (oddComposites.Contains(number))
            {
                return false;
            }
            if (DivisibleByPrime(number))
            {
                return false;
            }

            GeneratePrimesTo(number / 2);

            if (DivisibleByPrime(number))
            {
                return false;
            }

            primes.Add(number);
            return true;
        }

        private static bool DivisibleByPrime(int number)
        {
            // We only need to check if it is divisibile by prime numbers since all composite numbers
            // are the product of some combination of primes, so first we check against all the primes we've already cached
            foreach (int prime in primes)
            {
                if (number % prime == 0)
                {
                    oddComposites.Add(number);
                    return true;
                }
            }
            return false;
        }
        public static void GeneratePrimesTo(int limit)
        {
            for (int i = highestCached; i < limit; i += 2)
            {
                IsPrime(i);
            }
            highestCached = primes.Max();
            hasCached = true;
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

        public static HashSet<int> PrimePowerCubes(int a, int b, int c)
        {
            HashSet<int> cubes = new HashSet<int>();
            if(!IsPrime(a) || !IsPrime(b) || !IsPrime(c))
            {
                return cubes;
            }
            cubes.Add((int)(Math.Pow(a,2) + Math.Pow(b,3) + Math.Pow(c,4)));
            cubes.Add((int)(Math.Pow(a,2) + Math.Pow(c,3) + Math.Pow(b,4)));
            cubes.Add((int)(Math.Pow(b,2) + Math.Pow(a,3) + Math.Pow(c,4)));
            cubes.Add((int)(Math.Pow(b,2) + Math.Pow(c,3) + Math.Pow(a,4)));
            cubes.Add((int)(Math.Pow(c,2) + Math.Pow(a,3) + Math.Pow(b,4)));
            cubes.Add((int)(Math.Pow(c,2) + Math.Pow(b,3) + Math.Pow(a,4)));
            return cubes;
        }
    }
}