namespace Itmo.ObjectOrientedProgramming.Lab2.Formatter;

public record FilePath
{
    public FilePath(string filePath)
    {
        Value = filePath;
    }

    public string Value { get; }
}