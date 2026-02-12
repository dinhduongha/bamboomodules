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
    [Module("StockPickingBatchModule", Category = "SupplyChain", Depends = new[] { "stock" })]
    public partial class StockPickingBatchAppService : GenericAppService<StockPickingBatch>, IStockPickingBatchAppService
    {
        protected readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        protected readonly IMailThreadAppService _mailThreadAppService;
        public StockPickingBatchAppService(IRepository<StockPickingBatch, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
        }

        public async Task<StockPickingBatch> AssignAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: action_assign) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockPickingBatch> BatchDetailedOperationsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: action_batch_detailed_operations) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockPickingBatch> CancelAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: action_cancel) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockPickingBatch> ConfirmAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: action_confirm) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<StockPickingBatch> CreateAsync(CreateRequestDto<StockPickingBatch> input)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_fleet, FILE: stock_picking_batch.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        public async Task<StockPickingBatch> DoneAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: action_done) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockPickingBatch> MergeAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: action_merge) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockPickingBatch> OnchangeScheduledDateAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: onchange_scheduled_date) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockPickingBatch> OpenLabelLayoutAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: action_open_label_layout) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockPickingBatch> OrderOnZipAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_fleet, FILE: stock_picking_batch.py, METHOD: order_on_zip) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockPickingBatch> PrintAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: action_print) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockPickingBatch> PutInPackAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: action_put_in_pack) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockPickingBatch> SeePackagesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: action_see_packages) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockPickingBatch> ViewReceptionReportAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: action_view_reception_report) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<StockPickingBatch> input)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_fleet, FILE: stock_picking_batch.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}