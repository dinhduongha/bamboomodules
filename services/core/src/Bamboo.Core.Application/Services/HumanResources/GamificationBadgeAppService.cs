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
    public class GamificationBadgeAppService : GenericApplicationService<GamificationBadge>, IGamificationBadgeAppService
    {
        private readonly IImageMixinAppService _imageMixinAppService;
        private readonly IMailThreadAppService _mailThreadAppService;
        private readonly IWebsitePublishedMixinAppService _websitePublishedMixinAppService;
        public GamificationBadgeAppService(IRepository<GamificationBadge, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IImageMixinAppService imageMixinAppService, IMailThreadAppService mailThreadAppService, IWebsitePublishedMixinAppService websitePublishedMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _imageMixinAppService = imageMixinAppService;
            _mailThreadAppService = mailThreadAppService;
            _websitePublishedMixinAppService = websitePublishedMixinAppService;
        }

        protected async Task<GamificationBadge> CanGrantBadgeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: gamification_badge.py) ---
            // def _can_grant_badge(self):
            // """Check if a user can grant a badge to another user
            // 
            // :param uid: the id of the res.users trying to send the badge
            // :param badge_id: the granted badge id
            // :return: integer representing the permission.
            // """
            // if self.env.is_admin():
            //     return self.CAN_GRANT
            // 
            // if self.rule_auth == 'nobody':
            //     return self.NOBODY_CAN_GRANT
            // elif self.rule_auth == 'users' and self.env.user not in self.rule_auth_user_ids:
            //     return self.USER_NOT_VIP
            // elif self.rule_auth == 'having':
            //     all_user_badges = self.env['gamification.badge.user'].search([('user_id', '=', self.env.uid)]).mapped('badge_id')
            //     if self.rule_auth_badge_ids - all_user_badges:
            //         return self.BADGE_REQUIRED
            // 
            // if self.rule_max and self.stat_my_monthly_sending >= self.rule_max_number:
            //     return self.TOO_MANY
            // 
            // # badge.rule_auth == 'everyone' -> no check
            // return self.CAN_GRANT
            */
            return default;
        }

        public async Task<GamificationBadge> CheckGrantingAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: gamification_badge.py) ---
            // def check_granting(self):
            // """Check the user 'uid' can grant the badge 'badge_id' and raise the appropriate exception
            // if not
            // 
            // Do not check for SUPERUSER_ID
            // """
            // status_code = self._can_grant_badge()
            // if status_code == self.CAN_GRANT:
            //     return True
            // elif status_code == self.NOBODY_CAN_GRANT:
            //     raise exceptions.UserError(_('This badge can not be sent by users.'))
            // elif status_code == self.USER_NOT_VIP:
            //     raise exceptions.UserError(_('You are not in the user allowed list.'))
            // elif status_code == self.BADGE_REQUIRED:
            //     raise exceptions.UserError(_('You do not have the required badges.'))
            // elif status_code == self.TOO_MANY:
            //     raise exceptions.UserError(_('You have already sent this badge too many time this month.'))
            // else:
            //     _logger.error("Unknown badge status code: %s" % status_code)
            // return False
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<GamificationBadge> ComputeGrantedEmployeesCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_gamification, FILE: gamification.py) ---
            // def _compute_granted_employees_count(self):
            // for badge in self:
            //     badge.granted_employees_count = self.env['gamification.badge.user'].search_count([
            //         ('badge_id', '=', badge.id),
            //         ('employee_id', '!=', False)
            //     ])
            */
            return default;
        }

        protected async Task<GamificationBadge> ComputeSurveyIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: survey, FILE: badge.py) ---
            // def _compute_survey_id(self):
            // for badge in self:
            //     badge.survey_id = badge.survey_ids[0] if badge.survey_ids else None
            */
            return default;
        }

        protected async Task<GamificationBadge> GetBadgeUserStatsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: gamification_badge.py) ---
            // def _get_badge_user_stats(self):
            // """Return stats related to badge users"""
            // first_month_day = date.today().replace(day=1)
            // 
            // for badge in self:
            //     owners = badge.owner_ids
            //     badge.stat_my = sum(o.user_id == self.env.user for o in owners)
            //     badge.stat_this_month = sum(o.create_date.date() >= first_month_day for o in owners)
            //     badge.stat_my_this_month = sum(
            //         o.user_id == self.env.user and o.create_date.date() >= first_month_day
            //         for o in owners
            //     )
            //     badge.stat_my_monthly_sending = sum(
            //         o.create_uid == self.env.user and o.create_date.date() >= first_month_day
            //         for o in owners
            //     )
            */
            return default;
        }

        public async Task<GamificationBadge> GetGrantedEmployeesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_gamification, FILE: gamification.py) ---
            // def get_granted_employees(self):
            // employee_ids = self.mapped('owner_ids.employee_id').ids
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': 'Granted Employees',
            //     'view_mode': 'kanban,list,form',
            //     'res_model': 'hr.employee.public',
            //     'domain': [('id', 'in', employee_ids)]
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<GamificationBadge> GetOwnersInfoInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: gamification_badge.py) ---
            // def _get_owners_info(self):
            // """Return:
            //     the list of unique res.users ids having received this badge
            //     the total number of time this badge was granted
            //     the total number of users this badge was granted to
            // """
            // defaults = {
            //     'granted_count': 0,
            //     'granted_users_count': 0,
            //     'unique_owner_ids': [],
            // }
            // if not self.ids:
            //     self.update(defaults)
            //     return
            // 
            // Users = self.env["res.users"]
            // query = Users._where_calc([])
            // Users._apply_ir_rules(query)
            // badge_alias = query.join("res_users", "id", "gamification_badge_user", "user_id", "badges")
            // 
            // rows = self.env.execute_query(SQL(
            //     """
            //       SELECT %(badge_alias)s.badge_id, count(res_users.id) as stat_count,
            //              count(distinct(res_users.id)) as stat_count_distinct,
            //              array_agg(distinct(res_users.id)) as unique_owner_ids
            //         FROM %(from_clause)s
            //        WHERE %(where_clause)s
            //          AND %(badge_alias)s.badge_id IN %(ids)s
            //     GROUP BY %(badge_alias)s.badge_id
            //     """,
            //     from_clause=query.from_clause,
            //     where_clause=query.where_clause or SQL("TRUE"),
            //     badge_alias=SQL.identifier(badge_alias),
            //     ids=tuple(self.ids),
            // ))
            // 
            // mapping = {
            //     badge_id: {
            //         'granted_count': count,
            //         'granted_users_count': distinct_count,
            //         'unique_owner_ids': owner_ids,
            //     }
            //     for (badge_id, count, distinct_count, owner_ids) in rows
            // }
            // for badge in self:
            //     badge.update(mapping.get(badge.id, defaults))
            */
            return default;
        }

        protected async Task<GamificationBadge> RemainingSendingCalcInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: gamification_badge.py) ---
            // def _remaining_sending_calc(self):
            // """Computes the number of badges remaining the user can send
            // 
            // 0 if not allowed or no remaining
            // integer if limited sending
            // -1 if infinite (should not be displayed)
            // """
            // for badge in self:
            //     if badge._can_grant_badge() != self.CAN_GRANT:
            //         # if the user cannot grant this badge at all, result is 0
            //         badge.remaining_sending = 0
            //     elif not badge.rule_max:
            //         # if there is no limitation, -1 is returned which means 'infinite'
            //         badge.remaining_sending = -1
            //     else:
            //         badge.remaining_sending = badge.rule_max_number - badge.stat_my_monthly_sending
            */
            return default;
        }
    }
}