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
    [Module("Account", Category = "Accounting", Depends = new[] { "base_setup", "onboarding", "product", "analytic", "portal", "digest" })]
    public class AccountReconcileModelAppService : GenericApplicationService<AccountReconcileModel>, IAccountReconcileModelAppService
    {
        private readonly IMailThreadAppService _mailThreadAppService;
        public AccountReconcileModelAppService(IRepository<AccountReconcileModel, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IMailThreadAppService mailThreadAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _mailThreadAppService = mailThreadAppService;
        }

        protected async Task<AccountReconcileModel> CheckPaymentToleranceParamInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_reconcile_model.py) ---
            // def _check_payment_tolerance_param(self):
            // for record in self:
            //     if record.allow_payment_tolerance:
            //         if record.payment_tolerance_type == 'percentage' and not 0 <= record.payment_tolerance_param <= 100:
            //             raise ValidationError(_("A payment tolerance defined as a percentage should always be between 0 and 100"))
            //         elif record.payment_tolerance_type == 'fixed_amount' and record.payment_tolerance_param < 0:
            //             raise ValidationError(_("A payment tolerance defined as an amount should always be higher than 0"))
            */
            return default;
        }

        protected async Task<AccountReconcileModel> ComputeNumberEntriesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_reconcile_model.py) ---
            // def _compute_number_entries(self):
            // data = self.env['account.move.line']._read_group([('reconcile_model_id', 'in', self.ids)], ['reconcile_model_id'], ['__count'])
            // mapped_data = {reconcile_model.id: count for reconcile_model, count in data}
            // for model in self:
            //     model.number_entries = mapped_data.get(model.id, 0)
            */
            return default;
        }

        protected async Task<AccountReconcileModel> ComputePaymentToleranceParamInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_reconcile_model.py) ---
            // def _compute_payment_tolerance_param(self):
            // for record in self:
            //     if record.payment_tolerance_type == 'percentage':
            //         record.payment_tolerance_param = min(100.0, max(0.0, record.payment_tolerance_param))
            //     else:
            //         record.payment_tolerance_param = max(0.0, record.payment_tolerance_param)
            */
            return default;
        }

        protected async Task<AccountReconcileModel> ComputeShowDecimalSeparatorInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_reconcile_model.py) ---
            // def _compute_show_decimal_separator(self):
            // for record in self:
            //     record.show_decimal_separator = any(l.amount_type == 'regex' for l in record.line_ids)
            */
            return default;
        }

        public async Task<AccountReconcileModel> CopyDataAsync(Guid id, AccountReconcileModelCopyDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_reconcile_model.py) ---
            // def copy_data(self, default=None):
            // default = dict(default or {})
            // vals_list = super().copy_data(default)
            // if default.get('name'):
            //     return vals_list
            // for model, vals in zip(self, vals_list):
            //     name = _("%s (copy)", model.name)
            //     while self.env['account.reconcile.model'].search_count([('name', '=', name)], limit=1):
            //         name = _("%s (copy)", name)
            //     vals['name'] = name
            // return vals_list
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountReconcileModel> ReconcileStatAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_reconcile_model.py) ---
            // def action_reconcile_stat(self):
            // self.ensure_one()
            // action = self.env["ir.actions.actions"]._for_xml_id("account.action_move_journal_line")
            // self._cr.execute('''
            //     SELECT ARRAY_AGG(DISTINCT move_id)
            //     FROM account_move_line
            //     WHERE reconcile_model_id = %s
            // ''', [self.id])
            // action.update({
            //     'context': {},
            //     'domain': [('id', 'in', self._cr.fetchone()[0])],
            //     'help': """<p class="o_view_nocontent_empty_folder">{}</p>""".format(_('This reconciliation model has created no entry so far')),
            // })
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}