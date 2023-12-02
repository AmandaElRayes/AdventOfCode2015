namespace day3
{
    public class Challenge3
    {

        public string ReadFile()
        {
            //return "^^<<v<<v><v^^<><>";
            return "^>v";
        }
        public int RunMain()
        {
            string s = ReadFile();
            int noOfHouses = GetNoOfHousesFromString(s);
            Console.WriteLine("Number of houses passed: " + noOfHouses);

            return noOfHouses;
        }

        public int GetNoOfHousesFromString(string s)
        {
            var matrix = CreateMatrix(s);
            Console.WriteLine("---------------Result--------------------------");
            PrintMatrix(matrix);
            var noOfHouses = CalculateNoOfHouses(matrix);
            return noOfHouses;
        }

        public int CalculateNoOfHouses(List<List<int>> matrix)
        {
            var count = 0;
            foreach (var list in matrix)
            {
                foreach (var item in list)
                {
                    if (item != 0)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        private static void PrintMatrix(List<List<int>> matrix)
        {
            foreach (var column in matrix)
            {
                foreach (var element in column)
                {
                    Console.Write(element);
                }
                Console.WriteLine("\n");
            }
        }

        public List<List<int>> CreateMatrix(string s)
        {
            var matrix = InitMatrix();
            var rowIndex = 0;
            var columnIndex = 0;
            foreach (char element in s)
            {
                Console.WriteLine(element.ToString());
                switch (element.ToString())
                {
                    case "^":
                        (matrix, rowIndex, columnIndex) = CaseUp(matrix, rowIndex, columnIndex);
                        break;
                    case "<":
                        (matrix, rowIndex, columnIndex) = CaseLeft(matrix, rowIndex, columnIndex);
                        break;
                    case "v":
                        (matrix, rowIndex, columnIndex) = CaseDown(matrix, rowIndex, columnIndex);
                        break;
                    case ">":
                        (matrix, rowIndex, columnIndex) = CaseRight(matrix, rowIndex, columnIndex);
                        break;
                    default:
                        Console.WriteLine("Error: should not end up here.");
                        break;
                }
                PrintMatrix(matrix);
            }
            return matrix;
        }

        public List<List<int>> InitMatrix()
        {
            var matrix = new List<List<int>>();
            var column = new List<int>
            {
                -1
            };
            matrix.Add(column);

            return matrix;
        }

        public bool IsMatrixIndexValid(int rowindex, int colindex, List<List<int>> matrix)
        {
            if (colindex <= matrix.Count)
            {
                if (rowindex <= matrix[colindex].Count)
                {
                    return true;
                }
                return false;
            }
            return false;
        }


        public (List<List<int>>, int, int) CaseUp(List<List<int>> matrix, int rowIndex, int columnIndex)
        {
            if (rowIndex > 0)
            {
                rowIndex--;
            }
            matrix.Insert(0, new List<int>());
            matrix[0].Add(1);

            return (matrix, rowIndex, columnIndex);
        }

        public (List<List<int>>, int, int) CaseDown(List<List<int>> matrix, int rowIndex, int columnIndex)
        {
            rowIndex++;
            var rowCount = 0;
            foreach (var row in matrix[columnIndex])
            {
                if (rowCount == rowIndex)
                {
                    Console.WriteLine(row.ToString());
                    matrix[columnIndex].Add(1);
                }
                else
                {
                    matrix[columnIndex].Add(0);
                }

                rowCount++;
            }


            return (matrix, rowIndex, columnIndex);
        }

        public (List<List<int>>, int, int) CaseLeft(List<List<int>> matrix, int rowIndex, int columnIndex)
        {
            if (columnIndex > 0)
            {
                columnIndex--;
            }
            foreach (var column in matrix)
            {
                column.Add(1);
            }

            return (matrix, rowIndex, columnIndex);
        }



        public (List<List<int>>, int, int) CaseRight(List<List<int>> matrix, int rowIndex, int columnIndex)
        {
            var colCount = 0;
            foreach (var column in matrix)
            {
                if (colCount == columnIndex)
                {
                    column.Add(1);
                }
                else
                {
                    column.Add(0);
                }
                colCount++;
            }
            columnIndex++;

            return (matrix, rowIndex, columnIndex);
        }

    }
}
