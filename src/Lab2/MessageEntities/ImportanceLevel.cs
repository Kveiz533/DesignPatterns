namespace Itmo.ObjectOrientedProgramming.Lab2.MessageEntities;

public record ImportanceLevel
{
    private readonly int _value;

    private ImportanceLevel(int level)
    {
        _value = level;
    }

    public static ImportanceLevel Low()
    {
        return new ImportanceLevel(0);
    }

    public static ImportanceLevel Medium()
    {
        return new ImportanceLevel(1);
    }

    public static ImportanceLevel High()
    {
        return new ImportanceLevel(2);
    }

    public static ImportanceLevel ExtraHigh()
    {
        return new ImportanceLevel(3);
    }

    public static bool operator >=(ImportanceLevel left, ImportanceLevel right) => left._value >= right._value;

    public static bool operator <=(ImportanceLevel left, ImportanceLevel right) => left._value <= right._value;
}