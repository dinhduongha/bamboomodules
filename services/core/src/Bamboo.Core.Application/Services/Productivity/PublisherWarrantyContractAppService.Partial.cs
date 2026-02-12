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
    public partial class PublisherWarrantyContractAppService
    {

        [ApiModel]
        protected async Task<PublisherWarrantyContract> GetMessageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: update.py, METHOD: _get_message) ---
            --- METHOD SOURCE (MODULE: website_mail, FILE: update.py, METHOD: _get_message) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PublisherWarrantyContract> GetSysLogsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: update.py, METHOD: _get_sys_logs) ---
            */
            return default;
        }
    }
}