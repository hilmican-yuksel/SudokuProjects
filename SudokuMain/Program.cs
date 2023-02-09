using System;
using SudokuLogger;
using SudokuCreation;
using SudokuCreationTester;
//using Logger = SudokuLogger.SudokuLogger;
//using Creation = SudokuCreation.SudokuCreation;

namespace SudokuMain
{
    internal class SudokuMain
    {
        private static Logger Logger;
        private static Creation Creation;
        private static CreationTester CreationTester;

        static void Main(string[] args)
        {
            DateTime dateTime = DateTime.Now;
            string fileName = $"{dateTime.Day}.{dateTime.Month}.{dateTime.Year}.txt";
            string directoryName = Path.Combine(Environment.CurrentDirectory, @"CommonFiles\Statics\");
            string filePath = Path.Combine(directoryName, fileName);

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(directoryName);
            }

            Logger = new Logger(filePath);
            CreationTester = new CreationTester(Logger);

            CreationTester.TestCreationForTryCount(20);

            Thread.Sleep(Timeout.Infinite);

        }
    }
}