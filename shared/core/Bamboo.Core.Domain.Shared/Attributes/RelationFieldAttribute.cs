using System;
using System.Collections.Generic;
using System.Linq;

namespace Bamboo.Core.Domain.Shared.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class RelationFieldAttribute : Attribute
{
    // Relation type may be: many2one/one2one/one2many/many2many/eval
    public string Type { get; }
    public string? Model { get; }
    public string? Field { get; }

    public RelationFieldAttribute(string RelationType, string? RelatedModel = null, string? RelatedField = null)
    {
        Type = RelationType;
        Model = RelatedModel;
        Field = RelatedField;
    }
}

