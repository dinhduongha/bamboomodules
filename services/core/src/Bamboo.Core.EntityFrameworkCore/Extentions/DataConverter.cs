using System;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore;
// <summary>
/// Converts <see cref="DateOnly" /> to <see cref="DateTime"/> and vice versa.
/// </summary>
public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
{
    /// <summary>
    /// Creates a new instance of this converter.
    /// </summary>
    public DateOnlyConverter() : base(
            d => d.ToDateTime(TimeOnly.MinValue),
            d => DateOnly.FromDateTime(d))
    { }
}
public class StringDictionaryConverter : ValueConverter<StringDictionary, string>
{
    public StringDictionaryConverter()
        : base(
            v => JsonSerializer.Serialize((Dictionary<string, string?>)v, (JsonSerializerOptions?)null),
            v => StringDictionaryConverter.Deserialize(v))
    {
    }

    private static StringDictionary Deserialize(string v)
    {
        if (string.IsNullOrEmpty(v))
        {
            return new StringDictionary();
        }

        var dict = JsonSerializer.Deserialize<Dictionary<string, string?>>(v, (JsonSerializerOptions?)null);
        return dict != null ? new StringDictionary(dict) : new StringDictionary();
    }
}
/*
public class StringDictionaryConverter : ValueConverter<StringDictionary, string>
    {
        public StringDictionaryConverter()
            : base(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                v =>
                {
                    if (string.IsNullOrEmpty(v))
                    {
                        return new StringDictionary();
                    }
                    var dict = JsonSerializer.Deserialize<Dictionary<string, string?>>(v, (JsonSerializerOptions?)null);
                    return dict != null ? new StringDictionary(dict) : new StringDictionary();
                })
        {
        }
    }
*/