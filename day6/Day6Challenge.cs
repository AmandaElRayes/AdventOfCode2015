using System.Data;

namespace day6
{
    public class Day6Challenge
    {
        public void Run()
        {
            var grid = ReadTxt();
            var noOfLitLights = CountGrid(grid, 1000);
            Console.WriteLine(noOfLitLights + " lights are lit.");
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

        private static (int[,], int) EditGrid(int[,] grid, int fromRows, int toRows, int fromCols, int toCols, string lightCase, int brightness)
        {
            for (int i = fromRows; i <= toRows; i++)
            {
                for (int j = fromCols; j <= toCols; j++)
                {
                    switch (lightCase)
                    {
                        case "on":
                            brightness++;
                            grid[i, j] = 1;
                            break;
                        case "off":
                            if(brightness >= 1)
                            {
                                brightness--;
                            }
                            
                            grid[i, j] = 0;
                            break;
                        case "toggle":
                            brightness += 2;
                            if (grid[i,j] == 1)
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
            return (grid, brightness);
        }

        public int[,] ReadTxt()
        {
            using var sr = new StreamReader("input.txt");
            var grid = CreateGrid(1000);
            var brightness = 0;
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                //decode text
                (grid, brightness) = LightGrid(grid, line, brightness);
            }
            Console.WriteLine("Brightness: " + brightness);
            return grid;
        }
         
        public (int[,], int) LightGrid(int[,] grid, string? line, int brightness)
        {
            var splitLine = line.Split(' ');
            string from;
            string to;
            if (line.StartsWith("turn on"))
            {
                from = splitLine[2];
                to = splitLine[4];
                (grid, brightness) = Light(grid, from, to, "on", brightness);
            }
            else if (line.StartsWith("turn off"))
            {
                from = splitLine[2];
                to = splitLine[4];
                (grid, brightness) = Light(grid, from, to, "off", brightness);
            }
            else
            {
                from = splitLine[1];
                to = splitLine[3];
                (grid, brightness) = Light(grid, from, to, "toggle", brightness);
            }

            return (grid, brightness);
        }

        private (int[,], int) Light(int[,] grid, string from, string to, string lightCase, int brightness)
        {
            var fromRows = int.Parse(from.Split(',')[0]);
            var fromCols = int.Parse(from.Split(',')[1]);
            var toRows = int.Parse(to.Split(',')[0]);
            var toCols = int.Parse(to.Split(',')[1]);
            return EditGrid(grid, fromRows, toRows, fromCols, toCols, lightCase, brightness);
        }
    }
}
