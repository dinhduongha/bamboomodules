using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Models;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace Bamboo.Core.Application.Services
{
    [Module("Maintenance", Depends = new[] { "mail" })]
    public class MaintenanceEquipmentAppService : GenericApplicationService<MaintenanceEquipment>, IMaintenanceEquipmentAppService
    {
        private readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        private readonly IMailThreadAppService _mailThreadAppService;
        private readonly IMaintenanceMixinAppService _maintenanceMixinAppService;
        public MaintenanceEquipmentAppService(IRepository<MaintenanceEquipment, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService, IMaintenanceMixinAppService maintenanceMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
            _maintenanceMixinAppService = maintenanceMixinAppService;
        }

        protected async Task<MaintenanceEquipment> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py) ---
            // def _compute_display_name(self):
            // for record in self:
            //     if record.serial_no:
            //         record.display_name = (record.name or '') + '/' + record.serial_no
            //     else:
            //         record.display_name = record.name
            */
            return default;
        }

        protected async Task<MaintenanceEquipment> ComputeEquipmentAssignInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_maintenance, FILE: equipment.py) ---
            // def _compute_equipment_assign(self):
            // for equipment in self:
            //     if equipment.equipment_assign_to == 'employee':
            //         equipment.department_id = False
            //         equipment.employee_id = equipment.employee_id
            //     elif equipment.equipment_assign_to == 'department':
            //         equipment.employee_id = False
            //         equipment.department_id = equipment.department_id
            //     else:
            //         equipment.department_id = equipment.department_id
            //         equipment.employee_id = equipment.employee_id
            //     equipment.assign_date = fields.Date.context_today(self)
            */
            return default;
        }

        protected async Task<MaintenanceEquipment> ComputeMatchSerialInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py) ---
            // def _compute_match_serial(self):
            // if 'stock.lot' not in self.env or not self.env['stock.lot'].has_access('read'):
            //     self.match_serial = False
            //     return
            // matched_serial_data = self.env['stock.lot']._read_group(
            //     [('name', 'in', self.mapped('serial_no'))],
            //     ['name'],
            //     ['__count'],
            // )
            // matched_serial_count = dict(matched_serial_data)
            // for equipment in self:
            //     equipment.match_serial = matched_serial_count.get(equipment.serial_no, 0)
            */
            return default;
        }

        protected async Task<MaintenanceEquipment> ComputeOwnerInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_maintenance, FILE: equipment.py) ---
            // def _compute_owner(self):
            // for equipment in self:
            //     equipment.owner_user_id = self.env.user.id
            //     if equipment.equipment_assign_to == 'employee':
            //         equipment.owner_user_id = equipment.employee_id.user_id.id
            //     elif equipment.equipment_assign_to == 'department':
            //         equipment.owner_user_id = equipment.department_id.manager_id.user_id.id
            */
            return default;
        }

        public override async Task<MaintenanceEquipment> CreateAsync(MaintenanceEquipment entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_maintenance, FILE: equipment.py) ---
            // def create(self, vals_list):
            // equipments = super().create(vals_list)
            // for equipment in equipments:
            //     # subscribe employee or department manager when equipment assign to him.
            //     partner_ids = []
            //     if equipment.employee_id and equipment.employee_id.user_id:
            //         partner_ids.append(equipment.employee_id.user_id.partner_id.id)
            //     if equipment.department_id and equipment.department_id.manager_id and equipment.department_id.manager_id.user_id:
            //         partner_ids.append(equipment.department_id.manager_id.user_id.partner_id.id)
            //     if partner_ids:
            //         equipment.message_subscribe(partner_ids=partner_ids)
            // return equipments
            --- ODOO METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py) ---
            // def create(self, vals_list):
            // equipments = super().create(vals_list)
            // for equipment in equipments:
            //     if equipment.owner_user_id:
            //         equipment.message_subscribe(partner_ids=[equipment.owner_user_id.partner_id.id])
            // return equipments
            */
            return await base.CreateAsync(entity, fields);
        }

        protected async Task<MaintenanceEquipment> OnchangeCategoryIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py) ---
            // def _onchange_category_id(self):
            // self.technician_user_id = self.category_id.technician_user_id
            */
            return default;
        }

        public async Task<MaintenanceEquipment> OpenMatchedSerialAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py) ---
            // def action_open_matched_serial(self):
            // self.ensure_one()
            // action = self.env.ref('stock.action_production_lot_form', raise_if_not_found=False)
            // if not action:
            //     return True
            // action_dict = action._get_action_dict()
            // action_dict['context'] = {'search_default_name': self.serial_no}
            // return action_dict
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<MaintenanceEquipment> ReadGroupCategoryIdsInternalAsync(object categories, object domain)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py) ---
            // def _read_group_category_ids(self, categories, domain):
            // """ Read group customization in order to display all the categories in
            //     the kanban view, even if they are empty.
            // """
            // # bypass ir.model.access checks, but search with ir.rules
            // search_domain = self.env['ir.rule']._compute_domain(categories._name)
            // category_ids = categories.sudo()._search(search_domain, order=categories._order)
            // return categories.browse(category_ids)
            */
            return default;
        }

        protected async Task<MaintenanceEquipment> TrackSubtypeInternalAsync(object init_values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_maintenance, FILE: equipment.py) ---
            // def _track_subtype(self, init_values):
            // self.ensure_one()
            // if ('employee_id' in init_values and self.employee_id) or ('department_id' in init_values and self.department_id):
            //     return self.env.ref('maintenance.mt_mat_assign')
            // return super(MaintenanceEquipment, self)._track_subtype(init_values)
            --- ODOO METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py) ---
            // def _track_subtype(self, init_values):
            // self.ensure_one()
            // if 'owner_user_id' in init_values and self.owner_user_id:
            //     return self.env.ref('maintenance.mt_mat_assign')
            // return super(MaintenanceEquipment, self)._track_subtype(init_values)
            */
            return default;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, MaintenanceEquipment entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_maintenance, FILE: equipment.py) ---
            // def write(self, vals):
            // partner_ids = []
            // # subscribe employee or department manager when equipment assign to employee or department.
            // if vals.get('employee_id'):
            //     user_id = self.env['hr.employee'].browse(vals['employee_id'])['user_id']
            //     if user_id:
            //         partner_ids.append(user_id.partner_id.id)
            // if vals.get('department_id'):
            //     department = self.env['hr.department'].browse(vals['department_id'])
            //     if department and department.manager_id and department.manager_id.user_id:
            //         partner_ids.append(department.manager_id.user_id.partner_id.id)
            // if partner_ids:
            //     self.message_subscribe(partner_ids=partner_ids)
            // return super(MaintenanceEquipment, self).write(vals)
            --- ODOO METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py) ---
            // def write(self, vals):
            // if vals.get('owner_user_id'):
            //     self.message_subscribe(partner_ids=self.env['res.users'].browse(vals['owner_user_id']).partner_id.ids)
            // return super(MaintenanceEquipment, self).write(vals)
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}