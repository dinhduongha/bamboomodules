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
    public interface IMrpRoutingWorkcenterAppService : IGenericApplicationService<MrpRoutingWorkcenter>
    {
        Task<MrpRoutingWorkcenter> ArchiveAsync(Guid id);
        Task<MrpRoutingWorkcenter> CopyExistingOperationsAsync(Guid id);
        Task<MrpRoutingWorkcenter> CopyToBomAsync(Guid id);
        Task<MrpRoutingWorkcenter> UnarchiveAsync(Guid id);
    }
}