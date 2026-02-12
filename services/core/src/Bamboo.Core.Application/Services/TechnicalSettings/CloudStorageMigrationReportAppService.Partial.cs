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
    public partial class CloudStorageMigrationReportAppService
    {

        protected async Task<CloudStorageMigrationReport> ComputeAllToMigrateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: cloud_storage_migration, FILE: cloud_storage_migration_report.py, METHOD: _compute_all_to_migrate) ---
            */
            return default;
        }

        protected async Task<CloudStorageMigrationReport> ComputeHasAttachmentRelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: cloud_storage_migration, FILE: cloud_storage_migration_report.py, METHOD: _compute_has_attachment_rel) ---
            */
            return default;
        }

        protected async Task<CloudStorageMigrationReport> ComputeMessageToMigrateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: cloud_storage_migration, FILE: cloud_storage_migration_report.py, METHOD: _compute_message_to_migrate) ---
            */
            return default;
        }

        protected async Task<CloudStorageMigrationReport> ComputeResModelNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: cloud_storage_migration, FILE: cloud_storage_migration_report.py, METHOD: _compute_res_model_name) ---
            */
            return default;
        }
    }
}