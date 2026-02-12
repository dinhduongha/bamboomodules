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
    public partial class DecimalPrecisionAppService
    {

        [ApiModel]
        protected async Task<DecimalPrecision> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: decimal_precision.py, METHOD: _load_pos_data_fields) ---
            */
            return default;
        }

        protected async Task<DecimalPrecision> OnchangeDigitsWarningInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: decimal_precision.py, METHOD: _onchange_digits_warning) ---
            */
            return default;
        }
    }
}