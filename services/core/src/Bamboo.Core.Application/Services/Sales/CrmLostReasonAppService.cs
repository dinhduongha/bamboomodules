using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Application.Services;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
using Microsoft.Extensions.Caching.Memory;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Models;

namespace Bamboo.Core.Application.Services
{
    [Module("Crm", Depends = new[] { "base_setup", "sales_team", "mail", "calendar", "resource", "utm", "web_tour", "contacts", "digest", "phone_validation" })]
    public class CrmLostReasonAppService : GenericApplicationService<CrmLostReason>, ICrmLostReasonAppService
    {

        public CrmLostReasonAppService(IRepository<CrmLostReason, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<CrmLostReason> ComputeLeadsCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lost_reason.py) ---
            // def _compute_leads_count(self):
            // lead_data = self.env['crm.lead'].with_context(active_test=False)._read_group(
            //     [('lost_reason_id', 'in', self.ids)],
            //     ['lost_reason_id'],
            //     ['__count'],
            // )
            // mapped_data = {lost_reason.id: count for lost_reason, count in lead_data}
            // for reason in self:
            //     reason.leads_count = mapped_data.get(reason.id, 0)
            */
            return default;
        }

        public async Task<CrmLostReason> LostLeadsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lost_reason.py) ---
            // def action_lost_leads(self):
            // return {
            //     'name': _('Leads'),
            //     'view_mode': 'list,form',
            //     'domain': [('lost_reason_id', 'in', self.ids)],
            //     'res_model': 'crm.lead',
            //     'type': 'ir.actions.act_window',
            //     'context': {'create': False, 'active_test': False},
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}