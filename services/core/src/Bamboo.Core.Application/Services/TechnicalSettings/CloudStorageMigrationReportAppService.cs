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
    [Module("CloudStorageMigration", Category = "TechnicalSettings", Depends = new[] { "cloud_storage" })]
    public partial class CloudStorageMigrationReportAppService : GenericAppService<CloudStorageMigrationReport>, ICloudStorageMigrationReportAppService
    {

        public CloudStorageMigrationReportAppService(IRepository<CloudStorageMigrationReport, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        public async Task<CloudStorageMigrationReport> GetProgressAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: cloud_storage_migration, FILE: cloud_storage_migration_report.py, METHOD: get_progress) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CloudStorageMigrationReport> InitAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: cloud_storage_migration, FILE: cloud_storage_migration_report.py, METHOD: init) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}