using JetBrains.Annotations;

namespace Bamboo.Abp.VerificationCode;

public class VerificationCodeCacheItem
{
    [NotNull]
    public string Code { get; }

    public string Data { get; }

    public VerificationCodeCacheItem(
        [NotNull] string code, string data)
    {
        Code = code;
        Data = data;
    }
}