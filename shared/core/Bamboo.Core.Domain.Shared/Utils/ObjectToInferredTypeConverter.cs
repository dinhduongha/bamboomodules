using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Bamboo.Core;
public class ObjectToInferredTypeConverter : JsonConverter<object>
{
    public override object Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.True:
                return true;
            case JsonTokenType.False:
                return false;
            case JsonTokenType.Number:
                if (reader.TryGetInt64(out long l))
                    return l;
                return reader.GetDouble();
            case JsonTokenType.String:
                return reader.GetString();
            case JsonTokenType.StartArray:
                return JsonSerializer.Deserialize<List<object>>(ref reader, options);
            case JsonTokenType.StartObject:
                return JsonSerializer.Deserialize<Dictionary<string, object>>(ref reader, options);
            default:
                return null;
        }
    }

    public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, value?.GetType() ?? typeof(object), options);
    }
}
