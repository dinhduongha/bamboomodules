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
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Services
{
    public partial class DataRecycleRecordAppService
    {

        protected async Task<DataRecycleRecord> ComputeCompanyIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: data_recycle, FILE: data_recycle_record.py, METHOD: _compute_company_id) ---
            */
            return default;
        }

        protected async Task<DataRecycleRecord> ComputeNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: data_recycle, FILE: data_recycle_record.py, METHOD: _compute_name) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<DataRecycleRecord> GetCompanyIdInternalAsync(object record)
        {
            /*
            --- METHOD SOURCE (MODULE: data_recycle, FILE: data_recycle_record.py, METHOD: _get_company_id) ---
            */
            return default;
        }

        protected async Task<DataRecycleRecord> OriginalRecordsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: data_recycle, FILE: data_recycle_record.py, METHOD: _original_records) ---
            */
            return default;
        }
    }
}