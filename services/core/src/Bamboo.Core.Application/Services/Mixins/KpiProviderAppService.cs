using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Interfaces;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("base_setup", Category = "Base", Depends = new[] { "base", "web" })]
    public partial class KpiProviderAppService : ApplicationService, IKpiProviderAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public KpiProviderAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> GetAccountKpiSummaryAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IKpiProviderable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: kpi_provider.py) ---
            // def get_account_kpi_summary(self):
            // grouped_moves_to_report = self.env['account.move']._read_group(
            //     fields.Domain.OR([
            //         [('state', '=', 'draft')],
            //         [('state', '=', 'posted'), ('checked', '=', False)],
            //         [('state', '=', 'posted'), ('journal_id.type', '=', 'bank'), ('statement_line_id.is_reconciled', '=', False)],
            //     ]),
            //     ['journal_id'],
            //     ['journal_id:count'],
            // )
            // 
            // FieldsSelection = self.env['ir.model.fields.selection'].with_context(lang=self.env.user.lang)
            // journal_type_names = {x.value: x.name for x in FieldsSelection.search([
            //     ('field_id.model', '=', 'account.journal'),
            //     ('field_id.name', '=', 'type'),
            // ])}
            // 
            // count_by_type = {}
            // for journal_id, count in grouped_moves_to_report:
            //     journal_type = journal_id.type
            //     count_by_type[journal_type] = count_by_type.get(journal_type, 0) + count
            // 
            // return [{
            //     'id': f'account_journal_type.{journal_type}',
            //     'name': journal_type_names[journal_type],
            //     'type': 'integer',
            //     'value': count,
            // } for journal_type, count in count_by_type.items()]
            */
            return default;
        }

        public async Task<TEntity> GetKpiSummaryAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IKpiProviderable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: kpi_provider.py) ---
            // def get_kpi_summary(self):
            // result = super().get_kpi_summary()
            // result.extend(self.get_account_kpi_summary())
            // return result
            --- ODOO METHOD SOURCE (MODULE: base_setup, FILE: kpi_provider.py) ---
            // def get_kpi_summary(self):
            // """
            // Other modules can override this method to add their own KPIs to the list.
            // This method will be called by the databases module to retrieve the data displayed on the databases list.
            // The return value shall be a list of dictionaries with the following keys:
            // 
            // - id: a unique identifier for the KPI
            // - type: the type of data (`integer` or `return_status`)
            // - name: the translated name of the KPI, as displayable to the current user
            // - value: either the numeric value (for `type=integer`) or one of the statuses (for `type=return_status`):
            //   - late       one return of this type should have been done already
            //   - longterm   the deadline of the closest uncompleted return is in more than 3 months
            //   - to_do      the deadline of the closest uncompleted return is in less than 3 months
            //   - to_submit  the closest uncompleted return is ready, but still needs an action
            //   - done       all of the forseeable returns are completed
            // """
            // return []
            */
            return default;
        }
    }
}