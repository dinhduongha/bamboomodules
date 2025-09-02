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
    public interface IRestaurantFloorAppService : IGenericApplicationService<RestaurantFloor>
    {
        Task<RestaurantFloor> DeactivateFloorAsync(Guid id, RestaurantFloorDeactivateFloorRequestDto input);
        Task<RestaurantFloor> RenameFloorAsync(Guid id, RestaurantFloorRenameFloorRequestDto input);
        Task<RestaurantFloor> SyncFromUiAsync(Guid id, RestaurantFloorSyncFromUiRequestDto input);
    }
}