namespace ProjectEuler
{
    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine(FibonacciNumbers.FindNth(1000));
        }

        private static int Problem41()
        {
            for (int i = 100000001; i < 987654321; i += 2)
            {
                if (PandigitalNumbers.IsPandigital(i) && Primes.IsPrime(i))
                {
                    return i;
                }
            }
            return 0;
        }
    }
}