namespace ProjectEuler
{
    public static class FibonacciNumbers
    {
        public static int FindNth(int n)
        {
            List<int> fibs = new List<int> { 1, 1 };
            // Since we've already seeded this with the first 2, we start at n>2
            while (n > 2)
            {
                fibs[0] += fibs[1];
                fibs.Sort();
                n--;
            }
            return fibs[1];
        }
    }
}