using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Volo.Abp.Application.Dtos;

public class FilterBase : PagedAndSortedResultRequestDto
{
    public int Page { get; set; } = 0;
    public int Size { get; set; } = 0;
    public string Keyword { get; set; }
    public string Format { get; set; }
    public List<KeyValuePair<string, string>> OrderBy { get; set; }
    public string ToUrlEncoded()
    {
        var keyValueContent = ToKeyValue(this);
        var formUrlEncodedContent = new FormUrlEncodedContent(keyValueContent);
        var urlEncodedString = formUrlEncodedContent.ReadAsStringAsync().GetAwaiter().GetResult();
        return urlEncodedString;
    }

    public static string ToUrlEncoded(object filter)
    {
        var keyValueContent = ToKeyValue(filter);
        var formUrlEncodedContent = new FormUrlEncodedContent(keyValueContent);
        var urlEncodedString = formUrlEncodedContent.ReadAsStringAsync().GetAwaiter().GetResult();
        return urlEncodedString;

    }

    /// https://geeklearning.io/serialize-an-object-to-an-url-encoded-string-in-csharp/
    public static IDictionary<string, string> ToKeyValue(object metaToken)
    {
        if (metaToken == null)
            return null;

        var json = JsonSerializer.Serialize(metaToken);
        using var doc = JsonDocument.Parse(json);
        var result = new Dictionary<string, string>();
        FlattenElement(doc.RootElement, result, null);
        return result;
    }

    private static void FlattenElement(JsonElement element, IDictionary<string, string> dict, string prefix)
    {
        switch (element.ValueKind)
        {
            case JsonValueKind.Object:
                foreach (var prop in element.EnumerateObject())
                {
                    var propName = prefix != null ? $"{prefix}.{prop.Name}" : prop.Name;
                    FlattenElement(prop.Value, dict, propName);
                }
                break;

            case JsonValueKind.Array:
                int index = 0;
                foreach (var item in element.EnumerateArray())
                {
                    var propName = $"{prefix}[{index}]";
                    FlattenElement(item, dict, propName);
                    index++;
                }
                break;

            case JsonValueKind.String:
                if (element.TryGetDateTime(out var date))
                    dict[prefix] = date.ToString("o", CultureInfo.InvariantCulture);
                else
                    dict[prefix] = element.GetString();
                break;

            case JsonValueKind.Number:
                dict[prefix] = element.ToString();
                break;

            case JsonValueKind.True:
            case JsonValueKind.False:
                dict[prefix] = element.GetBoolean().ToString();
                break;

            case JsonValueKind.Null:
            case JsonValueKind.Undefined:
                break; // bỏ qua null
        }
    }

    public static string ToFormUrlEncodedString(object obj)
    {
        var dict = ToKeyValue(obj);
        if (dict == null || dict.Count == 0)
            return string.Empty;

        var sb = new StringBuilder();
        foreach (var kv in dict)
        {
            if (sb.Length > 0)
                sb.Append('&');

            sb.Append(Uri.EscapeDataString(kv.Key));
            sb.Append('=');
            sb.Append(Uri.EscapeDataString(kv.Value ?? ""));
        }

        return sb.ToString();
    }
}