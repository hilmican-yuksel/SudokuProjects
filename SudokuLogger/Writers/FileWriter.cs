using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuLogger.Writers
{
    public class FileWriter : WriterBase
    {
        public string FilePath { get; set; }
        public FileWriter(string filePath) : base(WriterTypes.File)
        {
            FilePath = filePath;
        }

        public override void Write(LogMessage logMessage)
        {
            base.Write(logMessage);

            using (StreamWriter sw = File.AppendText(FilePath))
            {
                sw.WriteLine(logMessage.Message.ToString());
            }
        }

        public override void WriteSudoku(int[,] sudokuValues)
        {
            base.WriteSudoku(sudokuValues);

            using (StreamWriter sw = File.AppendText(FilePath))
            {
                for (int i = 0; i < sudokuValues.GetLength(0); i++)
                {
                    for (int j = 0; j < sudokuValues.GetLength(1); j++)
                    {

                        sw.Write(sudokuValues[i, j]);
                        sw.Write(" ");

                        if ((i == 2 && j == 8) || (i == 5 && j == 8))
                        {
                            sw.WriteLine();
                            sw.Write("------+-------+-------");
                        }
                        if (j == 2 || j == 5)
                        {
                            sw.Write("| ");
                        }
                    }
                    sw.WriteLine();
                }
            }
        }
    }
}
