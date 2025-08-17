using System;
namespace Bamboo.Core.Domain.Shared.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class OdooFieldAttribute : Attribute
{
    public string? String { get; set; }
    public string? Help { get; set; }
    public bool? Required { get; set; }
    public bool? Readonly { get; set; }
    public bool? Index { get; set; }
    public bool? Store { get; set; }
    public bool? Copy { get; set; }
    public bool? Translate { get; set; }
    public bool? Sparse { get; set; }
    public bool? CompanyDependent { get; set; }
    public int? Digits { get; set; }
    public bool? Attatchment { get; set; }
    public string? ComodelName { get; set; }
    public string[] Groups { get; set; }
}