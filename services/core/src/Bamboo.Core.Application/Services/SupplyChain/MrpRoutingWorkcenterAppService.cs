using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("Mrp", Category = "SupplyChain", Depends = new[] { "product", "stock", "resource" })]
    public class MrpRoutingWorkcenterAppService : GenericApplicationService<MrpRoutingWorkcenter>, IMrpRoutingWorkcenterAppService
    {
        private readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        private readonly IMailThreadAppService _mailThreadAppService;
        public MrpRoutingWorkcenterAppService(IRepository<MrpRoutingWorkcenter, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
        }

        public async Task<MrpRoutingWorkcenter> ArchiveAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_routing.py) ---
            // def action_archive(self):
            // res = super().action_archive()
            // bom_lines = self.env['mrp.bom.line'].search([('operation_id', 'in', self.ids)])
            // bom_lines.write({'operation_id': False})
            // byproduct_lines = self.env['mrp.bom.byproduct'].search([('operation_id', 'in', self.ids)])
            // byproduct_lines.write({'operation_id': False})
            // self.bom_id._set_outdated_bom_in_productions()
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<MrpRoutingWorkcenter> CheckNoCyclicDependenciesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_routing.py) ---
            // def _check_no_cyclic_dependencies(self):
            // if self._has_cycle('blocked_by_operation_ids'):
            //     raise ValidationError(_("You cannot create cyclic dependency."))
            */
            return default;
        }

        protected async Task<MrpRoutingWorkcenter> ComputeOperationCostInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_routing.py) ---
            // def _compute_operation_cost(self):
            // duration = self.env.context.get('op_duration', self.time_cycle)
            // return (duration / 60.0) * (self.workcenter_id.costs_hour)
            */
            return default;
        }

        protected async Task<MrpRoutingWorkcenter> ComputeTimeComputedOnInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_routing.py) ---
            // def _compute_time_computed_on(self):
            // for operation in self:
            //     operation.time_computed_on = _('%i work orders', operation.time_mode_batch) if operation.time_mode != 'manual' else False
            */
            return default;
        }

        protected async Task<MrpRoutingWorkcenter> ComputeTimeCycleInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_routing.py) ---
            // def _compute_time_cycle(self):
            // manual_ops = self.filtered(lambda operation: operation.time_mode == 'manual')
            // for operation in manual_ops:
            //     operation.time_cycle = operation.time_cycle_manual
            // for operation in self - manual_ops:
            //     data = self.env['mrp.workorder'].search([
            //         ('operation_id', 'in', operation.ids),
            //         ('qty_produced', '>', 0),
            //         ('state', '=', 'done')],
            //         limit=operation.time_mode_batch,
            //         order="date_finished desc, id desc")
            //     # To compute the time_cycle, we can take the total duration of previous operations
            //     # but for the quantity, we will take in consideration the qty_produced like if the capacity was 1.
            //     # So producing 50 in 00:10 with capacity 2, for the time_cycle, we assume it is 25 in 00:10
            //     # When recomputing the expected duration, the capacity is used again to divide the qty to produce
            //     # so that if we need 50 with capacity 2, it will compute the expected of 25 which is 00:10
            //     total_duration = 0  # Can be 0 since it's not an invalid duration for BoM
            //     cycle_number = 0  # Never 0 unless infinite item['workcenter_id'].capacity
            //     for item in data:
            //         total_duration += item['duration']
            //         capacity = item['workcenter_id']._get_capacity(item.product_id)
            //         qty_produced = item.product_uom_id._compute_quantity(item['qty_produced'], item.product_id.uom_id)
            //         cycle_number += float_round((qty_produced / capacity or 1.0), precision_digits=0, rounding_method='UP')
            //     if cycle_number:
            //         operation.time_cycle = total_duration / cycle_number
            //     else:
            //         operation.time_cycle = operation.time_cycle_manual
            */
            return default;
        }

        protected async Task<MrpRoutingWorkcenter> ComputeWorkorderCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_routing.py) ---
            // def _compute_workorder_count(self):
            // data = self.env['mrp.workorder']._read_group([
            //     ('operation_id', 'in', self.ids),
            //     ('state', '=', 'done')], ['operation_id'], ['__count'])
            // count_data = {operation.id: count for operation, count in data}
            // for operation in self:
            //     operation.workorder_count = count_data.get(operation.id, 0)
            */
            return default;
        }

        public async Task<MrpRoutingWorkcenter> CopyExistingOperationsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_routing.py) ---
            // def copy_existing_operations(self):
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': _('Select Operations to Copy'),
            //     'res_model': 'mrp.routing.workcenter',
            //     'view_mode': 'list,form',
            //     'domain': ['|', ('bom_id', '=', False), ('bom_id.active', '=', True)],
            //     'context' : {
            //         'bom_id': self.env.context["bom_id"],
            //         'list_view_ref': 'mrp.mrp_routing_workcenter_copy_to_bom_tree_view',
            //     }
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MrpRoutingWorkcenter> CopyToBomAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_routing.py) ---
            // def copy_to_bom(self):
            // if 'bom_id' in self.env.context:
            //     bom_id = self.env.context.get('bom_id')
            //     for operation in self:
            //         operation.copy({'bom_id': bom_id})
            //     return {
            //         'view_mode': 'form',
            //         'res_model': 'mrp.bom',
            //         'views': [(False, 'form')],
            //         'type': 'ir.actions.act_window',
            //         'res_id': bom_id,
            //     }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<MrpRoutingWorkcenter> GetDurationExpectedInternalAsync(object product, object quantity, object unit, object workcenter)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_routing.py) ---
            // def _get_duration_expected(self, product, quantity, unit=False, workcenter=False):
            // product = product or self.bom_id.product_tmpl_id
            // if self._skip_operation_line(product):
            //     return 0
            // unit = unit or product.uom_id
            // quantity = self.bom_id.product_uom_id._compute_quantity(quantity, unit)
            // workcenter = workcenter or self.workcenter_id
            // capacity = workcenter._get_capacity(product)
            // cycle_number = float_round(quantity / capacity, precision_digits=0, rounding_method='UP')
            // return workcenter._get_expected_duration(product) + cycle_number * self.time_cycle * 100.0 / workcenter.time_efficiency
            */
            return default;
        }

        protected async Task<MrpRoutingWorkcenter> SkipOperationLineInternalAsync(object product)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_routing.py) ---
            // def _skip_operation_line(self, product):
            // """ Control if a operation should be processed, can be inherited to add
            // custom control.
            // """
            // self.ensure_one()
            // # skip operation line if archived
            // if not self.active:
            //     return True
            // if not product or product._name == 'product.template':
            //     return False
            // 
            // never_attribute_values = self.env.context.get('never_attribute_ids')
            // return self.env['mrp.bom']._skip_for_no_variant(product, self.bom_product_template_attribute_value_ids, never_attribute_values)
            */
            return default;
        }

        protected async Task<MrpRoutingWorkcenter> TotalCostPerHourInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_account, FILE: mrp_routing.py) ---
            // def _total_cost_per_hour(self):
            // self.ensure_one()
            // return self.workcenter_id.costs_hour
            */
            return default;
        }

        public async Task<MrpRoutingWorkcenter> UnarchiveAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_routing.py) ---
            // def action_unarchive(self):
            // res = super().action_unarchive()
            // self.bom_id._set_outdated_bom_in_productions()
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}