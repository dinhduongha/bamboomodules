using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Volo.Abp.Caching;

namespace Bamboo.Abp.VerificationCode;

public class VerificationCodeManager : IVerificationCodeManager
{
    private readonly IDistributedCache<VerificationCodeCacheItem> _cache;
    private readonly IVerificationCodeGenerator _verificationCodeGenerator;

    public VerificationCodeManager(
        IDistributedCache<VerificationCodeCacheItem> cache,
        IVerificationCodeGenerator verificationCodeGenerator)
    {
        _cache = cache;
        _verificationCodeGenerator = verificationCodeGenerator;
    }

    public virtual async Task<string> GenerateAsync(string codeCacheKey, TimeSpan codeCacheLifespan,
        VerificationCodeConfiguration configuration)
    {
        var verificationCode = await _verificationCodeGenerator.CreateAsync(configuration);

        await _cache.SetAsync(codeCacheKey, new VerificationCodeCacheItem(verificationCode, ""),
            new DistributedCacheEntryOptions {AbsoluteExpirationRelativeToNow = codeCacheLifespan});

        return verificationCode;

    }

    public virtual async Task<VerificationCodeCacheItem?> ValidateAsync(string codeCacheKey, string verificationCode,
        VerificationCodeConfiguration configuration)
    {
        var cacheItem = await _cache.GetAsync(codeCacheKey, true);

        if (cacheItem == null)
        {
            return null;
        }
        
        var result = IsInputCodeCorrect(verificationCode, cacheItem.Code, configuration);

        if (result)
        {
            await _cache.RemoveAsync(codeCacheKey);
            return cacheItem;
        }
        return null;
    }

    public virtual async Task<string> GenerateAsync(string codeCacheKey, string data, TimeSpan codeCacheLifespan,
        VerificationCodeConfiguration configuration)
    {
        var verificationCode = await _verificationCodeGenerator.CreateAsync(configuration);

        await _cache.SetAsync($"{codeCacheKey}:{verificationCode}", new VerificationCodeCacheItem(verificationCode, data),
            new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = codeCacheLifespan });

        return verificationCode;

    }

    public virtual async Task<VerificationCodeCacheItem?> ValidateReceiveAsync(string codeCacheKey, string verificationCode,
        VerificationCodeConfiguration configuration)
    {
        var cacheItem = await _cache.GetAsync($"{codeCacheKey}:{verificationCode}", true);

        if (cacheItem == null)
        {
            return null;
        }

        var result = IsInputCodeCorrect(verificationCode, cacheItem.Code, configuration);

        if (result)
        {
            await _cache.RemoveAsync($"{codeCacheKey}:{verificationCode}");
            return cacheItem;
        }
        return null;
    }

    protected virtual bool IsInputCodeCorrect(string inputCode, string correctCode,
        VerificationCodeConfiguration configuration)
    {
        if (inputCode.Length != correctCode.Length)
        {
            return false;
        }
        
        if (configuration.EquivalentCharsMaps.IsNullOrEmpty())
        {
            return inputCode == correctCode;
        }

        for (var i = 0; i < inputCode.Length; i++)
        {
            if (!IsCharCorrect(inputCode[i], correctCode[i], configuration.EquivalentCharsMaps))
            {
                return false;
            }
        }

        return true;
    }

    protected virtual bool IsCharCorrect(char inputChar, char correctChar,
        IDictionary<char, IEnumerable<char>> equivalentCharsMaps)
    {
        if (inputChar == correctChar)
        {
            return true;
        }

        return equivalentCharsMaps.ContainsKey(correctChar) && equivalentCharsMaps[correctChar].Contains(inputChar);
    }
}