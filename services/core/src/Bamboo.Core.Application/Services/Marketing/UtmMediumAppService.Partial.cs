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
    public partial class UtmMediumAppService
    {

        protected async Task<UtmMedium> FetchOrCreateUtmMediumInternalAsync(object name, object module)
        {
            /*
            --- METHOD SOURCE (MODULE: utm, FILE: utm_medium.py, METHOD: _fetch_or_create_utm_medium) ---
            */
            return default;
        }

        protected async Task<UtmMedium> UnlinkExceptLinkedMailingsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: utm_medium.py, METHOD: _unlink_except_linked_mailings) ---
            */
            return default;
        }

        protected async Task<UtmMedium> UnlinkExceptUtmMediumRecordInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: utm, FILE: utm_medium.py, METHOD: _unlink_except_utm_medium_record) ---
            */
            return default;
        }

        protected async Task<UtmMedium> UnlinkExceptUtmMediumSmsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing_sms, FILE: utm.py, METHOD: _unlink_except_utm_medium_sms) ---
            */
            return default;
        }
    }
}