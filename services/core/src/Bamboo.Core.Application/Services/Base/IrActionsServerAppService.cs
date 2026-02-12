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
    [Module("BaseModule", Category = "Base")]
    public partial class IrActionsServerAppService : GenericAppService<IrActServer>, IIrActionsServerAppService
    {
        protected readonly IIrActionsActionsAppService _irActionsActionsAppService;
        protected readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        protected readonly IMailThreadAppService _mailThreadAppService;
        public IrActionsServerAppService(IRepository<IrActServer, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IIrActionsActionsAppService irActionsActionsAppService, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _irActionsActionsAppService = irActionsActionsAppService;
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
        }

        public async Task<IrActServer> CopyDataAsync(IrActionsServerCopyDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: copy_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<IrActServer> CreateActionAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: create_action) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<IrActServer> HistoryWizardActionAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: history_wizard_action) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<IrActServer> OpenAutomationAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: ir_actions_server.py, METHOD: action_open_automation) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<IrActServer> OpenParentActionAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: action_open_parent_action) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<IrActServer> OpenScheduledActionAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: action_open_scheduled_action) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<IrActServer> RunAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: run) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<IrActServer> UnlinkActionAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: unlink_action) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}