using System;
using System.Diagnostics;
using SudokuBase;
using SudokuCreation;
using SudokuLogger;

namespace SudokuCreationTester
{
    public class CreationTester : Sudoku
    {
        public CreationTester(Logger logger) : base(logger)
        {
        }

        public static void TestCreationForTryCount(int TestCountPerTry)
        {
            Test(1000, TestCountPerTry);
            //for (int i = 25; i <= 1000; i += 5)
            //{
            //    Test(i, TestCountPerTry);
            //}

        }

        private static void Test(int TryCount, int TestCountPerTry)
        {

            Stopwatch stopWatchTotal = new Stopwatch();

            int counter = 1;
            while (true)
            {
                Stopwatch stopWatchLocale = new Stopwatch();
                if (counter == TestCountPerTry + 1)
                    break;

                stopWatchLocale.Start();
                stopWatchTotal.Start();

                Creation.CreateSudoku(TryCount);

                stopWatchLocale.Stop();
                stopWatchTotal.Stop();

                TimeSpan timeSpanLocale = stopWatchLocale.Elapsed;
                string elapsedTimeLocale = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    timeSpanLocale.Hours, timeSpanLocale.Minutes, timeSpanLocale.Seconds,
                    timeSpanLocale.Milliseconds / 10);

                _logger.Debug(TryCount.ToString() + " -- " + counter.ToString() + " / " + TestCountPerTry + " : " + elapsedTimeLocale, WriteLocationTypes.Console);

                counter++;
            }

            TimeSpan timeSpanTotal = stopWatchTotal.Elapsed;
            string elapsedTimeTotal = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                timeSpanTotal.Hours, timeSpanTotal.Minutes, timeSpanTotal.Seconds,
                timeSpanTotal.Milliseconds / 10);

            _logger.Debug(TryCount.ToString() + " Yanılma Limiti İle, " + TestCountPerTry.ToString() + "Deneme'nin Toplam Süresi : " + elapsedTimeTotal.ToString());
        }

        private TimeSpan CalculateAvarage(TimeSpan timeSpan, int TestCountPerTry)
        {
            int total = (int)timeSpan.TotalMilliseconds;

            int avarage = (int)(total / TestCountPerTry);

            TimeSpan ts = TimeSpan.FromMilliseconds(avarage);

            return ts;
        }
    }
}