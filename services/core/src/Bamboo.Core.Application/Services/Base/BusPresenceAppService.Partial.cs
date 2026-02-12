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
    public partial class BusPresenceAppService
    {

        protected async Task<BusPresence> GcBusPresenceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: bus, FILE: bus_presence.py, METHOD: _gc_bus_presence) ---
            */
            return default;
        }

        protected async Task<BusPresence> GetBusTargetInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: bus, FILE: bus_presence.py, METHOD: _get_bus_target) ---
            --- METHOD SOURCE (MODULE: mail, FILE: bus_presence.py, METHOD: _get_bus_target) ---
            */
            return default;
        }

        protected async Task<BusPresence> GetIdentityDataInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: bus, FILE: bus_presence.py, METHOD: _get_identity_data) ---
            --- METHOD SOURCE (MODULE: mail, FILE: bus_presence.py, METHOD: _get_identity_data) ---
            */
            return default;
        }

        protected async Task<BusPresence> GetIdentityFieldNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: bus, FILE: bus_presence.py, METHOD: _get_identity_field_name) ---
            --- METHOD SOURCE (MODULE: mail, FILE: bus_presence.py, METHOD: _get_identity_field_name) ---
            */
            return default;
        }

        protected async Task<BusPresence> InvalidateImStatusInternalAsync(object fnames, object flush)
        {
            /*
            --- METHOD SOURCE (MODULE: bus, FILE: bus_presence.py, METHOD: _invalidate_im_status) ---
            --- METHOD SOURCE (MODULE: mail, FILE: bus_presence.py, METHOD: _invalidate_im_status) ---
            */
            return default;
        }

        protected async Task<BusPresence> SendPresenceInternalAsync(object im_status, object bus_target)
        {
            /*
            --- METHOD SOURCE (MODULE: bus, FILE: bus_presence.py, METHOD: _send_presence) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<BusPresence> UpdatePresenceInternalAsync(object inactivity_period, object identity_field, object identity_value)
        {
            /*
            --- METHOD SOURCE (MODULE: bus, FILE: bus_presence.py, METHOD: _update_presence) ---
            */
            return default;
        }
    }
}