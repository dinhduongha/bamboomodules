using System;

namespace Bamboo.Core.Domain.Shared.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class ModuleAttribute : Attribute 
{
    public string Name { get; } public string[] Depends { get; set; }
    public ModuleAttribute(string name, params string[] depends) { Name = name; Depends = depends; } 
}