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
    public interface IMrpRoutingWorkcenterAppService : IGenericAppService<MrpRoutingWorkcenter>
    {
        Task<MrpRoutingWorkcenter> ArchiveAsync(Guid[] ids);
        Task<MrpRoutingWorkcenter> CopyExistingOperationsAsync(Guid[] ids);
        Task<MrpRoutingWorkcenter> CopyToBomAsync(Guid[] ids);
        Task<MrpRoutingWorkcenter> OpenOperationFormAsync(Guid[] ids);
        Task<MrpRoutingWorkcenter> UnarchiveAsync(Guid[] ids);
    }
}