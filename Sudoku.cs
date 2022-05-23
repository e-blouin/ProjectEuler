namespace ProjectEuler
{
    public class Sudoku
    {
        public Sudoku(string grid)
        {
            string[] values = grid.Split();
        }
    }

    public class Tile
    {
        private static int row;
        private static int column;
        private static int square;
        private static int value;
        private Tile(int val, int index)
        {
            value = val;
        }
    }
}