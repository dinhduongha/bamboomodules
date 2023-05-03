using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;

namespace Bamboo.Abp.VerificationCode;

public class VerificationCodeGenerator : IVerificationCodeGenerator
{
    public virtual Task<string> CreateAsync(VerificationCodeConfiguration configuration)
    {
        if (configuration.Generate != null)
        {
            return Task.FromResult(configuration.Generate.Invoke());
        }

        Check.NotNullOrWhiteSpace(configuration.Chars, nameof(configuration.Chars));
        
        return Task.FromResult(RandomString(configuration.Chars, configuration.Length));
    }
    
    public virtual string RandomString(string chars, int length)
    {
        var random = new Random();

        return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
    }
}