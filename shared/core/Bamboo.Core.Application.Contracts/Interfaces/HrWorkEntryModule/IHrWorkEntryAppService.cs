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
    public interface IHrWorkEntryAppService : IGenericApplicationService<HrWorkEntry>
    {
        Task<HrWorkEntry> ApproveLeaveAsync(Guid id);
        Task<HrWorkEntry> InitAsync(Guid id);
        Task<HrWorkEntry> RefuseLeaveAsync(Guid id);
        Task<HrWorkEntry> ValidateAsync(Guid id);
    }
}