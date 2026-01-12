using System;
namespace Bamboo.Core.Domain.Shared.Attributes;
[AttributeUsage(AttributeTargets.Method)]
public class ApiPrivateAttribute : Attribute
{
    // Marker attribute to indicate this method should not be exposed via API Controller
}