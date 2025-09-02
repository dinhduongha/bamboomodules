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
    public interface IMrpWorkcenterAppService : IGenericApplicationService<MrpWorkcenter>
    {
        Task<MrpWorkcenter> ArchiveAsync(Guid id);
        Task<MrpWorkcenter> ShowOperationsAsync(Guid id);
        Task<MrpWorkcenter> UnblockAsync(Guid id);
        Task<MrpWorkcenter> WorkOrderAlternativesAsync(Guid id);
        Task<MrpWorkcenter> WorkOrderAsync(Guid id);
    }
}