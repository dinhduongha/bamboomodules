using System;
//namespace Bamboo.Core.Domain.Shared.Attributes;
namespace Bamboo.Core.Models;

[AttributeUsage(AttributeTargets.Property)]
public class JsonFieldAttribute : Attribute
{
    public bool IsSparse { get; set; } = true;
}