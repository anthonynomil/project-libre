using System.Diagnostics.CodeAnalysis;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Infrastructure.Configuration;

// This class is used by Swagger to format enum used throughout the API to
// expose their keys' name rather than their values.
// This is necessary for the frontend tooling to convert them to usable enums
// throughout the frontend application.
[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
public class SwaggerEnumSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (!context.Type.IsEnum)
        {
            return;
        }

        var enumNames = Enum.GetNames(context.Type);
        var enumValues = Enum.GetValues(context.Type);

        var enumNamesArray = new OpenApiArray();
        var enumValuesArray = new OpenApiArray();

        for (var i = 0; i < enumNames.Length; i++)
        {
            enumNamesArray.Add(new OpenApiString(enumNames[i]));
            enumValuesArray.Add(new OpenApiInteger((int)enumValues.GetValue(i)!));
        }

        schema.Extensions.Add("x-enumNames", enumNamesArray);
        schema.Extensions.Add("x-enumValues", enumValuesArray);
    }
}
