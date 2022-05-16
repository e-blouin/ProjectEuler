namespace ProjectEuler
{
    /// <summary>
    /// Handler for #28: https://projecteuler.net/problem=28
    ///</summary>
    public static class Spirals
    {
        ///<summary>
        ///Determines the sum of the diagonals in a number spiral with the given dimensions
        ///<summary>
        public static int CalculateDiagonalSum(int dimension)
        {
            if (dimension == 1)
            {
                return 1;
            }
            if (dimension % 2 == 0)
            {
                throw new ArgumentException($"Dimension of the cube must be an odd number for this calculation. Received: {dimension}");
            }
            int sum = 1;
            for (int i = 3; i <= dimension; i += 2)
            {
                sum += 4 * (i * i) - 6 * (i - 1);
            }
            return sum;
        }

        ////<summary>
        ////Returns the side length when the ratio of prime numbers to all numbers on the diagonal falls below the percent passed in
        ////<summary
        public static int GetSideLengthForPrimeRatio(int percent)
        {
            int ratio = 100;
            int dimension = 3;
            double primeDiagonals = 3;
            while (ratio > percent)
            {
                dimension += 2;
                primeDiagonals += PrimeDiagonalCount(dimension);
                ratio = (int)Math.Ceiling(primeDiagonals * 100/ (dimension * 2 - 1));
            }
            return dimension;
        }

        private static List<int> GetDiagonals(int dimension)
        {
            if (dimension % 2 == 0)
            {
                throw new System.Exception("Spirals cannot have dimensions that are even");
            }
            if (dimension == 1)
            {
                return new List<int>{1};
            }
            List<int> diagonals = new List<int>();
            int square = dimension * dimension;
            for (int i = 0; i < 4; i++)
            {
                diagonals.Add(square - (i * (dimension - 1)));
            }
            return diagonals;
        }

        private static int PrimeDiagonalCount(int dimension)
        {
            if (dimension % 2 == 0)
            {
                throw new System.Exception("Spirals cannot have dimensions that are even");
            }
            if (dimension == 1)
            {
                return 0;
            }
            int square = dimension * dimension;
            int primeDiagonals = 0;
            for (int i = 0; i < 4; i++)
            {
                if(Primes.IsPrimeCached(square - (i * (dimension - 1))))
                {
                    primeDiagonals++;
                }
            }
            return primeDiagonals;
        }
    }
}