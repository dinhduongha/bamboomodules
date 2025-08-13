using System;

namespace Bamboo.Core.Domain.Shared.Attributes; [AttributeUsage(AttributeTargets.Property)] public class One2manyAttribute : Attribute { public string RelatedModel { get; set; } public string InverseField { get; set; } }