using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;

public static class JsonElementCamelCaseExtensions
{
    private static readonly Regex _wordSplitRegex =
        new Regex(@"[_\- ]+([a-zA-Z0-9])", RegexOptions.Compiled);

    private static string ToCamelCase(string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        // 1️⃣ Normalize: UserName → userName
        var result = char.ToLowerInvariant(input[0]) + input.Substring(1);

        // 2️⃣ snake_case / kebab-case → camelCase
        result = _wordSplitRegex.Replace(
            result,
            m => m.Groups[1].Value.ToUpperInvariant()
        );

        return result;
    }

    public static JsonElement ToCamelCase(this JsonElement element)
    {
        using var stream = new MemoryStream();
        using var writer = new Utf8JsonWriter(stream);

        WriteElement(writer, element);

        writer.Flush();
        return JsonDocument.Parse(stream.ToArray()).RootElement.Clone();
    }

    private static void WriteElement(Utf8JsonWriter writer, JsonElement element)
    {
        switch (element.ValueKind)
        {
            case JsonValueKind.Object:
                writer.WriteStartObject();
                foreach (var prop in element.EnumerateObject())
                {
                    writer.WritePropertyName(ToCamelCase(prop.Name));
                    WriteElement(writer, prop.Value);
                }
                writer.WriteEndObject();
                break;

            case JsonValueKind.Array:
                writer.WriteStartArray();
                foreach (var item in element.EnumerateArray())
                {
                    WriteElement(writer, item);
                }
                writer.WriteEndArray();
                break;

            default:
                element.WriteTo(writer);
                break;
        }
    }
}
