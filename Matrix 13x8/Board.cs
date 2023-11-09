class Board
{
    public char[][] matrix { get; set; } = new char[][]
        {
            new char[] { '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*' },
            new char[] { 'B', '*', '*', 'B', 'B', 'B', '*', '*', '*', '*', '*', '*', '*' },
            new char[] { '*', 'B', 'B', 'X', '*', 'B', '*', '*', '*', '*', '*', '*', '*' },
            new char[] { '*', '*', '*', '*', '*', 'B', '*', '*', '*', '*', '*', '*', '*' },
            new char[] { '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*' },
            new char[] { '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*' },
            new char[] { '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*' },
            new char[] { '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*' }
        };


    public Board()
    {
    }
    public Board(char[][] inputMatrix)
    {
        matrix = inputMatrix;
    }

    public void PrintBoard()
    {
        for (int i = 0; i < 8; i++)
        {
            Console.WriteLine();
            for (int j = 0; j < 13; j++)
            {
                switch (matrix[i][j])
                {
                    case 'B':
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case 'X':
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case 'P':
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
                Console.Write(matrix[i][j] + " ");
            }
        }
        Console.WriteLine();
    }

    public void SetCell(int x, int y, char value)
    {
        matrix[x][y] = value;
    }

    public int GetRows()
    {
        return matrix.Length;
    }

    public int GetColumns()
    {
        return matrix[0].Length;
    }

    public char GetCellValue(int x, int y)
    {
        return matrix[x][y];
    }
}
