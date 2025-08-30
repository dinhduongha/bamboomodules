using System;
namespace Bamboo.Core.Domain.Shared.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class JsonFieldAttribute : Attribute
{
    public bool IsSparse { get; set; } = true;
}