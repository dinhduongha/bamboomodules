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
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("Lunch", Category = "HumanResources", Depends = new[] { "mail" })]
    public partial class LunchOrderAppService : GenericAppService<LunchOrder>, ILunchOrderAppService
    {

        public LunchOrderAppService(IRepository<LunchOrder, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        public async Task<LunchOrder> AddToCartAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_order.py, METHOD: add_to_cart) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<LunchOrder> CancelAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_order.py, METHOD: action_cancel) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<LunchOrder> ConfirmAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_order.py, METHOD: action_confirm) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<LunchOrder> NotifyAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_order.py, METHOD: action_notify) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<LunchOrder> OrderAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_order.py, METHOD: action_order) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<LunchOrder> ReorderAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_order.py, METHOD: action_reorder) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<LunchOrder> ResetAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_order.py, METHOD: action_reset) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<LunchOrder> SendAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_order.py, METHOD: action_send) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<LunchOrder> UpdateQuantityAsync(LunchOrderUpdateQuantityRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_order.py, METHOD: update_quantity) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}