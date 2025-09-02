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
    public interface IMaintenanceRequestAppService : IGenericApplicationService<MaintenanceRequest>
    {
        Task<MaintenanceRequest> ActivityUpdateAsync(Guid id);
        Task<MaintenanceRequest> ArchiveEquipmentRequestAsync(Guid id);
        Task<MaintenanceRequest> MessageNewAsync(Guid id, MaintenanceRequestMessageNewRequestDto input);
        Task<MaintenanceRequest> ResetEquipmentRequestAsync(Guid id);
    }
}