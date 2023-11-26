using System.Data;

namespace day6
{
    public class Day6Challenge
    {
        public void Run()
        {
            var gridSize = 1000;
            var (grid, brightnessGrid) = GetGridResults();
            var noOfLitLights = CountGrid(grid, gridSize);
            var brightnessTotal = CountBrightness(brightnessGrid, gridSize);
            // count lightgrid
            Console.WriteLine(noOfLitLights + " lights are lit.");
            Console.WriteLine("Total brightness of those lights is: " + brightnessTotal);
        }



        public (int[,], int[,]) GetGridResults()
        {
            using var sr = new StreamReader("input.txt");
            var grid = CreateGrid(1000);
            var brightnessGrid = CreateGrid(1000);
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                //decode text
                (grid, brightnessGrid) = LightGrid(grid, line, brightnessGrid);
            }
            return (grid, brightnessGrid);
        }

        public int[,] CreateGrid(int gridSize)
        {
            //initialize
            var fromRows = 0;
            var toRows = gridSize;
            var fromCols = 0;
            var toCols = gridSize;

            int[,] grid = new int[toRows, toCols];

            for (int i = fromRows; i < toRows; i++)
            {
                for (int j = fromCols; j < toCols; j++)
                {
                    grid[i, j] = 0;
                }
            }
            return grid;
        }

        public (int[,], int[,]) LightGrid(int[,] grid, string? line, int[,] brightnessGrid)
        {
            var splitLine = line.Split(' ');
            string from;
            string to;
            if (line.StartsWith("turn on"))
            {
                from = splitLine[2];
                to = splitLine[4];
                (grid, brightnessGrid) = Light(grid, from, to, "on", brightnessGrid);
            }
            else if (line.StartsWith("turn off"))
            {
                from = splitLine[2];
                to = splitLine[4];
                (grid, brightnessGrid) = Light(grid, from, to, "off", brightnessGrid);
            }
            else
            {
                from = splitLine[1];
                to = splitLine[3];
                (grid, brightnessGrid) = Light(grid, from, to, "toggle", brightnessGrid);
            }

            return (grid, brightnessGrid);
        }
        private (int[,], int[,]) Light(int[,] grid, string from, string to, string lightCase, int[,] brightnessGrid)
        {
            var fromRows = int.Parse(from.Split(',')[0]);
            var fromCols = int.Parse(from.Split(',')[1]);
            var toRows = int.Parse(to.Split(',')[0]);
            var toCols = int.Parse(to.Split(',')[1]);
            return EditGrid(grid, fromRows, toRows, fromCols, toCols, lightCase, brightnessGrid);
        }

        private static (int[,], int[,]) EditGrid(int[,] grid, int fromRows, int toRows, int fromCols, int toCols, string lightCase, int[,] brightnessGrid)
        {
            for (int i = fromRows; i <= toRows; i++)
            {
                for (int j = fromCols; j <= toCols; j++)
                {
                    switch (lightCase)
                    {
                        case "on":
                            brightnessGrid[i, j]++;
                            grid[i, j] = 1;
                            break;
                        case "off":
                            if (brightnessGrid[i, j] >= 1)
                            {
                                brightnessGrid[i, j]--;
                            }
                            grid[i, j] = 0;
                            break;
                        case "toggle":
                            brightnessGrid[i, j] += 2;
                            if (grid[i, j] == 1)
                            {
                                grid[i, j] = 0;
                            }
                            else
                            {
                                grid[i, j] = 1;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            return (grid, brightnessGrid);
        }

        public int CountGrid(int[,] grid, int gridSize)
        {
            var count = 0;
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    if (grid[i,j] == 1)
                    {                        
                        count++;
                    }
                }
            }
            return count;

        }

        public int CountBrightness(int[,] brightnessGrid, int gridSize)
        {
            var count = 0;
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    count += brightnessGrid[i, j];
                }
            }
            return count;
        }






    }
}
