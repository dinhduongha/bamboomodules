using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Volo.Abp.Domain.Entities;

namespace Bamboo.Core.Application.Contracts.DTOs;

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
    [JsonPropertyName("ids")]
    public List<Guid>? Ids { get; set; }

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

    [JsonPropertyName("fields")]
    public List<string>? Fields { get; set; }
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
    public int Limit { get; set; } = 100;

    [JsonPropertyName("order")]
    public string? Order { get; set; }

    [JsonPropertyName("count")]
    public bool? Count { get; set; } = false;

    [JsonPropertyName("context")]
    public JsonElement? Context { get; set; } = null;
}

public class SearchCountRequestDto
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

public class CreateRequestDto<TEntity>
    where TEntity : class, IEntity<Guid>
{
    [JsonPropertyName("entity")]
    public TEntity Entity { get; set; }

    [JsonPropertyName("fields")]
    public List<string> Fields { get; set; }

    [JsonPropertyName("context")]
    public JsonElement? Context { get; set; } = null;
}

public class CreateRequestDto
{
    [JsonPropertyName("entity")]
    public JsonElement Entity { get; set; }

    [JsonPropertyName("fields")]
    public List<string> Fields { get; set; }

    [JsonPropertyName("context")]
    public JsonElement? Context { get; set; } = null;
}

public class UpdateRequestDto<TEntity>
    where TEntity : class, IEntity<Guid>
{
    [JsonPropertyName("ids")]
    public List<Guid> Ids { get; set; }

    [JsonPropertyName("entity")]
    public TEntity? Entity { get; set; }

    [JsonPropertyName("fields")]
    public List<string> Fields { get; set; }

    [JsonPropertyName("context")]
    public JsonElement? Context { get; set; } = null;
}

public class UpdateRequestDto
{
    [JsonPropertyName("ids")]
    public List<Guid> Ids { get; set; }

    [JsonPropertyName("entity")]
    public JsonElement Entity { get; set; }

    [JsonPropertyName("fields")]
    public List<string> Fields { get; set; }

    [JsonPropertyName("context")]
    public JsonElement? Context { get; set; } = null;
}

public class UpdateJsonRequestDto
{
    [JsonPropertyName("ids")]
    public List<Guid> Ids { get; set; }

    [JsonPropertyName("json_field")]
    public string JsonField { get; set; }

    [JsonPropertyName("action")]
    public string Action { get; set; }

    [JsonPropertyName("values")]
    public JsonElement? Values { get; set; }

    [JsonPropertyName("dict")]
    public Dictionary<string, object>? Dict { get; set; }

    [JsonPropertyName("context")]
    public JsonElement? Context { get; set; } = null;
}


public class CopyRequestDto<TEntity>
    where TEntity : class, IEntity<Guid>
{
    [JsonPropertyName("ids")]
    public List<Guid> Ids { get; set; }

    [JsonPropertyName("fields")]
    public List<string> Fields { get; set; }

    [JsonPropertyName("default_values")]
    public TEntity DefaultValues { get; set; }

    [JsonPropertyName("context")]
    public JsonElement? Context { get; set; } = null;
}

public class CopyRequestDto
{
    [JsonPropertyName("ids")]
    public List<Guid> Ids { get; set; }

    [JsonPropertyName("fields")]
    public List<string> Fields { get; set; }

    [JsonPropertyName("default_values")]
    public JsonElement DefaultValues { get; set; }

    [JsonPropertyName("context")]
    public JsonElement? Context { get; set; } = null;
}

public class OnChangeRequestDto<TEntity>
    where TEntity : class, IEntity<Guid>
{
    [JsonPropertyName("changed_fields")]
    public List<string> ChangedFields { get; set; }

    [JsonPropertyName("values")]
    public TEntity Values { get; set; }

    [JsonPropertyName("info")]
    public Dictionary<string, object> FieldInfos { get; set; }

    [JsonPropertyName("context")]
    public JsonElement? Context { get; set; } = null;
}

public class OnChangeRequestDto
{
    [JsonPropertyName("ids")]
    public List<Guid> Ids { get; set; }

    [JsonPropertyName("changed_fields")]
    public List<string> ChangedFields { get; set; }

    [JsonPropertyName("values")]
    public object Values { get; set; }

    [JsonPropertyName("info")]
    public Dictionary<string, object> FieldInfos { get; set; }

    [JsonPropertyName("context")]
    public JsonElement? Context { get; set; } = null;
}

public class DefaultGetRequestDto
{

    [JsonPropertyName("fields")]
    public List<string>? Fields { get; set; }

    [JsonPropertyName("context")]
    public JsonElement? Context { get; set; } = null;
}

public class NameCreateRequestDto
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("context")]
    public JsonElement? Context { get; set; } = null;
}

public class NameGetRequestDto
{
    [JsonPropertyName("ids")]
    public List<Guid> Ids { get; set; }

    [JsonPropertyName("context")]
    public JsonElement? Context { get; set; } = null;
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
    public int? Limit { get; set; } = 100;

    [JsonPropertyName("context")]
    public JsonElement? Context { get; set; } = null;
}


public class FieldsGetRequestDto
{

    [JsonPropertyName("fields")]
    public List<string>? Fields { get; set; }

    [JsonPropertyName("info")]
    public Dictionary<string, List<string>> Attributes { get; set; }

    [JsonPropertyName("context")]
    public JsonElement? Context { get; set; } = null;
}

public class OnchangeResultDto
{
    public Dictionary<string, object> Value { get; set; }
    public Dictionary<string, string> Warning { get; set; }
}


public class WebSearchReadRequestDto
{

    [JsonPropertyName("domain")]
    public JsonElement? Domain { get; set; }

    [JsonPropertyName("specification")]
    public JsonElement? Specification { get; set; }

    [JsonPropertyName("fields")]
    public List<string>? Fields { get; set; }

    [JsonPropertyName("offset")]
    public long? Offset { get; set; }

    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

    [JsonPropertyName("order")]
    public string? Order { get; set; }

    [JsonPropertyName("context")]
    public JsonElement? Context { get; set; } = null;
}

public class WebReadRequestDto
{
    [JsonPropertyName("ids")]
    public List<Guid> Ids { get; set; }

    [JsonPropertyName("specification")]
    public JsonElement? Specification { get; set; }

    [JsonPropertyName("fields")]
    public List<string> Fields { get; set; }

    [JsonPropertyName("context")]
    public JsonElement? Context { get; set; } = null;
}

public class WebReadGroupRequestDto
{

    [JsonPropertyName("domain")]
    public JsonElement? Domain { get; set; }

    [JsonPropertyName("specification")]
    public JsonElement? Specification { get; set; }

    [JsonPropertyName("groupby")]
    public JsonElement? GroupBy { get; set; }

    [JsonPropertyName("fields")]
    public List<string>? Fields { get; set; }

    [JsonPropertyName("offset")]
    public long? Offset { get; set; }

    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

    [JsonPropertyName("order")]
    public string? Order { get; set; }

    [JsonPropertyName("lazy")]
    public string? Lazy { get; set; }

    [JsonPropertyName("context")]
    public JsonElement? Context { get; set; } = null;
}

public class WebSaveRequestDto<TEntity>
    where TEntity : class, IEntity<Guid>
{
    [JsonPropertyName("ids")]
    public List<Guid> Ids { get; set; }

    [JsonPropertyName("entity")]
    public TEntity Entity { get; set; }

    [JsonPropertyName("specification")]
    public JsonElement? Specification { get; set; }

    [JsonPropertyName("fields")]
    public List<string> Fields { get; set; }

    [JsonPropertyName("context")]
    public JsonElement? Context { get; set; } = null;
}

public class WebSaveRequestDto
{
    [JsonPropertyName("ids")]
    public List<Guid> Ids { get; set; }

    [JsonPropertyName("entity")]
    public JsonElement Entity { get; set; }

    [JsonPropertyName("specification")]
    public JsonElement? Specification { get; set; }

    [JsonPropertyName("fields")]
    public List<string> Fields { get; set; }

    [JsonPropertyName("context")]
    public JsonElement? Context { get; set; } = null;
}