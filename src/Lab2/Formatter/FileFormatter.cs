namespace Itmo.ObjectOrientedProgramming.Lab2.Formatter;

public sealed class FileFormatter : IFormatter
{
    private readonly string _filePath;

    public FileFormatter(string filePath)
    {
        _filePath = filePath;
    }

    public void FormatTitle(string title)
    {
        File.AppendAllText(_filePath, title + Environment.NewLine);
    }

    public void FormatBody(string body)
    {
        File.AppendAllText(_filePath, body + Environment.NewLine + Environment.NewLine);
    }
}