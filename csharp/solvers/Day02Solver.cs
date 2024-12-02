namespace aoc2024.solvers
{

    [Day(2)]
    public class Day02Solver : BaseDaySolver
    {
        private static IEnumerable<int[]> Rows(string input) =>
            from line in input.Split('\n')
            let nums = line.Split(" ").Select(int.Parse).ToArray()
            select nums.ToArray();

        private static bool Valid(int[] row)
        {
            var pairs = Enumerable.Zip(row, row.Skip(1));
            return
                pairs.All(p => 1 <= p.Second - p.First && p.Second - p.First <= 3) ||
                pairs.All(p => 1 <= p.First - p.Second && p.First - p.Second <= 3);
        }

        private static IEnumerable<int[]> Generate(int[] rows) =>
        from i in Enumerable.Range(0, rows.Length + 1)
        let before = rows.Take(i - 1)
        let after = rows.Skip(i)
        select Enumerable.Concat(before, after).ToArray();


        public override string Part1(string input)
        {
            var result = Rows(input).Count(Valid);
            return result.ToString();
        }

        public override string Part2(string input)
        {
            var result = Rows(input).Count(rows => Generate(rows).Any(Valid));
            return result.ToString();
        }
    }
}

