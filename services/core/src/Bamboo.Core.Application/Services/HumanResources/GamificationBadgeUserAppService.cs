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
    public class GamificationBadgeUserAppService : GenericApplicationService<GamificationBadgeUser>, IGamificationBadgeUserAppService
    {

        public GamificationBadgeUserAppService(IRepository<GamificationBadgeUser, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<GamificationBadgeUser> CheckEmployeeRelatedUserInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_gamification, FILE: gamification.py) ---
            // def _check_employee_related_user(self):
            // for badge_user in self:
            //     if badge_user.employee_id and badge_user.employee_id not in badge_user.user_id.\
            //         with_context(allowed_company_ids=self.env.user.company_ids.ids).employee_ids:
            //         raise ValidationError(_('The selected employee does not correspond to the selected user.'))
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
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'gamification.badge',
            //     'view_mode': 'form',
            //     'res_id': self.badge_id.id,
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
            // template = self.env.ref(
            //     'gamification.email_template_badge_received',
            //     raise_if_not_found=False
            // )
            // if not template:
            //     return
            // 
            // for badge_user in self:
            //     template.send_mail(
            //         badge_user.id,
            //     )
            // 
            // return True
            */
            return default;
        }
    }
}