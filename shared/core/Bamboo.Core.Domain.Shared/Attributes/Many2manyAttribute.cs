using System;
namespace Bamboo.Core.Domain.Shared.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class Many2manyAttribute : Attribute
{
    public string RelatedModel { get; set; }
    public string RelatedField { get; set; }
    public Many2manyAttribute(string name = null, string relatedField = null)
    {
        RelatedModel = name;
        RelatedField = relatedField;
    }
}