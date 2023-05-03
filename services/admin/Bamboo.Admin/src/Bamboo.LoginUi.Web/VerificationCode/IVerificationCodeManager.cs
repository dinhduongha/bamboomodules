using System;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Bamboo.Abp.VerificationCode;

public interface IVerificationCodeManager
{
    Task<string> GenerateAsync(string codeCacheKey, TimeSpan codeCacheLifespan, [NotNull] VerificationCodeConfiguration configuration);
    Task<string> GenerateAsync(string codeCacheKey, string data, TimeSpan codeCacheLifespan, [NotNull] VerificationCodeConfiguration configuration);

    Task<VerificationCodeCacheItem?> ValidateAsync(string codeCacheKey, string verificationCode, [NotNull] VerificationCodeConfiguration configuration);
    Task<VerificationCodeCacheItem?> ValidateReceiveAsync(string codeCacheKey, string verificationCode, [NotNull] VerificationCodeConfiguration configuration);
}