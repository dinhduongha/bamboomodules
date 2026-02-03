using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Bamboo.Core.Application.Dtos;

public class JsonRpcRequest
{
    [JsonPropertyName("jsonrpc")]
    public string? Jsonrpc { get; set; }

    [JsonPropertyName("method")]
    public string? Method { get; set; }

    [JsonPropertyName("params")]
    public JsonRpcParams? Params { get; set; }
    [JsonPropertyName("id")]
    public object? Id { get; set; }
}

public class JsonRpcParams
{
    [JsonPropertyName("model")]
    public string? Model { get; set; }

    [JsonPropertyName("method")]
    public string? Method { get; set; }

    [JsonPropertyName("args")]
    public List<object>? Args { get; set; }

    [JsonPropertyName("kwargs")]
    public Dictionary<string, object>? Kwargs { get; set; }
}

public class JsonRpcResponse
{
    [JsonPropertyName("jsonrpc")]
    public string? Jsonrpc { get; set; }

    [JsonPropertyName("id")]
    public object? Id { get; set; }

    [JsonPropertyName("result")]
    public object? Result { get; set; }

    [JsonPropertyName("error")]
    public JsonRpcError? Error { get; set; }
}

public class JsonRpcError
{
    [JsonPropertyName("code")]
    public int Code { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("data")]
    public object? Data { get; set; }
}

public class JsonV2Params
{

    [JsonPropertyName("ids")]
    public List<Guid>? Ids { get; set; }

    [JsonPropertyName("context")]
    public JsonElement? Context { get; set; }

    [JsonPropertyName("domain")]
    public JsonElement? Domain { get; set; }

    [JsonPropertyName("fields")]
    public List<string>? Fields { get; set; }


    [JsonPropertyName("args")]
    public List<object> Args { get; set; }

    [JsonPropertyName("kwargs")]
    public Dictionary<string, object> Kwargs { get; set; }
}