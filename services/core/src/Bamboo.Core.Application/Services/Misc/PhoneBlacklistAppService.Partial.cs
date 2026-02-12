using System;
using System.Threading.Tasks;
using System.Collections.Generic;
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
    public partial class PhoneBlacklistAppService
    {

        protected async Task<PhoneBlacklist> AddInternalAsync(object numbers, object message)
        {
            /*
            --- METHOD SOURCE (MODULE: phone_validation, FILE: phone_blacklist.py, METHOD: _add) ---
            */
            return default;
        }

        protected async Task<PhoneBlacklist> RemoveInternalAsync(object numbers, object message)
        {
            /*
            --- METHOD SOURCE (MODULE: phone_validation, FILE: phone_blacklist.py, METHOD: _remove) ---
            */
            return default;
        }

        protected async Task<PhoneBlacklist> SearchNumberInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: phone_validation, FILE: phone_blacklist.py, METHOD: _search_number) ---
            */
            return default;
        }
    }
}