using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuLogger.Writers
{
    public abstract class WriterBase
    {
        public WriterTypes WriterType { get; set; }

        public WriterBase(WriterTypes writerType)
        {
            WriterType = writerType;
        }

        public virtual void Write(LogMessage logMessage)
        {

        }
        public virtual void WriteSudoku(int[,] sudokuValues)
        {

        }
    }

    public enum WriterTypes
    {
        None = 0,
        Console = 1,
        File = 2,
        Sudoku = 3
    }

    public class LogMessage
    {
        public string Message { get; set; }
        public LogTypes LogType { get; set; }

        public LogMessage(string message, LogTypes logType)
        {
            Message = message;
            LogType = logType;
        }
    }

    public enum LogTypes
    {
        None = 0,
        Error = 1,
        Warning = 2,
        Information = 3,
        Debug = 4,
    }
}
