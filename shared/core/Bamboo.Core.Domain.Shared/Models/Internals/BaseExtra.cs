using System;
using System.Collections.Generic;

namespace Bamboo.Core.Models;

[Serializable]
public class StringDictionary : Dictionary<string, string?>
{
    public StringDictionary()
    {

    }

    public StringDictionary(IDictionary<string, string?> dictionary)
        : base(dictionary)
    {
    }
}