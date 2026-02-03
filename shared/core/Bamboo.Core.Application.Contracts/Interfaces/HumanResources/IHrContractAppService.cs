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
    public interface IHrContractAppService : IGenericAppService<HrContract>
    {
        Task<HrContract> GenerateWorkEntriesAsync(HrContractGenerateWorkEntriesRequestDto input);
        Task<HrContract> GetAllStructuresAsync(Guid[] ids);
        Task<HrContract> GetAttributeAsync(HrContractGetAttributeRequestDto input);
        Task<HrContract> HasStaticWorkEntriesAsync(Guid[] ids);
        Task<HrContract> OpenContractFormAsync(Guid[] ids);
        Task<HrContract> OpenContractHistoryAsync(Guid[] ids);
        Task<HrContract> OpenContractListAsync(Guid[] ids);
        Task<HrContract> SetAttributeValueAsync(HrContractSetAttributeValueRequestDto input);
        Task<HrContract> UpdateStateAsync(Guid[] ids);
    }
}