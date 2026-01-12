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
    public interface IRestaurantFloorAppService : IGenericApplicationService<RestaurantFloor>
    {
        Task<RestaurantFloor> DeactivateFloorAsync(Guid id, RestaurantFloorDeactivateFloorRequestDto input);
        Task<RestaurantFloor> RenameFloorAsync(Guid id, RestaurantFloorRenameFloorRequestDto input);
        Task<RestaurantFloor> SyncFromUiAsync(Guid id, RestaurantFloorSyncFromUiRequestDto input);
    }
}