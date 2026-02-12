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
    [Module("Digest", Category = "Marketing", Depends = new[] { "mail", "portal", "resource" })]
    public partial class DigestDigestAppService : GenericAppService<DigestDigest>, IDigestDigestAppService
    {

        public DigestDigestAppService(IRepository<DigestDigest, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        public async Task<DigestDigest> ActivateAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: digest, FILE: digest.py, METHOD: action_activate) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<DigestDigest> DeactivateAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: digest, FILE: digest.py, METHOD: action_deactivate) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<DigestDigest> SendAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: digest, FILE: digest.py, METHOD: action_send) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<DigestDigest> SendManualAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: digest, FILE: digest.py, METHOD: action_send_manual) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<DigestDigest> SetPeriodicityAsync(DigestDigestSetPeriodicityRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: digest, FILE: digest.py, METHOD: action_set_periodicity) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<DigestDigest> SubscribeAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: digest, FILE: digest.py, METHOD: action_subscribe) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<DigestDigest> UnsubscribeAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: digest, FILE: digest.py, METHOD: action_unsubscribe) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}