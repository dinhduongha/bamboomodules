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
    public interface IPosPresetAppService : IGenericAppService<PosPreset>
    {
        Task<PosPreset> GetAvailableSlotsAsync(Guid[] ids);
        Task<PosPreset> OpenLinkedConfigAsync(Guid[] ids);
        Task<PosPreset> OpenLinkedOrdersAsync(Guid[] ids);
    }
}