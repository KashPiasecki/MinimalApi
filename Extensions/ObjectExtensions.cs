namespace MinimalApi.Extensions;

public static class ObjectExtensions
{
    public static bool IsSomething(this object obj) =>
        obj is not null;
}