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
    [Module("PurchaseRequisitionModule", Category = "SupplyChain", Depends = new[] { "purchase" })]
    public partial class PurchaseRequisitionAppService : GenericAppService<PurchaseRequisition>, IPurchaseRequisitionAppService
    {
        protected readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        protected readonly IMailThreadAppService _mailThreadAppService;
        public PurchaseRequisitionAppService(IRepository<PurchaseRequisition, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
        }

        public async Task<PurchaseRequisition> CancelAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase_requisition.py, METHOD: action_cancel) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PurchaseRequisition> ConfirmAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase_requisition.py, METHOD: action_confirm) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PurchaseRequisition> DoneAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase_requisition.py, METHOD: action_done) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PurchaseRequisition> DraftAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase_requisition.py, METHOD: action_draft) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}