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
    public interface IResPartnerBankAppService : IGenericAppService<ResPartnerBank>
    {
        Task<ResPartnerBank> ArchiveBankAsync(Guid[] ids);
        Task<ResPartnerBank> BuildQrCodeBase64Async(ResPartnerBankBuildQrCodeBase64RequestDto input);
        Task<ResPartnerBank> BuildQrCodeUrlAsync(ResPartnerBankBuildQrCodeUrlRequestDto input);
        Task<ResPartnerBank> CheckIbanAsync(ResPartnerBankCheckIbanRequestDto input);
        Task<ResPartnerBank> GetAvailableQrMethodsInSequenceAsync(Guid[] ids);
        Task<ResPartnerBank> GetBbanAsync(Guid[] ids);
        Task<ResPartnerBank> GetSupportedAccountTypesAsync(Guid[] ids);
        Task<ResPartnerBank> OpenAllocationWizardAsync(Guid[] ids);
        Task<ResPartnerBank> RetrieveAccTypeAsync(ResPartnerBankRetrieveAccTypeRequestDto input);
    }
}