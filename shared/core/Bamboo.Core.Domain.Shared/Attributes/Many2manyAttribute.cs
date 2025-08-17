using System;
namespace Bamboo.Core.Domain.Shared.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class Many2manyAttribute : Attribute
{
    public string RelatedModel { get; set; }
}