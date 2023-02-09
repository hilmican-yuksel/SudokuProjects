using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuLogger.Writers
{
    public class ConsoleWriter : WriterBase
    {
        public ConsoleWriter() : base(WriterTypes.Console)
        {

        }

        public override void Write(LogMessage logMessage)
        {
            base.Write(logMessage);

            if (logMessage.LogType == LogTypes.None)
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (logMessage.LogType == LogTypes.Error)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (logMessage.LogType == LogTypes.Warning)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else if (logMessage.LogType == LogTypes.Information)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            else if (logMessage.LogType == LogTypes.Debug)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }

            Console.WriteLine(logMessage.Message.ToString());
        }

        public override void WriteSudoku(int[,] sudokuValues)
        {
            base.WriteSudoku(sudokuValues);

            Console.ForegroundColor = ConsoleColor.DarkBlue;

            for (int i = 0; i < sudokuValues.GetLength(0); i++)
            {
                for (int j = 0; j < sudokuValues.GetLength(1); j++)
                {
                    Console.Write(sudokuValues[i, j]);
                    Console.Write(" ");

                    if ((i == 2 && j == 8) || (i == 5 && j == 8))
                    {
                        Console.WriteLine();
                        Console.Write("------+-------+-------");
                    }
                    if (j == 2 || j == 5)
                    {
                        Console.Write("| ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
