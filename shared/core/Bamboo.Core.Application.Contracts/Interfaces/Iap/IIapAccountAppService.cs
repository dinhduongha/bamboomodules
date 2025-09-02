using Bamboo.Core.Application.Contracts.DTOs;
using Volo.Abp.Application.Services;
using System.Linq;
using System.Collections.Generic;
using System;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Models;
using System.Threading.Tasks;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IIapAccountAppService : IGenericApplicationService<IapAccount>
    {
        Task<IapAccount> BuyCreditsAsync(Guid id);
        Task<IapAccount> GetAccountIdAsync(Guid id, IapAccountGetAccountIdRequestDto input);
        Task<IapAccount> GetAsync(Guid id, IapAccountGetRequestDto input);
        Task<IapAccount> GetConfigAccountUrlAsync(Guid id);
        Task<IapAccount> GetCreditsAsync(Guid id, IapAccountGetCreditsRequestDto input);
        Task<IapAccount> GetCreditsUrlAsync(Guid id, IapAccountGetCreditsUrlRequestDto input);
        Task<IapAccount> IsRunningTestSuiteAsync(Guid id);
        Task<IapAccount> OpenRegistrationWizardAsync(Guid id);
        Task<IapAccount> OpenSenderNameWizardAsync(Guid id);
        Task<IapAccount> ValidateWarningAlertsAsync(Guid id);
        Task<IapAccount> WebReadAsync(Guid id);
        Task<IapAccount> WebSaveAsync(Guid id);
    }
}