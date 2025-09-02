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