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
    public interface IMrpWorkcenterAppService : IGenericApplicationService<MrpWorkcenter>
    {
        Task<MrpWorkcenter> ArchiveAsync(Guid id);
        Task<MrpWorkcenter> ShowOperationsAsync(Guid id);
        Task<MrpWorkcenter> UnblockAsync(Guid id);
        Task<MrpWorkcenter> WorkOrderAlternativesAsync(Guid id);
        Task<MrpWorkcenter> WorkOrderAsync(Guid id);
    }
}