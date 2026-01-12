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
        Task<HrWorkEntry> InitAsync(Guid id);
        Task<HrWorkEntry> RefuseLeaveAsync(Guid id);
        Task<HrWorkEntry> ValidateAsync(Guid id);
    }
}