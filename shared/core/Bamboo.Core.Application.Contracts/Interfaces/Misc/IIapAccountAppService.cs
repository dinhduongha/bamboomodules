using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IIapAccountAppService : IGenericApplicationService<IapAccount>
    {
        Task<IapAccount> BuyCreditsAsync(Guid[] ids);
        Task<IapAccount> GetAccountIdAsync(IapAccountGetAccountIdRequestDto input);
        Task<IapAccount> GetAsync(IapAccountGetRequestDto input);
        Task<IapAccount> GetConfigAccountUrlAsync(Guid[] ids);
        Task<IapAccount> GetCreditsAsync(IapAccountGetCreditsRequestDto input);
        Task<IapAccount> GetCreditsUrlAsync(IapAccountGetCreditsUrlRequestDto input);
        Task<IapAccount> OpenRegistrationWizardAsync(Guid[] ids);
        Task<IapAccount> OpenSenderNameWizardAsync(Guid[] ids);
        Task<IapAccount> ValidateWarningAlertsAsync(Guid[] ids);
        Task<IapAccount> WebReadAsync(Guid[] ids);
        Task<IapAccount> WebSaveAsync(Guid[] ids);
    }
}