 public class Solution
    {

        public int NumIslands(char[,] grid)
        {
            int marker = 0;
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (isLand(grid, i, j))
                    {
                        markNeighbour(grid, i, j);

                        marker++;
                    }
                }
            }

            Console.WriteLine(marker);
            return marker;
        }

        public static bool isLand(char[,] grid, int i, int j)
        {
            return grid[i, j] == '1';
        }

        public static void markNeighbour(char[,] grid, int i, int j)
        {
            if (grid[i, j] == '0')
            {
                return;
            }

            grid[i, j] = '0';
            Console.Write(string.Format("{0} {1}; ", i, j));

            if (i - 1 >= 0 && grid[i - 1, j] == '1')
            {
                markNeighbour(grid, i - 1, j);
            }
            if (i < grid.GetLength(0) - 1 && grid[i + 1, j] == '1')
            {
                markNeighbour(grid, i + 1, j);
            }
            if (j < grid.GetLength(1) - 1 && grid[i, j + 1] == '1')
            {
                markNeighbour(grid, i, j + 1);
            }
            if (j - 1 >= 0 && grid[i, j - 1] == '1')
            {
                markNeighbour(grid, i, j - 1);
            }
        }
    }
