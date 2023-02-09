using SudokuLogger.Writers;

namespace SudokuLogger
{
    public class Logger
    {
        private string FilePath { get; set; }
        private WriterBase ConsoleWriter { get; set; }
        private WriterBase FileWriter { get; set; }

        public Logger(string filePath)
        {
            FilePath = filePath;
            ConsoleWriter = new ConsoleWriter();
            FileWriter = new FileWriter(FilePath);
        }
        public void Error(string message, WriteLocationTypes loc = WriteLocationTypes.All)
        {
            LogMessage logMessage = new LogMessage(message, LogTypes.Error);

            PassToWriters(logMessage, loc);
        }

        public void Debug(string message, WriteLocationTypes loc = WriteLocationTypes.All)
        {
            LogMessage logMessage = new LogMessage(message, LogTypes.Debug);

            PassToWriters(logMessage, loc);
        }

        public void Warning(string message, WriteLocationTypes loc = WriteLocationTypes.All)
        {
            LogMessage logMessage = new LogMessage(message, LogTypes.Warning);

            PassToWriters(logMessage, loc);
        }

        public void Information(string message, WriteLocationTypes loc = WriteLocationTypes.All)
        {
            LogMessage logMessage = new LogMessage(message, LogTypes.Information);

            PassToWriters(logMessage, loc);
        }

        public void PrintSudoku(int[,] sudokuValues, WriteLocationTypes loc = WriteLocationTypes.Console)
        {

            switch (loc)
            {
                case WriteLocationTypes.None:
                    break;
                case WriteLocationTypes.Console:
                    {
                        if (ConsoleWriter != null)
                        {
                            ConsoleWriter.WriteSudoku(sudokuValues);
                        }
                    }
                    break;
                case WriteLocationTypes.File:
                    {
                        if (FileWriter != null)
                        {
                            FileWriter.WriteSudoku(sudokuValues);
                        }
                    }
                    break;
                case WriteLocationTypes.All:
                    {
                        if (ConsoleWriter != null)
                        {
                            ConsoleWriter.WriteSudoku(sudokuValues);
                        }

                        if (FileWriter != null)
                        {
                            FileWriter.WriteSudoku(sudokuValues);
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void PassToWriters(LogMessage logMessage, WriteLocationTypes loc)
        {
            switch (loc)
            {
                case WriteLocationTypes.None:
                    break;
                case WriteLocationTypes.Console:
                    {
                        if (ConsoleWriter != null)
                        {
                            ConsoleWriter.Write(logMessage);
                        }
                    }
                    break;
                case WriteLocationTypes.File:
                    {
                        if (FileWriter != null)
                        {
                            FileWriter.Write(logMessage);
                        }
                    }
                    break;
                case WriteLocationTypes.All:
                    {
                        if (ConsoleWriter != null)
                        {
                            ConsoleWriter.Write(logMessage);
                        }

                        if (FileWriter != null)
                        {
                            FileWriter.Write(logMessage);
                        }
                    }
                    break;
                default:
                    break;
            }
        }

    }

    public enum WriteLocationTypes
    {
        None = 0,
        Console = 1,
        File = 2,
        All = 3
    }

}