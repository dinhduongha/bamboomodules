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
    public interface IHrVersionAppService : IGenericAppService<HrVersion>
    {
        Task<HrVersion> CheckContractFinishedAsync(Guid[] ids);
        Task<HrVersion> GenerateWorkEntriesAsync(HrVersionGenerateWorkEntriesRequestDto input);
        Task<HrVersion> GetFormviewActionAsync(HrVersionGetFormviewActionRequestDto input);
        Task<HrVersion> GetValuesFromContractTemplateAsync(HrVersionGetValuesFromContractTemplateRequestDto input);
        Task<HrVersion> HasStaticWorkEntriesAsync(Guid[] ids);
        Task<HrVersion> OpenVersionAsync(Guid[] ids);
    }
}