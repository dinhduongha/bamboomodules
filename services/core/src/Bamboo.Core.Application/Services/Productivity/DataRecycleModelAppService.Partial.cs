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
    public partial class DataRecycleModelAppService
    {

        protected async Task<DataRecycleModel> CheckRecycleActionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: data_recycle, FILE: data_recycle_model.py, METHOD: _check_recycle_action) ---
            */
            return default;
        }

        protected async Task<DataRecycleModel> ComputeDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: data_recycle, FILE: data_recycle_model.py, METHOD: _compute_domain) ---
            */
            return default;
        }

        protected async Task<DataRecycleModel> ComputeNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: data_recycle, FILE: data_recycle_model.py, METHOD: _compute_name) ---
            */
            return default;
        }

        protected async Task<DataRecycleModel> ComputeRecordsToRecycleCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: data_recycle, FILE: data_recycle_model.py, METHOD: _compute_records_to_recycle_count) ---
            */
            return default;
        }

        protected async Task<DataRecycleModel> CronRecycleRecordsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: data_recycle, FILE: data_recycle_model.py, METHOD: _cron_recycle_records) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<DataRecycleModel> NotifyRecordsToRecycleInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: data_recycle, FILE: data_recycle_model.py, METHOD: _notify_records_to_recycle) ---
            */
            return default;
        }

        protected async Task<DataRecycleModel> RecycleRecordsInternalAsync(object batch_commits)
        {
            /*
            --- METHOD SOURCE (MODULE: data_recycle, FILE: data_recycle_model.py, METHOD: _recycle_records) ---
            */
            return default;
        }

        protected async Task<DataRecycleModel> SendNotificationInternalAsync(object delta)
        {
            /*
            --- METHOD SOURCE (MODULE: data_recycle, FILE: data_recycle_model.py, METHOD: _send_notification) ---
            */
            return default;
        }
    }
}