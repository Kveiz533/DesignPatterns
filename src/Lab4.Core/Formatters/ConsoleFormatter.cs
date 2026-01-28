namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Formatters;

public sealed class ConsoleFormatter : IFormatter
{
    public void Format(Stream stream)
    {
        using var reader = new StreamReader(stream);

        string? line = reader.ReadLine();
        while (line is not null)
        {
            Console.WriteLine(line);
            line = reader.ReadLine();
        }
    }
}