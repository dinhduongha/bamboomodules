using Volo.Abp.ObjectMapping;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("PosRestaurant", Category = "Sales", Depends = new[] { "point_of_sale" })]
    public partial class RestaurantFloorAppService : GenericAppService<RestaurantFloor>, IRestaurantFloorAppService
    {
        protected readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public RestaurantFloorAppService(IRepository<RestaurantFloor, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _posLoadMixinAppService = posLoadMixinAppService;
        }

        public async Task<RestaurantFloor> DeactivateFloorAsync(RestaurantFloorDeactivateFloorRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_restaurant.py, METHOD: deactivate_floor) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<RestaurantFloor> RenameFloorAsync(RestaurantFloorRenameFloorRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_restaurant.py, METHOD: rename_floor) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<RestaurantFloor> SyncFromUiAsync(RestaurantFloorSyncFromUiRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_restaurant.py, METHOD: sync_from_ui) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}