namespace aoc2024.solvers
{
    public abstract class BaseDaySolver : IDaySolver
    {
        public abstract string Part1(string input);
        public abstract string Part2(string input);
        private static readonly char[] separator = { '\r', '\n' };

        protected static string[] GetLines(string input) =>
            input.Split(separator, StringSplitOptions.RemoveEmptyEntries);

        protected static int[] GetNumbers(string input) =>
            GetLines(input).Select(int.Parse).ToArray();

        protected static void Log(string message) =>
            Console.WriteLine($"[LOG]: {message}");
    }
}
