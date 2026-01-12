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
    public interface IHrWorkEntryAppService : IGenericApplicationService<HrWorkEntry>
    {
        Task<HrWorkEntry> ApproveLeaveAsync(Guid id);
        Task<HrWorkEntry> GetUnusualDaysAsync(Guid id, HrWorkEntryGetUnusualDaysRequestDto input);
        Task<HrWorkEntry> RefuseLeaveAsync(Guid id);
        Task<HrWorkEntry> SplitAsync(Guid id, HrWorkEntrySplitRequestDto input);
        Task<HrWorkEntry> ValidateAsync(Guid id);
    }
}