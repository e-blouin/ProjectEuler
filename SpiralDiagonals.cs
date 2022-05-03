namespace ProjectEuler
{
    /// <summary>
    /// Handler for #28: https://projecteuler.net/problem=28
    ///</summary>
    public static class SpiralDiagonals
    {
        ///<summary>
        ///Determines the sum of the diagonals in a number spiral with the given dimensions
        ///<summary>
        public static int Calculate(int dimension)
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

    }
}