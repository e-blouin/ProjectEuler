namespace ProjectEuler
{
    public static class Triangles
    {
        public static bool IsRightTriangle(List<int> sides)
        {
            if (sides.Count() != 3)
            {
                throw new ArgumentException("Sides must be a list of 3 integers");
            }
            sides.Sort();
            return Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2) == Math.Pow(sides[2], 2);
        }
    }
}