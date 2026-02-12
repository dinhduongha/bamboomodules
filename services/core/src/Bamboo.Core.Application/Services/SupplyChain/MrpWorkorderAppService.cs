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
    [Module("Mrp", Category = "SupplyChain", Depends = new[] { "product", "stock", "resource" })]
    public partial class MrpWorkorderAppService : GenericAppService<MrpWorkorder>, IMrpWorkorderAppService
    {

        public MrpWorkorderAppService(IRepository<MrpWorkorder, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        public async Task<MrpWorkorder> ButtonFinishAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: button_finish) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpWorkorder> ButtonPendingAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: button_pending) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpWorkorder> ButtonScrapAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: button_scrap) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpWorkorder> ButtonStartAsync(MrpWorkorderButtonStartRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: button_start) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpWorkorder> ButtonUnblockAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: button_unblock) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpWorkorder> CancelAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: action_cancel) ---
            --- METHOD SOURCE (MODULE: mrp_account, FILE: mrp_workorder.py, METHOD: action_cancel) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpWorkorder> EndAllAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: end_all) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpWorkorder> EndPreviousAsync(MrpWorkorderEndPreviousRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: end_previous) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpWorkorder> GetDurationAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: get_duration) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpWorkorder> GetWorkingDurationAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: get_working_duration) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpWorkorder> MarkAsDoneAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: action_mark_as_done) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpWorkorder> OpenWizardAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: action_open_wizard) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpWorkorder> ReplanAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: action_replan) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpWorkorder> SeeMoveScrapAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: action_see_move_scrap) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpWorkorder> SetStateAsync(MrpWorkorderSetStateRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: set_state) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<object> UnlinkAsync(List<Guid> ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: mrp_account, FILE: mrp_workorder.py, METHOD: unlink) ---
            */
            return await base.UnlinkAsync(ids);
        }
    }
}