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
    [Module("AuthPasskey", Category = "Base", Depends = new[] { "base_setup", "web" })]
    public partial class AuthPasskeyKeyAppService : GenericAppService<AuthPasskeyKey>, IAuthPasskeyKeyAppService
    {

        public AuthPasskeyKeyAppService(IRepository<AuthPasskeyKey, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        public async Task<AuthPasskeyKey> DeletePasskeyAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_passkey, FILE: auth_passkey_key.py, METHOD: action_delete_passkey) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AuthPasskeyKey> InitAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_passkey, FILE: auth_passkey_key.py, METHOD: init) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AuthPasskeyKey> RenamePasskeyAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_passkey, FILE: auth_passkey_key.py, METHOD: action_rename_passkey) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}