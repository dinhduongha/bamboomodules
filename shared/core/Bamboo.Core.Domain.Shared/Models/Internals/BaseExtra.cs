using System;
using System.Collections.Generic;
using System.Linq;

namespace Bamboo.Core.Models;

[Serializable]
public class StringDictionary : Dictionary<string, string?>, IComparable<StringDictionary>
{
    public StringDictionary()
    {
    }

    public StringDictionary(IDictionary<string, string?> dictionary)
        : base(dictionary)
    {
    }

    public int CompareTo(StringDictionary? other)
    {
        // Handle null case
        if (other == null)
        {
            return 1; // Non-null is greater than null
        }

        // If both dictionaries are empty, they are equal
        if (this.Count == 0 && other.Count == 0)
        {
            return 0;
        }

        // Compare by count first
        if (this.Count != other.Count)
        {
            return this.Count.CompareTo(other.Count);
        }

        // Get sorted keys for consistent comparison
        var thisKeys = this.Keys.OrderBy(k => k).ToList();
        var otherKeys = other.Keys.OrderBy(k => k).ToList();

        // Compare keys
        for (int i = 0; i < thisKeys.Count; i++)
        {
            var keyComparison = string.Compare(thisKeys[i], otherKeys[i], StringComparison.Ordinal);
            if (keyComparison != 0)
            {
                return keyComparison;
            }

            // Keys are equal, compare values
            var thisValue = this[thisKeys[i]];
            var otherValue = other[otherKeys[i]];

            // Handle null values
            if (thisValue == null && otherValue == null)
            {
                continue;
            }
            if (thisValue == null)
            {
                return -1; // Null is less than non-null
            }
            if (otherValue == null)
            {
                return 1; // Non-null is greater than null
            }

            // Compare non-null values
            var valueComparison = string.Compare(thisValue, otherValue, StringComparison.Ordinal);
            if (valueComparison != 0)
            {
                return valueComparison;
            }
        }

        // All keys and values are equal
        return 0;
    }
}

    [AttributeUsage(AttributeTargets.Property)]
    public class JsonFieldAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Property)]
    public class RelationFieldAttribute : Attribute
    {
        public string RelatedModel { get; }
        public string RelationType { get; }

        public RelationFieldAttribute(string relatedModel, string relationType)
        {
            RelatedModel = relatedModel;
            RelationType = relationType;
        }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class ModelNameAttribute : Attribute
    {
        public string[] Names { get; }
        public ModelNameAttribute(params string[] names)
        {
            Names = names;    
        }
    }