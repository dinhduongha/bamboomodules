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
    [Module("Stock", Category = "SupplyChain", Depends = new[] { "product", "barcodes_gs1_nomenclature", "digest" })]
    public partial class StockLocationAppService : GenericAppService<StockLocation>, IStockLocationAppService
    {

        public StockLocationAppService(IRepository<StockLocation, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        public async Task<StockLocation> CopyDataAsync(StockLocationCopyDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_location.py, METHOD: copy_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockLocation> IsSubcontractAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_location.py, METHOD: is_subcontract) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockLocation> ShouldBypassReservationAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_location.py, METHOD: should_bypass_reservation) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockLocation> ViewEquipmentsRecordsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_maintenance, FILE: stock_location.py, METHOD: action_view_equipments_records) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}