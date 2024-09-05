namespace Models;

public static class ResultMessage
{
    public static string AlreadyExists() => $"Already exists.";

    public static string Created() => $"Created.";

    public static string Deleted() => $"Deleted.";

    public static string InvalidCredentials() => "Invalid credentials.";

    public static string NotFound() => $"Not found.";

    public static string Validation() => "One or multiple entries failed validations.";

    public static string Updated() => $"Updated.";
}
