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
    [Module("Mail", Category = "Productivity", Depends = new[] { "base", "base_setup", "bus", "web_tour", "html_editor" })]
    public partial class MailActivityTypeAppService : GenericApplicationService<MailActivityType>, IMailActivityTypeAppService
    {

        public MailActivityTypeAppService(IRepository<MailActivityType, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        public async Task<MailActivityType> ArchiveAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_activity_type.py) ---
            // def action_archive(self):
            // if self.env.ref('mail.mail_activity_data_todo') in self:
            //     raise UserError(_("The 'To-Do' activity type is used to create reminders from the top bar menu and the command palette. Consequently, it cannot be archived or deleted."))
            // return super().action_archive()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<MailActivityType> CheckActivityTypeResModelInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_activity_type.py) ---
            // def _check_activity_type_res_model(self):
            // self.env['mail.activity.plan.template'].search(
            //     [('activity_type_id', 'in', self.ids)])._check_activity_type_res_model()
            */
            return default;
        }

        protected async Task<MailActivityType> ComputeDelayLabelInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_activity_type.py) ---
            // def _compute_delay_label(self):
            // selection_description_values = {
            //     e[0]: e[1] for e in self._fields['delay_unit']._description_selection(self.env)}
            // for activity_type in self:
            //     unit = selection_description_values[activity_type.delay_unit]
            //     activity_type.delay_label = '%s %s' % (activity_type.delay_count, unit)
            */
            return default;
        }

        protected async Task<MailActivityType> ComputeInitialResModelInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_activity_type.py) ---
            // def _compute_initial_res_model(self):
            // for activity_type in self:
            //     activity_type.initial_res_model = activity_type.res_model
            */
            return default;
        }

        protected async Task<MailActivityType> ComputeSuggestedNextTypeIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_activity_type.py) ---
            // def _compute_suggested_next_type_ids(self):
            // """suggested_next_type_ids and triggered_next_type_id should be mutually exclusive"""
            // for activity_type in self:
            //     if activity_type.chaining_type == 'trigger':
            //         activity_type.suggested_next_type_ids = False
            */
            return default;
        }

        protected async Task<MailActivityType> ComputeTriggeredNextTypeIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_activity_type.py) ---
            // def _compute_triggered_next_type_id(self):
            // """suggested_next_type_ids and triggered_next_type_id should be mutually exclusive"""
            // for activity_type in self:
            //     if activity_type.chaining_type == 'suggest':
            //         activity_type.triggered_next_type_id = False
            */
            return default;
        }

        protected async Task<MailActivityType> GetDateDeadlineInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_activity_type.py) ---
            // def _get_date_deadline(self):
            // """ Return the activity deadline computed from today or from activity_previous_deadline context variable. """
            // self.ensure_one()
            // if self.delay_from == 'previous_activity' and self.env.context.get('activity_previous_deadline'):
            //     base = fields.Date.from_string(self.env.context.get('activity_previous_deadline'))
            // else:
            //     base = fields.Date.context_today(self)
            // return base + relativedelta(**{self.delay_unit: self.delay_count})
            */
            return default;
        }

        protected async Task<MailActivityType> GetModelInfoByXmlidInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: mail_activity_type.py) ---
            // def _get_model_info_by_xmlid(self):
            // info = super()._get_model_info_by_xmlid()
            // # used notably to generate activities only one time using a cron
            // info['fleet.mail_act_fleet_contract_to_renew'] = {
            //     'res_model': 'fleet.vehicle.log.contract',
            //     'unlink': False,
            // }
            // return info
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: mail_activity_type.py) ---
            // def _get_model_info_by_xmlid(self):
            // info = super()._get_model_info_by_xmlid()
            // info['hr_holidays.mail_act_leave_approval'] = {'res_model': 'hr.leave', 'unlink': False}
            // info['hr_holidays.mail_act_leave_second_approval'] = {'res_model': 'hr.leave', 'unlink': False}
            // info['hr_holidays.mail_act_leave_allocation_approval'] = {'res_model': 'hr.leave.allocation', 'unlink': False}
            // info['hr_holidays.mail_act_leave_allocation_second_approval'] = {'res_model': 'hr.leave.allocation', 'unlink': False}
            // return info
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_activity_type.py) ---
            // def _get_model_info_by_xmlid(self):
            // """ Get model info based on xml ids. """
            // return {
            //     # generic call, used notably in VOIP, ... no unlink, necessary for VOIP
            //     'mail.mail_activity_data_call': {'res_model': False, 'unlink': False},
            //     # generic meeting, used in calendar, hr, ... no unlink, necessary for appointment, appraisals
            //     'mail.mail_activity_data_meeting': {'res_model': False, 'unlink': False},
            //     # generic todo, used in plans, ... no unlink, basic generic fallback data
            //     'mail.mail_activity_data_todo': {'res_model': False, 'unlink': False},
            //     # generic upload, used in documents, accounting, ...
            //     'mail.mail_activity_data_upload_document': {'res_model': False, 'unlink': True},
            //     # generic warning, used in plans, business flows, ...
            //     'mail.mail_activity_data_warning': {'res_model': False, 'unlink': True},
            // }
            */
            return default;
        }

        protected async Task<MailActivityType> GetModelSelectionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_activity_type.py) ---
            // def _get_model_selection(self):
            // return [
            //     (model.model, model.name)
            //     for model in self.env['ir.model'].sudo().search(
            //         ['&', ('is_mail_thread', '=', True), ('transient', '=', False)])
            // ]
            */
            return default;
        }

        protected async Task<MailActivityType> InverseSuggestedNextTypeIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_activity_type.py) ---
            // def _inverse_suggested_next_type_ids(self):
            // for activity_type in self:
            //     if activity_type.suggested_next_type_ids:
            //         activity_type.chaining_type = 'suggest'
            */
            return default;
        }

        protected async Task<MailActivityType> InverseTriggeredNextTypeIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_activity_type.py) ---
            // def _inverse_triggered_next_type_id(self):
            // for activity_type in self:
            //     if activity_type.triggered_next_type_id:
            //         activity_type.chaining_type = 'trigger'
            //     else:
            //         activity_type.chaining_type = 'suggest'
            */
            return default;
        }

        protected async Task<MailActivityType> OnchangeResModelInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_activity_type.py) ---
            // def _onchange_res_model(self):
            // self.mail_template_ids = self.sudo().mail_template_ids.filtered(lambda template: template.model_id.model == self.res_model)
            // self.res_model_change = self.initial_res_model and self.initial_res_model != self.res_model
            */
            return default;
        }

        protected async Task<MailActivityType> UnlinkExceptTodoInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_activity_type.py) ---
            // def _unlink_except_todo(self):
            // master_data = self.browse()
            // for xml_id in [xmlid for xmlid, info in self._get_model_info_by_xmlid().items() if info['unlink'] is False]:
            //     activity_type = self.env.ref(xml_id, raise_if_not_found=False)
            //     if activity_type and activity_type in self:
            //         master_data += activity_type
            // if master_data:
            //     raise exceptions.UserError(
            //         _('You cannot delete %(activity_names)s as it is required in various apps.',
            //           activity_names=', '.join(act.name for act in master_data),
            //     ))
            */
            return default;
        }
    }
}