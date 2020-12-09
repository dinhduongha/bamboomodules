using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Bamboo.Account.Samples
{
    public interface ISampleAppService : IApplicationService
    {
        Task<SampleDto> GetAsync();

        Task<SampleDto> GetAuthorizedAsync();
    }
}
