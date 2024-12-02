namespace aoc2024;

public interface IDaySolver
{
    string Part1(string input);
    string Part2(string input);
}

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class DayAttribute(int day) : Attribute
{
    public int Day { get; } = day;
}
