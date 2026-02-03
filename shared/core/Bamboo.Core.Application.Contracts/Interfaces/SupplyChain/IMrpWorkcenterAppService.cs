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
    public interface IMrpWorkcenterAppService : IGenericApplicationService<MrpWorkcenter>
    {
        Task<MrpWorkcenter> ArchiveAsync(Guid[] ids);
        Task<MrpWorkcenter> ShowOperationsAsync(Guid[] ids);
        Task<MrpWorkcenter> UnblockAsync(Guid[] ids);
        Task<MrpWorkcenter> WorkOrderAlternativesAsync(Guid[] ids);
        Task<MrpWorkcenter> WorkOrderAsync(Guid[] ids);
    }
}