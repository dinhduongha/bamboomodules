using System;
namespace Bamboo.Core.Domain.Shared.Attributes;

[AttributeUsage(AttributeTargets.Method)]
public class ApiModelAttribute : Attribute
{
    // Marker attribute to indicate this method is @api.model
}