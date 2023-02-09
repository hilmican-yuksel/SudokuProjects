using SudokuLogger;

namespace SudokuBase
{
    public abstract class Sudoku
    {
        public static Logger _logger { get; set; }    
        public Sudoku(Logger logger)
        {
            _logger = logger;
        }
    }
}