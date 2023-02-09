using System.Diagnostics;
using SudokuBase;
using SudokuLogger;

namespace SudokuCreation
{
    public class Creation : Sudoku
    {
        public Creation(Logger logger) : base(logger) { }
        public static void CreateSudoku(int tryCount)
        {
            while (true)
            {
                int[,] sudokuGrid = CreateDiagonal();

                bool ctrl = FillSudoku(sudokuGrid, tryCount);

                if (ctrl)
                {
                    PrintSudoku(sudokuGrid);
                    break;
                }
                else
                {
                    GC.Collect();
                    continue;
                }

            }

        }

        private static int[,] CreateDiagonal()
        {
            int[,] array = new int[9, 9];

            Random rnd = new Random();

            List<int> numbers = new List<int>();

            numbers = SetDefaultNumbers();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (i > -1 && i < 3 && j > -1 && j < 3)
                    {
                        while (true)
                        {
                            int index = rnd.Next(0, numbers.Count);
                            int value = numbers[index];

                            if (SquareControl(array, i, j, value))
                            {
                                array[i, j] = value;

                                numbers.RemoveAt(index);

                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }
            }

            numbers = SetDefaultNumbers();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (i > 2 && i < 6 && j > 2 && j < 6)
                    {
                        while (true)
                        {
                            int index = rnd.Next(0, numbers.Count - 1);
                            int value = numbers[index];

                            if (SquareControl(array, i, j, value))
                            {
                                array[i, j] = value;

                                numbers.RemoveAt(index);

                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }
            }

            numbers = SetDefaultNumbers();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (i > 5 && i < 9 && j > 5 && j < 9)
                    {
                        while (true)
                        {
                            int index = rnd.Next(0, numbers.Count - 1);
                            int value = numbers[index];

                            if (SquareControl(array, i, j, value))
                            {
                                array[i, j] = value;

                                numbers.RemoveAt(index);

                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }
            }
            return array;
        }

        private static void PrintSudoku(int[,] sudokuValues)
        {
            _logger.PrintSudoku(sudokuValues, WriteLocationTypes.None);
        }

        private static bool FillSudoku(int[,] array, int tryCount)
        {
            Random rnd = new Random();

            List<int> numbers;

            //Oluşturma
            for (int i = 0; i < array.GetLength(0); i++)
            {
                numbers = SetDefaultNumbers();

                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == 0)
                    {
                        int counter = 0;
                        while (true)
                        {
                            counter++;

                            int index = rnd.Next(0, numbers.Count);
                            int value = numbers[index];

                            if (Control(array, i, j, value))
                            {
                                array[i, j] = value;

                                numbers.RemoveAt(index);

                                break;
                            }
                            else
                            {

                                if ((numbers.Count == 1 && counter > 3) || counter > tryCount)
                                {
                                    return false;
                                }
                                continue;
                            }
                        }
                    }
                    else
                    {
                        numbers.Remove(array[i, j]);
                    }
                }
            }
            return true;
        }

        private static bool Control(int[,] array, int I, int J, int value)
        {
            bool iControl = IControl(array, I, J, value);
            bool jControl = JControl(array, I, J, value);
            bool squareControl = SquareControl(array, I, J, value);

            if (jControl && iControl && squareControl)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool IControl(int[,] array, int I, int J, int value)
        {
            for (int j = 0; j < array.GetLength(0); j++)
            {
                if (j == J)
                {
                    continue;// aynı cell ise geç
                }
                else
                {
                    if (array[I, j] == value)
                    {
                        return false; // farklı cell ve aynı değer var değiş
                    }
                    else
                    {
                        continue; // farklı cell ve farklı değer devam et
                    }
                }
            }
            return true;// hiç aynı değer yok bu value konulabilir.
        }

        private static bool JControl(int[,] array, int I, int J, int value)
        {
            for (int i = 0; i < array.GetLength(1); i++)
            {
                if (i == I)
                {
                    continue;// aynı cell ise geç
                }
                else
                {
                    if (array[i, J] == value)
                    {
                        return false; // farklı cell ve aynı değer var değiş
                    }
                    else
                    {
                        continue; // farklı cell ve farklı değer devam et
                    }
                }
            }
            return true;// hiç aynı değer yok bu value konulabilir
        }

        private static bool SquareControlLoop(int[,] array, int I, int minI, int maxI, int J, int minJ, int maxJ, int value)
        {
            for (int i = minI; i <= maxI; i++)
            {
                for (int j = minJ; j <= maxJ; j++)
                {
                    if (i == I && j == J)
                    {
                        continue; //aynı cell 
                    }
                    else
                    {
                        if (array[i, j] == value)
                        {
                            return false;// farklı cell ve aynı değer var değiş
                        }
                        else
                        {
                            continue; // farklı cell ve farlı değer devam et
                        }
                    }
                }
            }
            return true;// hiç aynı değer yok bu value konulabilir
        }

        private static bool SquareControl(int[,] array, int I, int J, int value)
        {
            if (I >= 0 && I <= 2)// üst
            {
                if (J >= 0 && J <= 2)// üst sol 
                {
                    return SquareControlLoop(array, I, 0, 2, J, 0, 2, value);
                }
                else if (J >= 3 && J <= 5)// üst orta
                {
                    return SquareControlLoop(array, I, 0, 2, J, 3, 5, value);
                }
                else if (J >= 6 && J <= 8)// üst sağ
                {
                    return SquareControlLoop(array, I, 0, 2, J, 6, 8, value);
                }
                else
                {
                    return true;
                }
            }
            else if (I >= 3 && I <= 5)// orta
            {
                if (J >= 0 && J <= 2)// orta sol
                {
                    return SquareControlLoop(array, I, 3, 5, J, 0, 2, value);
                }
                else if (J >= 3 && J <= 5)// orta orta
                {
                    return SquareControlLoop(array, I, 3, 5, J, 3, 5, value);
                }
                else if (J >= 6 && J <= 8)// orta sağ
                {
                    return SquareControlLoop(array, I, 3, 5, J, 6, 8, value);
                }
                else
                {
                    return true;
                }
            }
            else if (I >= 6 && I <= 8)// alt
            {
                if (J >= 0 && J <= 2)// alt sol
                {
                    return SquareControlLoop(array, I, 6, 8, J, 0, 2, value);
                }
                else if (J >= 3 && J <= 5)// alt orta
                {
                    return SquareControlLoop(array, I, 6, 8, J, 3, 5, value);
                }
                else if (J >= 6 && J <= 8)// alt sağ
                {
                    return SquareControlLoop(array, I, 6, 8, J, 6, 8, value);
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

        private static List<int> SetDefaultNumbers()
        {
            List<int> numbers = new List<int>();
            for (int i = 1; i <= 9; i++)
                numbers.Add(i);

            return numbers;
        }
    }
}