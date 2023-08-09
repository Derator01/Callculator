using Callculator;

namespace Debug;

public static class Debug
{
    private static void Main()
    {
        while (true)
            Console.WriteLine(Calculator.Calculate(Console.ReadLine()));
    }
}
