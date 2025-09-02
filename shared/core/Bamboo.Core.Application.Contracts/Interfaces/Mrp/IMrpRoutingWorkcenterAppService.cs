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
    public interface IMrpRoutingWorkcenterAppService : IGenericApplicationService<MrpRoutingWorkcenter>
    {
        Task<MrpRoutingWorkcenter> ArchiveAsync(Guid id);
        Task<MrpRoutingWorkcenter> CopyExistingOperationsAsync(Guid id);
        Task<MrpRoutingWorkcenter> CopyToBomAsync(Guid id);
        Task<MrpRoutingWorkcenter> UnarchiveAsync(Guid id);
    }
}