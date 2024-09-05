using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Database.Configuration;

// This class is used by EFCore to setup the conversion of DateOnly objects used
// throughout the application to DateTime objects.
// This is a constraint imposed by MySQL which does not support DateOnly objects.
[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
internal class DateOnlyConverter()
    : ValueConverter<DateOnly, DateTime>(
        dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
        dateTime => DateOnly.FromDateTime(dateTime)
    );
