

namespace aoc2024.solvers
{

    [Day(1)]
    public class Day01Solver : BaseDaySolver
    {
        private static IEnumerable<int> Column(string input, int column) =>
            from line in input.Split('\n')
            let nums = line.Split("   ").Select(int.Parse).ToArray()
            orderby nums[column]
            select nums[column];

        public override string Part1(string input)
        {
            var result = Enumerable.Zip(Column(input, 0), Column(input, 1))
            .Select(x => Math.Abs(x.First - x.Second))
            .Sum();

            return result.ToString();
        }

        public override string Part2(string input)
        {
            var weights = Column(input, 1).CountBy(x => x).ToDictionary();
            return Column(input, 0).Select(num => weights.GetValueOrDefault(num) * num).Sum().ToString();

        }
    }
}

