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
    public interface IPosPresetAppService : IGenericApplicationService<PosPreset>
    {
        Task<PosPreset> GetAvailableSlotsAsync(Guid id);
        Task<PosPreset> OpenLinkedConfigAsync(Guid id);
        Task<PosPreset> OpenLinkedOrdersAsync(Guid id);
    }
}