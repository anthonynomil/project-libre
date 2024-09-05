using System.Reflection;
using Entities.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Database.Configuration;

internal static class PrimaryKeyTypes
{
    public static IEnumerable<Type> GetPrimaryKeyEntityTypes()
    {
        return GetPrimaryKeyEntitiesAssembly()
            .GetTypes()
            .Where(IsConcreteImplementationOfPrimaryKey);
    }

    public static void AddToModelBuilder(this IEnumerable<Type> types, ModelBuilder modelBuilder)
    {
        foreach (var type in types)
        {
            modelBuilder.Entity(type);
        }
    }

    private static Assembly GetPrimaryKeyEntitiesAssembly() =>
        Assembly.GetAssembly(typeof(PrimaryKey))
        ?? throw new Exception("Couldn't find the Entities assembly.");

    private static bool IsConcreteImplementationOfPrimaryKey(Type t)
    {
        return t is { IsAbstract: false } && t.IsSubclassOf(typeof(PrimaryKey));
    }
}
