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
    public interface IHrContractAppService : IGenericApplicationService<HrContract>
    {
        Task<HrContract> GenerateWorkEntriesAsync(Guid id, HrContractGenerateWorkEntriesRequestDto input);
        Task<HrContract> GetAllStructuresAsync(Guid id);
        Task<HrContract> GetAttributeAsync(Guid id, HrContractGetAttributeRequestDto input);
        Task<HrContract> HasStaticWorkEntriesAsync(Guid id);
        Task<HrContract> OpenContractFormAsync(Guid id);
        Task<HrContract> OpenContractHistoryAsync(Guid id);
        Task<HrContract> OpenContractListAsync(Guid id);
        Task<HrContract> SetAttributeValueAsync(Guid id, HrContractSetAttributeValueRequestDto input);
        Task<HrContract> UpdateStateAsync(Guid id);
    }
}