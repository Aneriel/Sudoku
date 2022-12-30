namespace Sudoku
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                int[,] sudokuTable = new int[9, 9];

                for (int i = 0; i < 9; i++)
                {
                    string line = Console.ReadLine();
                    string[] digits = line.Split(' ');

                    for (int j = 0; j < 9; j++)
                    {
                        sudokuTable[i, j] = int.Parse(digits[j]);
                    }
                }

                if (IsSudokuValid(sudokuTable))
                {
                    Console.WriteLine("yes");
                }
                else
                {
                    Console.WriteLine("no");
                }
            }

             bool IsSudokuValid(int[,] sudokuTable)
            {
                // Sprawdzanie wierszy
                for (int i = 0; i < 9; i++)
                {
                    bool[] check = new bool[9];

                    for (int j = 0; j < 9; j++)
                    {
                        if (check[sudokuTable[i, j] - 1])
                        {
                            return false;
                        }

                        check[sudokuTable[i, j] - 1] = true;
                    }
                }

                // Sprawdzanie kolumn
                for (int j = 0; j < 9; j++)
                {
                    bool[] check = new bool[9];

                    for (int i = 0; i < 9; i++)
                    {
                        if (check[sudokuTable[i, j] - 1])
                        {
                            return false;
                        }

                        check[sudokuTable[i, j] - 1] = true;
                    }
                }

                // Sprawdzanie 3x3
                for (int block = 0; block < 9; block++)
                {
                    bool[] check = new bool[9];

                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            int row = (block / 3) * 3 + i;
                            int col = (block % 3) * 3 + j;

                            if (check[sudokuTable[row, col] - 1])
                            {
                                return false;
                            }

                            check[sudokuTable[row, col] - 1] = true;
                        }
                    }
                }

                return true;
            }
        }
    }
}