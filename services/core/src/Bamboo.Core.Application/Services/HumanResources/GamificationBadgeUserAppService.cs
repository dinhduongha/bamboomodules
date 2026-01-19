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
    [Module("Gamification", Category = "HumanResources", Depends = new[] { "mail" })]
    public partial class GamificationBadgeUserAppService : GenericApplicationService<GamificationBadgeUser>, IGamificationBadgeUserAppService
    {
        private readonly IMailThreadAppService _mailThreadAppService;
        public GamificationBadgeUserAppService(IRepository<GamificationBadgeUser, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IMailThreadAppService mailThreadAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _mailThreadAppService = mailThreadAppService;
        }

        protected async Task<GamificationBadgeUser> CheckEmployeeRelatedUserInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_gamification, FILE: gamification.py) ---
            // def _check_employee_related_user(self):
            // for badge_user in self:
            //     if badge_user.employee_id and badge_user.employee_id not in badge_user.user_id.\
            //         with_context(allowed_company_ids=badge_user.user_id.company_ids.ids).employee_ids:
            //         raise ValidationError(_('The selected employee does not correspond to the selected user.'))
            */
            return default;
        }

        protected async Task<GamificationBadgeUser> ComputeHasEditDeleteAccessInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_gamification, FILE: gamification.py) ---
            // def _compute_has_edit_delete_access(self):
            // is_hr_user = self.env.user.has_group('hr.group_hr_user')
            // for badge_user in self:
            //     badge_user.has_edit_delete_access = is_hr_user or self.env.uid == self.create_uid.id
            */
            return default;
        }

        protected async Task<GamificationBadgeUser> MailGetPartnerFieldsInternalAsync(object introspect_fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: gamification_badge_user.py) ---
            // def _mail_get_partner_fields(self, introspect_fields=False):
            // return ['user_partner_id']
            */
            return default;
        }

        protected async Task<GamificationBadgeUser> NotifyGetRecipientsGroupsInternalAsync(object message, object model_description, object msg_vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: gamification_badge_user.py) ---
            // def _notify_get_recipients_groups(self, message, model_description, msg_vals=False):
            // groups = super()._notify_get_recipients_groups(message, model_description, msg_vals)
            // self.ensure_one()
            // for group in groups:
            //     if group[0] == 'user':
            //         group[2]['has_button_access'] = False
            // return groups
            --- ODOO METHOD SOURCE (MODULE: hr_gamification, FILE: gamification.py) ---
            // def _notify_get_recipients_groups(self, message, model_description, msg_vals=False):
            // groups = super()._notify_get_recipients_groups(message, model_description, msg_vals)
            // self.ensure_one()
            // base_url = self.get_base_url()
            // for group in groups:
            //     if group[0] == 'user':
            //         if self.employee_id:
            //             employee_form_url = f"{base_url}/web#action=hr.hr_employee_public_action&id={self.employee_id.id}&open_badges_tab=true&user_badge_id={self.id}"
            // 
            //             group[2]['button_access'] = {
            //                 'url': employee_form_url,
            //                 'title': _('View Your Badge'),
            //             }
            //             group[2]['has_button_access'] = True
            //         else:
            //             group[2]['has_button_access'] = False
            // return groups
            */
            return default;
        }

        public async Task<GamificationBadgeUser> OpenBadgeAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_gamification, FILE: gamification.py) ---
            // def action_open_badge(self):
            // self.ensure_one()
            // return {
            //     'name': _('Received Badge'),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'gamification.badge.user',
            //     'res_id': self.id,
            //     'target': 'new',
            //     'view_mode': 'form',
            //     'view_id': self.env.ref("hr_gamification.view_current_badge_form").id,
            //     'context': {"dialog_size": "medium"},
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<GamificationBadgeUser> SendBadgeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: gamification_badge_user.py) ---
            // def _send_badge(self):
            // """Send a notification to a user for receiving a badge
            // 
            // Does not verify constrains on badge granting.
            // The users are added to the owner_ids (create badge_user if needed)
            // The stats counters are incremented
            // :param ids: list(int) of badge users that will receive the badge
            // """
            // body_html = self.env.ref('gamification.email_template_badge_received')._render_field('body_html', self.ids)[self.id]
            // for badge_user in self:
            //     badge_user.message_notify(
            //         model=badge_user._name,
            //         res_id=badge_user.id,
            //         body=body_html,
            //         partner_ids=[badge_user.user_partner_id.id],
            //         subject=_("🎉 You've earned the %(badge)s badge!", badge=badge_user.badge_name),
            //         subtype_xmlid='mail.mt_comment',
            //         email_layout_xmlid='mail.mail_notification_layout',
            //     )
            // 
            // return True
            */
            return default;
        }
    }
}