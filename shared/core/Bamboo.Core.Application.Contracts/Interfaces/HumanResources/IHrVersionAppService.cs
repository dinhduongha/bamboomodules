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
    public interface IHrVersionAppService : IGenericApplicationService<HrVersion>
    {
        Task<HrVersion> CheckContractFinishedAsync(Guid id);
        Task<HrVersion> GenerateWorkEntriesAsync(Guid id, HrVersionGenerateWorkEntriesRequestDto input);
        Task<HrVersion> GetFormviewActionAsync(Guid id, HrVersionGetFormviewActionRequestDto input);
        Task<HrVersion> GetValuesFromContractTemplateAsync(Guid id, HrVersionGetValuesFromContractTemplateRequestDto input);
        Task<HrVersion> HasStaticWorkEntriesAsync(Guid id);
        Task<HrVersion> OpenVersionAsync(Guid id);
    }
}