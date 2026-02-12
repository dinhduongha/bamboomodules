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
    public partial class IrAttachmentAppService : GenericAppService<IrAttachment>, IIrAttachmentAppService
    {
        protected readonly IBusListenerMixinAppService _busListenerMixinAppService;
        public IrAttachmentAppService(IRepository<IrAttachment, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IBusListenerMixinAppService busListenerMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _busListenerMixinAppService = busListenerMixinAppService;
        }

        [ApiModel]
        public async Task<IrAttachment> CheckAsync(IrAttachmentCheckRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: check) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<IrAttachment> CopyAsync(CopyRequestDto<IrAttachment> input)
        {
            /*
            --- METHOD SOURCE (MODULE: attachment_indexation, FILE: ir_attachment.py, METHOD: copy) ---
            */
            return await base.CopyAsync(input);
        }

        public async Task<IrAttachment> CopyDataAsync(IrAttachmentCopyDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: copy_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<IrAttachment> CreateAsync(CreateRequestDto<IrAttachment> input)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: ir_attachment.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: website, FILE: ir_attachment.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        [ApiModel]
        public async Task<IrAttachment> CreateUniqueAsync(IrAttachmentCreateUniqueRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: create_unique) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<IrAttachment> ForceStorageAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: force_storage) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<IrAttachment> GenerateAccessTokenAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: generate_access_token) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<IrAttachment> GetAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: action_get) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<IrAttachment> GetServingGroupsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_attachment.py, METHOD: get_serving_groups) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: get_serving_groups) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<IrAttachment> InitAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: ir_attachment.py, METHOD: init) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<IrAttachment> PreviewAttachmentAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_fleet, FILE: ir_attachment.py, METHOD: action_preview_attachment) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<IrAttachment> RegenerateAssetsBundlesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: regenerate_assets_bundles) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<IrAttachment> RegisterAsMainAttachmentAsync(IrAttachmentRegisterAsMainAttachmentRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_attachment.py, METHOD: register_as_main_attachment) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<object> UnlinkAsync(List<Guid> ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: ir_attachment.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: unlink) ---
            */
            return await base.UnlinkAsync(ids);
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<IrAttachment> input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: ir_attachment.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_attachment.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}