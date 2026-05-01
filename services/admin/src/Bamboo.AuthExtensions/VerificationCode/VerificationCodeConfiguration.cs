using System;
using System.Collections.Generic;

namespace Bamboo.Abp.VerificationCode;

public class VerificationCodeConfiguration
{
    public byte Length { get; }
    
    public string Chars { get; }

    /// <summary>
    /// Set the chars to be considered the same
    /// </summary>
    /// <example>
    /// <code>'o' => ['O', '0']</code> means char 'O' and '0' can be regarded as the char 'o'.
    /// </example>
    public IDictionary<char, IEnumerable<char>> EquivalentCharsMaps { get; }

    /// <summary>
    /// If this property is not null, it will be used to generate a verification code.
    /// </summary>
    public Func<string> Generate { get; set; } = null;

    public VerificationCodeConfiguration(
        byte length = 6,
        string chars = "0123456789",
        IDictionary<char, IEnumerable<char>> equivalentCharsMaps = null)
    {
        Length = length;
        Chars = chars;
        
        EquivalentCharsMaps = equivalentCharsMaps ?? new Dictionary<char, IEnumerable<char>>();
    }

    public VerificationCodeConfiguration(Func<string> generate)
    {
        Generate = generate;
    }
}