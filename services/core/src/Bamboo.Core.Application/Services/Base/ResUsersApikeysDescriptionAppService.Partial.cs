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
    public partial class ResUsersApikeysDescriptionAppService
    {

        protected async Task<ResUsersApikeysDescription> ComputeExpirationDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _compute_expiration_date) ---
            */
            return default;
        }

        protected async Task<ResUsersApikeysDescription> OnchangeExpirationDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _onchange_expiration_date) ---
            */
            return default;
        }

        protected async Task<ResUsersApikeysDescription> SelectionDurationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: _selection_duration) ---
            */
            return default;
        }
    }
}