using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Bamboo.Core.Application.Dtos;

public class ReadRequestDto
{
    public List<Guid> Ids { get; set; }
    public List<string> Fields { get; set; }
    public JsonElement? context { get; set; } = null;
}

public class SearchRequestDto
{
    public string Domain { get; set; }
    public long Offset { get; set; } = 0;
    public int Limit { get; set; } = 10;
    public string Order { get; set; } = null;
    public bool Count { get; set; } = false;
}

public class SearchReadRequestDto
{
    public string Domain { get; set; }
    public List<string> Fields { get; set; }
    public long Offset { get; set; } = 0;
    public int Limit { get; set; } = 100;
    public string Order { get; set; } = null;
    bool Count { get; set; } = false;
}

public class CreateRequestDto
{
    public JsonElement Entity { get; set; }
    public List<string> Fields { get; set; }
}

public class UpdateRequestDto
{
    public List<Guid> Ids { get; set; }
    public JsonElement Entity { get; set; }
    public List<string> Fields { get; set; }
}

public class UpdateJsonRequestDto
{
    public List<Guid> Ids { get; set; }
    public string Field { get; set; }
    public string Action { get; set; }
    public JsonElement? Values { get; set; }
}

public class NameGetRequestDto
{
    public List<Guid> Ids { get; set; }
}

public class NameSearchRequestDto
{
    public string Name { get; set; }
    public string Domain { get; set; }
    public string Operator { get; set; } = "ilike";
    public int Limit { get; set; } = 100;
}

public class CopyRequestDto
{
    public List<string> Fields { get; set; }
    public object DefaultValues { get; set; }
}
