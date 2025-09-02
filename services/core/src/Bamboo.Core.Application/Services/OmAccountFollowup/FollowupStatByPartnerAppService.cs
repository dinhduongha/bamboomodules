using Bamboo.Core.Application.Contracts.DTOs;
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
    [Module("OmAccountFollowup", Depends = new[] { "account", "mail" })]
    public class FollowupStatByPartnerAppService : GenericApplicationService<FollowupStatByPartner>, IFollowupStatByPartnerAppService
    {

        public FollowupStatByPartnerAppService(IRepository<FollowupStatByPartner, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<FollowupStatByPartner> GetInvoicePartnerIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_followup, FILE: followup_partner.py) ---
            // def _get_invoice_partner_id(self):
            // for rec in self:
            //     rec.invoice_partner_id = rec.partner_id.address_get(
            //         adr_pref=['invoice']).get('invoice', rec.partner_id.id)
            */
            return default;
        }

        public async Task<FollowupStatByPartner> InitAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_followup, FILE: followup_partner.py) ---
            // def init(self):
            // tools.drop_view_if_exists(self._cr, 'followup_stat_by_partner')
            // self._cr.execute("""
            //     create view followup_stat_by_partner as (
            //         SELECT
            //             l.partner_id * 10000::bigint + l.company_id as id,
            //             l.partner_id AS partner_id,
            //             min(l.date) AS date_move,
            //             max(l.date) AS date_move_last,
            //             max(l.followup_date) AS date_followup,
            //             max(l.followup_line_id) AS max_followup_id,
            //             sum(l.debit - l.credit) AS balance,
            //             l.company_id as company_id
            //         FROM
            //             account_move_line l
            //             LEFT JOIN account_account a ON (l.account_id = a.id)
            //         WHERE
            //             a.account_type = 'asset_receivable' AND
            //             l.full_reconcile_id is NULL AND
            //             l.partner_id IS NOT NULL
            //             GROUP BY
            //             l.partner_id, l.company_id
            //     )""")
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}