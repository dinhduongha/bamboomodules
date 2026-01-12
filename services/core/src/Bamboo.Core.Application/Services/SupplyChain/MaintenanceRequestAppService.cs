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
    [Module("Maintenance", Category = "SupplyChain", Depends = new[] { "mail" })]
    public class MaintenanceRequestAppService : GenericApplicationService<MaintenanceRequest>, IMaintenanceRequestAppService
    {
        private readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        private readonly IMailThreadCcAppService _mailThreadCcAppService;
        public MaintenanceRequestAppService(IRepository<MaintenanceRequest, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadCcAppService mailThreadCcAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadCcAppService = mailThreadCcAppService;
        }

        public async Task<MaintenanceRequest> ActivityUpdateAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py) ---
            // def activity_update(self):
            // """ Update maintenance activities based on current record set state.
            // It reschedule, unlink or create maintenance request activities. """
            // self.filtered(lambda request: not request.schedule_date).activity_unlink(['maintenance.mail_act_maintenance_request'])
            // for request in self.filtered(lambda request: request.schedule_date):
            //     date_dl = fields.Datetime.from_string(request.schedule_date).date()
            //     updated = request.activity_reschedule(
            //         ['maintenance.mail_act_maintenance_request'],
            //         date_deadline=date_dl,
            //         new_user_id=request.user_id.id or request.owner_user_id.id or self.env.uid)
            //     if not updated:
            //         note = request._get_activity_note()
            //         request.activity_schedule(
            //             'maintenance.mail_act_maintenance_request',
            //             fields.Datetime.from_string(request.schedule_date).date(),
            //             note=note, user_id=request.user_id.id or request.owner_user_id.id or self.env.uid)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<MaintenanceRequest> AddFollowersInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py) ---
            // def _add_followers(self):
            // for request in self:
            //     partner_ids = (request.owner_user_id.partner_id + request.user_id.partner_id).ids
            //     request.message_subscribe(partner_ids=partner_ids)
            */
            return default;
        }

        public async Task<MaintenanceRequest> ArchiveEquipmentRequestAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py) ---
            // def archive_equipment_request(self):
            // self.write({'archive': True, 'recurring_maintenance': False})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<MaintenanceRequest> CheckRepeatIntervalInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py) ---
            // def _check_repeat_interval(self):
            // for record in self:
            //     if record.repeat_interval < 1:
            //         raise ValidationError(self.env._("The repeat interval cannot be less than 1."))
            */
            return default;
        }

        protected async Task<MaintenanceRequest> CheckScheduleEndInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py) ---
            // def _check_schedule_end(self):
            // for request in self:
            //     if request.schedule_date and request.schedule_end and request.schedule_date > request.schedule_end:
            //         raise ValidationError(self.env._("End date cannot be earlier than start date."))
            */
            return default;
        }

        protected async Task<MaintenanceRequest> ComputeDurationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py) ---
            // def _compute_duration(self):
            // for request in self:
            //     if request.schedule_date and request.schedule_end:
            //         duration = (request.schedule_end - request.schedule_date).total_seconds() / 3600
            //         request.duration = round(duration, 2)
            //     else:
            //         request.duration = 0
            */
            return default;
        }

        protected async Task<MaintenanceRequest> ComputeMaintenanceTeamIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py) ---
            // def _compute_maintenance_team_id(self):
            // for request in self:
            //     if request.equipment_id and request.equipment_id.maintenance_team_id:
            //         request.maintenance_team_id = request.equipment_id.maintenance_team_id.id
            //     if request.maintenance_team_id.company_id and request.maintenance_team_id.company_id.id != request.company_id.id:
            //         request.maintenance_team_id = False
            */
            return default;
        }

        protected async Task<MaintenanceRequest> ComputeOwnerInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_maintenance, FILE: equipment.py) ---
            // def _compute_owner(self):
            // for r in self:
            //     if r.equipment_id.equipment_assign_to == 'employee':
            //         r.owner_user_id = r.employee_id.user_id.id
            //     else:
            //         r.owner_user_id = False
            */
            return default;
        }

        protected async Task<MaintenanceRequest> ComputeRecurringMaintenanceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py) ---
            // def _compute_recurring_maintenance(self):
            // for request in self:
            //     if request.maintenance_type != 'preventive':
            //         request.recurring_maintenance = False
            */
            return default;
        }

        protected async Task<MaintenanceRequest> ComputeScheduleEndInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py) ---
            // def _compute_schedule_end(self):
            // for request in self:
            //     request.schedule_end = request.schedule_date and request.schedule_date + relativedelta(hours=1)
            */
            return default;
        }

        protected async Task<MaintenanceRequest> ComputeUserIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py) ---
            // def _compute_user_id(self):
            // for request in self:
            //     if request.equipment_id:
            //         request.user_id = request.equipment_id.technician_user_id or request.equipment_id.category_id.technician_user_id
            //     if request.user_id and request.company_id.id not in request.user_id.company_ids.ids:
            //         request.user_id = False
            */
            return default;
        }

        public override async Task<MaintenanceRequest> CreateAsync(MaintenanceRequest entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_maintenance, FILE: equipment.py) ---
            // def create(self, vals_list):
            // requests = super().create(vals_list)
            // for request in requests:
            //     # TDE FIXME: check default recipients (master)
            //     if request.employee_id.user_id:
            //         request.message_subscribe(partner_ids=[request.employee_id.user_id.partner_id.id])
            // return requests
            --- ODOO METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py) ---
            // def create(self, vals_list):
            // # context: no_log, because subtype already handle this
            // maintenance_requests = super().create(vals_list)
            // for request in maintenance_requests:
            //     if request.owner_user_id or request.user_id:
            //         request._add_followers()
            //     if request.equipment_id and not request.maintenance_team_id:
            //         request.maintenance_team_id = request.maintenance_team_id
            //     if request.close_date and not request.stage_id.done:
            //         request.close_date = False
            //     if not request.close_date and request.stage_id.done:
            //         request.close_date = fields.Date.today()
            // maintenance_requests.activity_update()
            // return maintenance_requests
            */
            return await base.CreateAsync(entity, fields);
        }

        protected async Task<MaintenanceRequest> CreationSubtypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py) ---
            // def _creation_subtype(self):
            // return self.env.ref('maintenance.mt_req_created')
            */
            return default;
        }

        protected async Task<MaintenanceRequest> DefaultEmployeeGetInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_maintenance, FILE: equipment.py) ---
            // def _default_employee_get(self):
            // return self.env.user.employee_id
            */
            return default;
        }

        protected async Task<MaintenanceRequest> DefaultStageInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py) ---
            // def _default_stage(self):
            // return self.env['maintenance.stage'].search([], limit=1)
            */
            return default;
        }

        protected async Task<MaintenanceRequest> GetActivityNoteInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py) ---
            // def _get_activity_note(self):
            // self.ensure_one()
            // if self.equipment_id:
            //     return _('Request planned for %s', self.equipment_id._get_html_link())
            // return False
            */
            return default;
        }

        protected async Task<MaintenanceRequest> GetDefaultTeamIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py) ---
            // def _get_default_team_id(self):
            // MT = self.env['maintenance.team']
            // team = MT.search([('company_id', '=', self.env.company.id)], limit=1)
            // if not team:
            //     team = MT.search([], limit=1)
            // return team.id
            */
            return default;
        }

        public async Task<MaintenanceRequest> MessageNewAsync(Guid id, MaintenanceRequestMessageNewRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_maintenance, FILE: equipment.py) ---
            // def message_new(self, msg_dict, custom_values=None):
            // if custom_values is None:
            //     custom_values = {}
            // # TDE FIXME: check author_id, should be set (master-)
            // email = tools.email_normalize(msg_dict.get('from'), strict=False)
            // user = self.env['res.users'].search([('login', '=', email)], limit=1) if email else self.env['res.users']
            // if user:
            //     employee = self.env.user.employee_id
            //     if employee:
            //         custom_values['employee_id'] = employee and employee[0].id
            // return super().message_new(msg_dict, custom_values=custom_values)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<MaintenanceRequest> NeedNewActivityInternalAsync(object vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py) ---
            // def _need_new_activity(self, vals):
            // return vals.get('equipment_id')
            */
            return default;
        }

        protected async Task<MaintenanceRequest> ReadGroupStageIdsInternalAsync(object stages, object domain)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py) ---
            // def _read_group_stage_ids(self, stages, domain):
            // """ Read group customization in order to display all the stages in the
            //     kanban view, even if they are empty
            // """
            // stage_ids = stages.sudo()._search([], order=stages._order)
            // return stages.browse(stage_ids)
            */
            return default;
        }

        public async Task<MaintenanceRequest> ResetEquipmentRequestAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py) ---
            // def reset_equipment_request(self):
            // """ Reinsert the maintenance request into the maintenance pipe in the first stage"""
            // first_stage_obj = self.env['maintenance.stage'].search([], order="sequence asc", limit=1)
            // # self.write({'active': True, 'stage_id': first_stage_obj.id})
            // self.write({'archive': False, 'stage_id': first_stage_obj.id})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<MaintenanceRequest> TrackSubtypeInternalAsync(object init_values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py) ---
            // def _track_subtype(self, init_values):
            // self.ensure_one()
            // if 'stage_id' in init_values:
            //     return self.env.ref('maintenance.mt_req_status')
            // return super(MaintenanceRequest, self)._track_subtype(init_values)
            */
            return default;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, MaintenanceRequest entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_maintenance, FILE: equipment.py) ---
            // def write(self, vals):
            // if vals.get('employee_id'):
            //     employee = self.env['hr.employee'].browse(vals['employee_id'])
            //     if employee and employee.user_id:
            //         self.message_subscribe(partner_ids=[employee.user_id.partner_id.id])
            // return super(MaintenanceRequest, self).write(vals)
            --- ODOO METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py) ---
            // def write(self, vals):
            // # Overridden to reset the kanban_state to normal whenever
            // # the stage (stage_id) of the Maintenance Request changes.
            // if vals and 'kanban_state' not in vals and 'stage_id' in vals:
            //     vals['kanban_state'] = 'normal'
            // now = fields.Datetime.now()
            // if 'stage_id' in vals and self.env['maintenance.stage'].browse(vals['stage_id']).done:
            //     for request in self:
            //         if request.maintenance_type != 'preventive' or not request.recurring_maintenance:
            //             continue
            //         schedule_date = request.schedule_date or now
            //         schedule_date += relativedelta(**{f"{request.repeat_unit}s": request.repeat_interval})
            //         schedule_end = schedule_date + relativedelta(hours=request.duration or 1)
            //         if request.repeat_type == 'forever' or schedule_date.date() <= request.repeat_until:
            //             request.copy({
            //                 'schedule_date': schedule_date,
            //                 'schedule_end': schedule_end,
            //                 'stage_id': request._default_stage().id,
            //             })
            // res = super(MaintenanceRequest, self).write(vals)
            // if vals.get('owner_user_id') or vals.get('user_id'):
            //     self._add_followers()
            // if 'stage_id' in vals:
            //     self.filtered(lambda m: m.stage_id.done).write({'close_date': fields.Date.today()})
            //     self.filtered(lambda m: not m.stage_id.done).write({'close_date': False})
            //     self.activity_feedback(['maintenance.mail_act_maintenance_request'])
            //     self.activity_update()
            // if vals.get('user_id') or vals.get('schedule_date'):
            //     self.activity_update()
            // if self._need_new_activity(vals):
            //     # need to change description of activity also so unlink old and create new activity
            //     self.activity_unlink(['maintenance.mail_act_maintenance_request'])
            //     self.activity_update()
            // return res
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}