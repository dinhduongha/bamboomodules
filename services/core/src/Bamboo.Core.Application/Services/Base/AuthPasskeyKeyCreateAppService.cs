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
    public partial class AuthPasskeyKeyCreateAppService : GenericAppService<AuthPasskeyKeyCreate>, IAuthPasskeyKeyCreateAppService
    {

        public AuthPasskeyKeyCreateAppService(IRepository<AuthPasskeyKeyCreate, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        public async Task<AuthPasskeyKeyCreate> MakeKeyAsync(AuthPasskeyKeyCreateMakeKeyRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_passkey, FILE: auth_passkey_key.py, METHOD: make_key) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}