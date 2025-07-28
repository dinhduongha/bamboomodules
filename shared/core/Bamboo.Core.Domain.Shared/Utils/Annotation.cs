using System;
using System.Collections.Generic;
using System.Linq;

namespace Bamboo.Core.Models;

[AttributeUsage(AttributeTargets.Property)]
public class JsonFieldAttribute : Attribute { }

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class ModuleAttribute : Attribute
{
    public string Name { get; }
    public string[] Depends { get; }
    public ModuleAttribute(string name, string[]? depends = null)
    {
        Name = name;
        Depends = depends ?? Array.Empty<string>();
    }
}


[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class ModelAttribute : Attribute
{
    public string Name { get; }
    public string[] Depends { get; }
    public bool IsTransient { get; }
    public ModelAttribute(string name, string[]? depends = null, bool isTransient = false)
    {
        Name = name;
        Depends = depends ?? Array.Empty<string>();
        IsTransient = isTransient;
    }
}

[AttributeUsage(AttributeTargets.Property)]
public class RelationFieldAttribute : Attribute
{
    private string relationType;

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

    // public RelationFieldAttribute(string RelationType, string Model, string Field)
    // {
    //     relationType = RelationType;
    //     this.Model = Model;
    //     this.Field = Field;
    // }
}

