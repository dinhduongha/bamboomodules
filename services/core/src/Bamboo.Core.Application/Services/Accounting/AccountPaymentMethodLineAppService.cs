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
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("Account", Category = "Accounting", Depends = new[] { "base_setup", "onboarding", "product", "analytic", "portal", "digest" })]
    public partial class AccountPaymentMethodLineAppService : GenericAppService<AccountPaymentMethodLine>, IAccountPaymentMethodLineAppService
    {

        public AccountPaymentMethodLineAppService(IRepository<AccountPaymentMethodLine, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {

        }

        [ApiModel]
        protected async Task<AccountPaymentMethodLine> AutoToggleAccountToReconcileInternalAsync(Guid account_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment_method.py) ---
            // def _auto_toggle_account_to_reconcile(self, account_id):
            // """ Automatically toggle the account to reconcile if allowed.
            // 
            // :param account_id: The id of an account.account.
            // """
            // account = self.env['account.account'].browse(account_id)
            // if not account.reconcile and account.account_type not in ('asset_cash', 'liability_credit_card', 'off_balance'):
            //     account.reconcile = True
            */
            return default;
        }

        protected async Task<AccountPaymentMethodLine> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment_method.py) ---
            // def _compute_display_name(self):
            // for method in self:
            //     if self.env.context.get('hide_payment_journal_id'):
            //         return super()._compute_display_name()
            //     method.display_name = f"{method.name} ({method.journal_id.name})"
            */
            return default;
        }

        protected async Task<AccountPaymentMethodLine> ComputeNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment_method.py) ---
            // def _compute_name(self):
            // for method in self:
            //     if not method.name:
            //         method.name = method.payment_method_id.name
            --- ODOO METHOD SOURCE (MODULE: account_payment, FILE: account_payment_method_line.py) ---
            // def _compute_name(self):
            // super()._compute_name()
            // for line in self:
            //     if line.payment_provider_id and not line.name:
            //         line.name = line.payment_provider_id.name
            */
            return default;
        }

        protected async Task<AccountPaymentMethodLine> ComputePaymentProviderIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_payment, FILE: account_payment_method_line.py) ---
            // def _compute_payment_provider_id(self):
            // results = self.journal_id._get_journals_payment_method_information()
            // manage_providers = results['manage_providers']
            // method_information_mapping = results['method_information_mapping']
            // providers_per_code = results['providers_per_code']
            // 
            // for line in self:
            //     journal = line.journal_id
            //     company = journal.company_id
            //     if (
            //         company
            //         and line.payment_method_id
            //         and not line.payment_provider_id
            //         and manage_providers
            //         and method_information_mapping.get(line.payment_method_id.id, {}).get('mode') == 'electronic'
            //     ):
            //         provider_ids = providers_per_code.get(company.id, {}).get(line.code, set())
            // 
            //         # Exclude the 'unique' / 'electronic' values that are already set on the journal.
            //         protected_provider_ids = set()
            //         for payment_type in ('inbound', 'outbound'):
            //             lines = journal[f'{payment_type}_payment_method_line_ids']
            //             for journal_line in lines:
            //                 if journal_line.payment_method_id:
            //                     if (
            //                         manage_providers
            //                         and method_information_mapping.get(journal_line.payment_method_id.id, {}).get('mode') == 'electronic'
            //                     ):
            //                         protected_provider_ids.add(journal_line.payment_provider_id.id)
            // 
            //         candidates_provider_ids = provider_ids - protected_provider_ids
            //         if candidates_provider_ids:
            //             line.payment_provider_id = next(iter(candidates_provider_ids))
            */
            return default;
        }

        protected async Task<AccountPaymentMethodLine> EnsureUniqueNameForJournalInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment_method.py) ---
            // def _ensure_unique_name_for_journal(self):
            // self.journal_id._check_payment_method_line_ids_multiplicity()
            */
            return default;
        }

        public async Task<AccountPaymentMethodLine> OpenProviderFormAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_payment, FILE: account_payment_method_line.py) ---
            // def action_open_provider_form(self):
            // self.ensure_one()
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': _('Provider'),
            //     'view_mode': 'form',
            //     'res_model': 'payment.provider',
            //     'target': 'current',
            //     'res_id': self.payment_provider_id.id
            // }
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<AccountPaymentMethodLine> UnlinkExceptActiveProviderInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_payment, FILE: account_payment_method_line.py) ---
            // def _unlink_except_active_provider(self):
            // """ Ensure we don't remove an account.payment.method.line that is linked to a provider
            // in the test or enabled state.
            // """
            // active_provider = self.payment_provider_id.filtered(lambda provider: provider.state in ['enabled', 'test'])
            // if active_provider:
            //     raise UserError(_(
            //         "You can't delete a payment method that is linked to a provider in the enabled "
            //         "or test state.\n""Linked providers(s): %s",
            //         ', '.join(a.display_name for a in active_provider),
            //     ))
            */
            return default;
        }
    }
}