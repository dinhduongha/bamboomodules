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
using Microsoft.Extensions.Caching.Distributed;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("OmAccountFollowup", Category = "Accounting", Depends = new[] { "account", "mail" })]
    public partial class FollowupStatByPartnerAppService : GenericAppService<FollowupStatByPartner>, IFollowupStatByPartnerAppService
    {

        public FollowupStatByPartnerAppService(IRepository<FollowupStatByPartner, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
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

        [ApiModel]
        public async Task<FollowupStatByPartner> InitAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_followup, FILE: followup_partner.py) ---
            // def init(self):
            // tools.drop_view_if_exists(self.env.cr, 'followup_stat_by_partner')
            // self.env.cr.execute("""
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
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}