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
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Interfaces;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("base_setup", Category = "Base", Depends = new[] { "base", "web" })]
    public partial class KpiProviderAppService : ApplicationService, IKpiProviderAppService
    {

        public KpiProviderAppService() 
        {

        }

        [ApiModel]
        public async Task<TEntity> GetAccountKpiSummaryAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IKpiProviderable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: kpi_provider.py, METHOD: get_account_kpi_summary) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetKpiSummaryAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IKpiProviderable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: kpi_provider.py, METHOD: get_kpi_summary) ---
            --- METHOD SOURCE (MODULE: base_setup, FILE: kpi_provider.py, METHOD: get_kpi_summary) ---
            */
            return default;
        }
    }
}