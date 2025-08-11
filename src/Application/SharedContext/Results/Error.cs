namespace Application.SharedContext.Results;

public class Error(string code, string message)
{
    public static Error NullValue { get; }
    public static Error None { get; }
}