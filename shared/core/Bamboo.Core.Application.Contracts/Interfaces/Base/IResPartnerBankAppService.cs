using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IResPartnerBankAppService : IGenericApplicationService<ResPartnerBank>
    {
        Task<ResPartnerBank> ArchiveBankAsync(Guid id);
        Task<ResPartnerBank> BuildQrCodeBase64Async(Guid id, ResPartnerBankBuildQrCodeBase64RequestDto input);
        Task<ResPartnerBank> BuildQrCodeUrlAsync(Guid id, ResPartnerBankBuildQrCodeUrlRequestDto input);
        Task<ResPartnerBank> CheckIbanAsync(Guid id, ResPartnerBankCheckIbanRequestDto input);
        Task<ResPartnerBank> GetAvailableQrMethodsInSequenceAsync(Guid id);
        Task<ResPartnerBank> GetBbanAsync(Guid id);
        Task<ResPartnerBank> GetSupportedAccountTypesAsync(Guid id);
        Task<ResPartnerBank> RetrieveAccTypeAsync(Guid id, ResPartnerBankRetrieveAccTypeRequestDto input);
    }
}