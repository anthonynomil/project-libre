namespace Entities.Helper;

internal static class EntityValidator
{
    private static DateOnly GetCurrentDateOnly()
    {
        return DateOnly.FromDateTime(DateTime.Now);
    }

    public static void PositiveInteger(int i, string name)
    {
        if (i < 0)
            throw new ArgumentException($"Parameter {name} must be a positive integer.");
    }

    public static void RequiredString(string s, string name)
    {
        if (string.IsNullOrEmpty(s))
            throw new ArgumentException($"Parameter {name} can't be null or empty.");
    }

    public static void ValidBirthdate(DateOnly birthdate, string name)
    {
        if (birthdate.CompareTo(GetCurrentDateOnly()) >= 0)
            throw new ArgumentException($"Birthdate {name} can't be as recent as today's date.");
    }
}
