using System.Threading.Tasks;

namespace Bamboo.Abp.VerificationCode;

public interface IVerificationCodeGenerator
{
    Task<string> CreateAsync(VerificationCodeConfiguration configuration);
}