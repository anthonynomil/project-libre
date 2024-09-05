namespace Models;

internal static class DtoUtils
{
    internal static TDto? ToDtoOrDefault<TEntity, TDto>(
        this TEntity? entity,
        Func<TEntity, TDto> function
    )
        where TEntity : class
        where TDto : class
    {
        return entity == null ? null : function(entity);
    }

    internal static IEnumerable<TDto>? ToDtoOrDefault<TEntity, TDto>(
        this IEnumerable<TEntity>? entities,
        Func<TEntity, TDto> function
    )
        where TEntity : class
        where TDto : class
    {
        return entities?.Select(function);
    }
}
