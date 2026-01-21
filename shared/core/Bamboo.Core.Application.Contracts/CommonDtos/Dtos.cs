using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Bamboo.Core.Application.Dtos;

public class ReadRequestDto
{
    [JsonPropertyName("ids")]
    public List<Guid> Ids { get; set; }

    [JsonPropertyName("fields")]
    public List<string> Fields { get; set; }

    [JsonPropertyName("context")]
    public JsonElement? Context { get; set; } = null;
}

public class SearchRequestDto
{
    [JsonPropertyName("domain")]
    public JsonElement? Domain { get; set; }

    [JsonPropertyName("offset")]
    public long Offset { get; set; } = 0;

    [JsonPropertyName("limit")]
    public int Limit { get; set; } = 10;

    [JsonPropertyName("order")]
    public string? Order { get; set; }

    [JsonPropertyName("count")]
    public bool? Count { get; set; } = false;

    [JsonPropertyName("context")]
    public JsonElement? Context { get; set; } = null;
}

public class SearchReadRequestDto
{
    [JsonPropertyName("domain")]
    public JsonElement? Domain { get; set; }

    [JsonPropertyName("fields")]
    public List<string>? Fields { get; set; }

    [JsonPropertyName("offset")]
    public long Offset { get; set; } = 0;

    [JsonPropertyName("limit")]
    public int Limit { get; set; } = 10;

    [JsonPropertyName("order")]
    public string? Order { get; set; }

    [JsonPropertyName("count")]
    public bool? Count { get; set; } = false;

    [JsonPropertyName("context")]
    public JsonElement? Context { get; set; } = null;
}

public class CreateRequestDto
{
    [JsonPropertyName("entity")]
    public JsonElement Entity { get; set; }

    [JsonPropertyName("fields")]
    public List<string> Fields { get; set; }
}

public class UpdateRequestDto
{
    [JsonPropertyName("ids")]
    public List<Guid> Ids { get; set; }

    [JsonPropertyName("entity")]
    public JsonElement Entity { get; set; }

    [JsonPropertyName("fields")]
    public List<string> Fields { get; set; }
}

public class UpdateJsonRequestDto
{
    [JsonPropertyName("ids")]
    public List<Guid> Ids { get; set; }

    [JsonPropertyName("fields")]
    public string Field { get; set; }

    [JsonPropertyName("action")]
    public string Action { get; set; }

    [JsonPropertyName("values")]
    public JsonElement? Values { get; set; }
}

public class NameGetRequestDto
{
    [JsonPropertyName("ids")]
    public List<Guid> Ids { get; set; }
}

public class NameSearchRequestDto
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("domain")]
    public JsonElement? Domain { get; set; }

    [JsonPropertyName("operator")]
    public string Operator { get; set; } = "ilike";

    [JsonPropertyName("limit")]
    public int Limit { get; set; } = 100;
}

public class CopyRequestDto
{
    [JsonPropertyName("fields")]
    public List<string> Fields { get; set; }

    [JsonPropertyName("default_values")]
    public object DefaultValues { get; set; }
}
