class Program
{
    static void Main()
    {


        aoc2024.SolutionRepository.AutoRegisterSolvers();
        // Input parameters
        Console.WriteLine("Enter the day (e.g., 1):");
        string? iinput = Console.ReadLine();
        if (string.IsNullOrEmpty(iinput))
        {
            Console.WriteLine("Invalid input");
            return;
        }
        int day = int.Parse(iinput);

        Console.WriteLine("Use sample data? (y/n):");
        iinput = Console.ReadLine();
        if (string.IsNullOrEmpty(iinput))
        {
            Console.WriteLine("Invalid input");
            return;
        }
        bool isSample = iinput.Trim().Equals("y", StringComparison.CurrentCultureIgnoreCase);

        try
        {
            aoc2024.IDaySolver solver = aoc2024.SolutionRepository.GetSolver(day);
            // Load input data
            string input = aoc2024.fileloader.FileLoader.LoadFile(day, isSample);

            Console.WriteLine($"Part 1 Solution: {solver.Part1(input)}");
            Console.WriteLine($"Part 2 Solution: {solver.Part2(input)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
