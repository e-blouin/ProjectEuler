namespace ProjectEuler
{
    public static class Squares
    {
        public static int SumSquareDifference(int limit)
        {
            int sumSquares = 0;
            int squareSum = 0;
            for(int i = 1; i <= limit; i++)
            {
                sumSquares += (int)Math.Pow(i, 2);
                squareSum += i;
            }
            return (int)Math.Pow(squareSum,2) - sumSquares;
        }
    }
}