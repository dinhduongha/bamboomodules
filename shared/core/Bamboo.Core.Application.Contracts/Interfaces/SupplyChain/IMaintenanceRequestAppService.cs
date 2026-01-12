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
    public interface IMaintenanceRequestAppService : IGenericApplicationService<MaintenanceRequest>
    {
        Task<MaintenanceRequest> ActivityUpdateAsync(Guid id);
        Task<MaintenanceRequest> ArchiveEquipmentRequestAsync(Guid id);
        Task<MaintenanceRequest> MessageNewAsync(Guid id, MaintenanceRequestMessageNewRequestDto input);
        Task<MaintenanceRequest> ResetEquipmentRequestAsync(Guid id);
    }
}