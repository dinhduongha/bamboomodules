using System;
namespace Bamboo.Core.Domain.Shared.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class ModelAttribute : Attribute
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsTransient { get; set; }
    public bool IsAuto { get; set; } = true;
    public ModelAttribute(string name)
    {
        Name = name;
    }
}