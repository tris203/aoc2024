using System.Reflection;

namespace aoc2024
{
    public static class SolutionRepository
    {
        private static readonly Dictionary<int, IDaySolver> solvers = [];

        public static void RegisterSolver(int day, IDaySolver solver)
        {
            solvers[day] = solver;
        }

        public static IDaySolver GetSolver(int day)
        {
            if (!solvers.TryGetValue(day, out IDaySolver? value))
                throw new InvalidOperationException($"No solver registered for day {day}");

            return value;
        }

        public static void AutoRegisterSolvers()
        {
            var solverTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => typeof(IDaySolver).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

            foreach (var type in solverTypes)
            {
                var dayAttribute = type.GetCustomAttribute<DayAttribute>();
                if (dayAttribute != null)
                {
                    var solver = (IDaySolver?)Activator.CreateInstance(type);
                    if (solver != null)
                    {
                        RegisterSolver(dayAttribute.Day, solver);
                    }
                    else
                    {
                        throw new InvalidOperationException($"Unable to create an instance of {type.FullName}");
                    }
                }
                else
                    throw new InvalidOperationException($"Class {type.Name} is missing a DayAttribute.");
            }
        }
    }
}
