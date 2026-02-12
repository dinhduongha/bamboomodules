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
    [Module("DataRecycle", Category = "Productivity", Depends = new[] { "mail" })]
    public partial class DataRecycleModelAppService : GenericAppService<DataRecycleModel>, IDataRecycleModelAppService
    {

        public DataRecycleModelAppService(IRepository<DataRecycleModel, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        public async Task<DataRecycleModel> OpenRecordsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: data_recycle, FILE: data_recycle_model.py, METHOD: open_records) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<DataRecycleModel> RecycleRecordsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: data_recycle, FILE: data_recycle_model.py, METHOD: action_recycle_records) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}