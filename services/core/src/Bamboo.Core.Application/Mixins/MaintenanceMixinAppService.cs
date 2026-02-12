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
    [Module("maintenance", Category = "SupplyChain", Depends = new[] { "mail" })]
    public partial class MaintenanceMixinAppService : ApplicationService, IMaintenanceMixinAppService
    {

        public MaintenanceMixinAppService() 
        {

        }

        public async Task<TEntity> ComputeDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMaintenanceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMaintenanceCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMaintenanceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: _compute_maintenance_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMaintenanceRequestInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMaintenanceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: _compute_maintenance_request) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMaintenanceTeamIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMaintenanceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: _compute_maintenance_team_id) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IMaintenanceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: create) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeCategoryIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMaintenanceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: _onchange_category_id) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ReadGroupCategoryIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object categories, object domain) where TEntity : IEntity<Guid>, IMaintenanceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: _read_group_category_ids) ---
            */
            return default;
        }

        public async Task<TEntity> TrackSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object init_values) where TEntity : IEntity<Guid>, IMaintenanceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: _track_subtype) ---
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IMaintenanceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: write) ---
            */
            return default;
        }
    }
}