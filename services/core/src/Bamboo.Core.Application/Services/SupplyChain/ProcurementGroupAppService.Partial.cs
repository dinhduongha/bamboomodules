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
    public partial class ProcurementGroupAppService
    {

        [ApiModel]
        protected async Task<ProcurementGroup> CheckIntercompLocationInternalAsync(object locations)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_rule.py, METHOD: _check_intercomp_location) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProcurementGroup> GetMovesToAssignDomainInternalAsync(Guid company_id)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_rule.py, METHOD: _get_moves_to_assign_domain) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_rule.py, METHOD: _get_moves_to_assign_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProcurementGroup> GetOrderpointDomainInternalAsync(Guid company_id)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_rule.py, METHOD: _get_orderpoint_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProcurementGroup> GetPushRuleInternalAsync(Guid product_id, Guid location_dest_id, object values)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_rule.py, METHOD: _get_push_rule) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProcurementGroup> GetRuleDomainInternalAsync(object location, object values)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_rule.py, METHOD: _get_rule_domain) ---
            --- METHOD SOURCE (MODULE: stock_dropshipping, FILE: stock.py, METHOD: _get_rule_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProcurementGroup> GetRuleInternalAsync(Guid product_id, Guid location_id, object values)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_rule.py, METHOD: _get_rule) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProcurementGroup> GetSchedulerTasksToDoInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_scheduler_tasks_to_do) ---
            --- METHOD SOURCE (MODULE: product_expiry, FILE: production_lot.py, METHOD: _get_scheduler_tasks_to_do) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_rule.py, METHOD: _get_scheduler_tasks_to_do) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProcurementGroup> RunSchedulerTasksInternalAsync(object use_new_cursor, Guid company_id)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _run_scheduler_tasks) ---
            --- METHOD SOURCE (MODULE: product_expiry, FILE: production_lot.py, METHOD: _run_scheduler_tasks) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_rule.py, METHOD: _run_scheduler_tasks) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProcurementGroup> SearchRuleForWarehousesInternalAsync(List<Guid> route_ids, Guid packaging_id, Guid product_id, List<Guid> warehouse_ids, object domain)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_rule.py, METHOD: _search_rule_for_warehouses) ---
            */
            return default;
        }

        protected async Task<ProcurementGroup> SearchRuleInternalAsync(List<Guid> route_ids, Guid packaging_id, Guid product_id, Guid warehouse_id, object domain)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_rule.py, METHOD: _search_rule) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProcurementGroup> SkipProcurementInternalAsync(object procurement)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_rule.py, METHOD: _skip_procurement) ---
            */
            return default;
        }
    }
}