namespace aoc2024.fileloader
{
    public class FileLoader
    {
        public static string LoadFile(int day, bool sample)
        {
            var path = $"../data/{day:00}/{(sample ? "sample" : "input")}.txt";
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"File not found: {path}");
            }
            return File.ReadAllText(path).TrimEnd();
        }
    }
}
