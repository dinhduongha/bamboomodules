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
    public partial class MailBlacklistAppService
    {

        protected async Task<MailBlacklist> AddInternalAsync(object email, object message)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_blacklist.py, METHOD: _add) ---
            */
            return default;
        }

        protected async Task<MailBlacklist> RemoveInternalAsync(object email, object message)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_blacklist.py, METHOD: _remove) ---
            */
            return default;
        }

        protected async Task<MailBlacklist> SearchInternalAsync(object domain)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_blacklist.py, METHOD: _search) ---
            */
            return default;
        }

        protected async Task<MailBlacklist> TrackSubtypeInternalAsync(object init_values)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mail_blacklist.py, METHOD: _track_subtype) ---
            */
            return default;
        }
    }
}