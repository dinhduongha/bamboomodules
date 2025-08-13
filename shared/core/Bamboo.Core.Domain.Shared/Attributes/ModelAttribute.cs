using System;

namespace Bamboo.Core.Domain.Shared.Attributes; [AttributeUsage(AttributeTargets.Class)] public class ModelAttribute : Attribute { public string Name { get; set; } public bool IsTransient { get; set; } public ModelAttribute(string name) { Name = name; } }