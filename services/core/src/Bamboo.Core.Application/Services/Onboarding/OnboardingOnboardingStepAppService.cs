using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
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
    [Module("Onboarding", Depends = new[] { "web" })]
    public class OnboardingOnboardingStepAppService : GenericApplicationService<OnboardingOnboardingStep>, IOnboardingOnboardingStepAppService
    {

        public OnboardingOnboardingStepAppService(IRepository<OnboardingOnboardingStep, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        public async Task<OnboardingOnboardingStep> CheckStepOnOnboardingHasActionAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: onboarding, FILE: onboarding_onboarding_step.py) ---
            // def check_step_on_onboarding_has_action(self):
            // if steps_without_action := self.filtered(lambda step: step.onboarding_ids and not step.panel_step_open_action_name):
            //     raise ValidationError(_(
            //         'An "Opening Action" is required for the following steps to be '
            //         'linked to an onboarding panel: %(step_titles)s',
            //         step_titles=steps_without_action.mapped('title'),
            //     ))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<OnboardingOnboardingStep> ComputeCurrentProgressInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: onboarding, FILE: onboarding_onboarding_step.py) ---
            // def _compute_current_progress(self):
            // # When `is_per_company` is changed, `progress_ids` is updated (see `write`) which triggers this `_compute`.
            // existing_progress_steps = self.progress_ids.filtered_domain([
            //     ('step_id', 'in', self.ids),
            //     ('company_id', 'in', [False, self.env.company.id]),
            // ])
            // for step in self:
            //     if step in existing_progress_steps.step_id:
            //         current_progress_step_id = existing_progress_steps.filtered(
            //             lambda progress_step: progress_step.step_id == step)
            //         step.current_progress_step_id = current_progress_step_id
            //         step.current_step_state = current_progress_step_id.step_state
            //     else:
            //         step.current_progress_step_id = False
            //         step.current_step_state = 'not_done'
            */
            return default;
        }

        protected async Task<OnboardingOnboardingStep> CreateProgressStepsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: onboarding, FILE: onboarding_onboarding_step.py) ---
            // def _create_progress_steps(self):
            // """Create progress step records as necessary to validate steps.
            // 
            // Only considers existing `onboarding.progress` records for the current
            // company or without company (depending on `is_per_company`).
            // """
            // onboarding_progress_records = self.env['onboarding.progress'].search([
            //     ('onboarding_id', 'in', self.onboarding_ids.ids),
            //     ('company_id', 'in', [False, self.env.company.id])
            // ])
            // progress_step_values = [
            //     {
            //         'step_id': step_id.id,
            //         'progress_ids': [
            //             Command.link(onboarding_progress_record.id)
            //             for onboarding_progress_record
            //             in onboarding_progress_records.filtered(lambda p: step_id in p.onboarding_id.step_ids)],
            //         'company_id': self.env.company.id if step_id.is_per_company else False,
            //     } for step_id in self
            // ]
            // return self.env['onboarding.progress.step'].create(progress_step_values)
            */
            return default;
        }

        protected async Task<OnboardingOnboardingStep> GetPlaceholderFilenameInternalAsync(object field)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: onboarding, FILE: onboarding_onboarding_step.py) ---
            // def _get_placeholder_filename(self, field):
            // if field == "step_image":
            //     return 'base/static/img/onboarding_default.png'
            // return super()._get_placeholder_filename(field)
            */
            return default;
        }

        public async Task<OnboardingOnboardingStep> OpenStepBankAccountAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: onboarding_onboarding_step.py) ---
            // def action_open_step_bank_account(self):
            // return self.env.company.setting_init_bank_account_action()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<OnboardingOnboardingStep> OpenStepBaseDocumentLayoutAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: onboarding_onboarding_step.py) ---
            // def action_open_step_base_document_layout(self):
            // view_id = self.env.ref('web.view_base_document_layout').id
            // return {
            //     'name': _('Configure your document layout'),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'base.document.layout',
            //     'target': 'new',
            //     'views': [(view_id, 'form')],
            //     'context': {"dialog_size": "extra-large"},
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<OnboardingOnboardingStep> OpenStepChartOfAccountsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: onboarding_onboarding_step.py) ---
            // def action_open_step_chart_of_accounts(self):
            // """ Called by the 'Chart of Accounts' button of the dashboard onboarding panel."""
            // company = self.env['account.journal'].browse(self._context.get('journal_id', None)).company_id or self.env.company
            // self.sudo().with_company(company).action_validate_step('account.onboarding_onboarding_step_chart_of_accounts')
            // 
            // # If an opening move has already been posted, we open the list view showing all the accounts
            // if company.opening_move_posted():
            //     return 'account.action_account_form'
            // 
            // # Then, we open will open a custom list view allowing to edit opening balances of the account
            // view_id = self.env.ref('account.init_accounts_tree').id
            // # Hide the current year earnings account as it is automatically computed
            // domain = [
            //     *self.env['account.account']._check_company_domain(company),
            //     ('account_type', '!=', 'equity_unaffected'),
            // ]
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': _('Chart of Accounts'),
            //     'res_model': 'account.account',
            //     'view_mode': 'list',
            //     'limit': 99999999,
            //     'search_view_id': [self.env.ref('account.view_account_search').id],
            //     'views': [[view_id, 'list'], [False, 'form']],
            //     'domain': domain,
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<OnboardingOnboardingStep> OpenStepCompanyDataAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: onboarding_onboarding_step.py) ---
            // def action_open_step_company_data(self):
            // """Set company's basic information."""
            // company = self.env['account.journal'].browse(self._context.get('journal_id', None)).company_id or self.env.company
            // action = {
            //     'type': 'ir.actions.act_window',
            //     'name': _('Set your company data'),
            //     'res_model': 'res.company',
            //     'res_id': company.id,
            //     'views': [(self.env.ref('account.res_company_form_view_onboarding').id, "form")],
            //     'target': 'new',
            // }
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<OnboardingOnboardingStep> OpenStepCreateInvoiceAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: onboarding_onboarding_step.py) ---
            // def action_open_step_create_invoice(self):
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': _('Create first invoice'),
            //     'views': [(self.env.ref("account.view_move_form").id, 'form')],
            //     'res_model': 'account.move',
            //     'context': {'default_move_type': 'out_invoice'},
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<OnboardingOnboardingStep> OpenStepFiscalYearAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: onboarding_onboarding_step.py) ---
            // def action_open_step_fiscal_year(self):
            // company = self.env['account.journal'].browse(self._context.get('journal_id', None)).company_id or self.env.company
            // new_wizard = self.env['account.financial.year.op'].create({'company_id': company.id})
            // view_id = self.env.ref('account.setup_financial_year_opening_form').id
            // 
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': _('Accounting Periods'),
            //     'view_mode': 'form',
            //     'res_model': 'account.financial.year.op',
            //     'target': 'new',
            //     'res_id': new_wizard.id,
            //     'views': [[view_id, 'form']],
            //     'context': {
            //         'dialog_size': 'medium',
            //     }
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<OnboardingOnboardingStep> OpenStepPaymentProviderAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_payment, FILE: onboarding_onboarding_step.py) ---
            // def action_open_step_payment_provider(self):
            // self.env.company.payment_onboarding_payment_method = 'stripe'
            // menu = self.env.ref('account_payment.payment_provider_menu', raise_if_not_found=False)
            // menu_id = menu.id if menu else None
            // return self.env.company._run_payment_onboarding_step(menu_id)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<OnboardingOnboardingStep> OpenStepSalesTaxAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: onboarding_onboarding_step.py) ---
            // def action_open_step_sales_tax(self):
            // view_id = self.env.ref('account.res_company_form_view_onboarding_sale_tax').id
            // 
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': _('Sales tax'),
            //     'res_id': self.env.company.id,
            //     'res_model': 'res.company',
            //     'target': 'new',
            //     'view_mode': 'form',
            //     'views': [[view_id, 'form']],
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<OnboardingOnboardingStep> SetJustDoneAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: onboarding, FILE: onboarding_onboarding_step.py) ---
            // def action_set_just_done(self):
            // # Make sure progress records exist for the current context (company)
            // steps_without_progress = self.filtered(lambda step: not step.current_progress_step_id)
            // steps_without_progress._create_progress_steps()
            // return self.current_progress_step_id.action_set_just_done().step_id
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<OnboardingOnboardingStep> ValidateStepAsync(Guid id, OnboardingOnboardingStepValidateStepRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: onboarding, FILE: onboarding_onboarding_step.py) ---
            // def action_validate_step(self, xml_id):
            // step = self.env.ref(xml_id, raise_if_not_found=False)
            // if not step:
            //     return "NOT_FOUND"
            // return "JUST_DONE" if step.action_set_just_done() else "WAS_DONE"
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<OnboardingOnboardingStep> ValidateStepBaseDocumentLayoutAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: onboarding_onboarding_step.py) ---
            // def action_validate_step_base_document_layout(self):
            // """Set the onboarding(s) step as done only if layout is set."""
            // step = self.env.ref('account.onboarding_onboarding_step_base_document_layout', raise_if_not_found=False)
            // if not step or not self.env.company.external_report_layout_id:
            //     return False
            // return self.action_validate_step('account.onboarding_onboarding_step_base_document_layout')
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<OnboardingOnboardingStep> ValidateStepPaymentProviderAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_payment, FILE: onboarding_onboarding_step.py) ---
            // def action_validate_step_payment_provider(self):
            // validation_response = super().action_validate_step_payment_provider()
            // self.action_validate_step("account_payment.onboarding_onboarding_step_payment_provider")
            // return validation_response
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: onboarding_step.py) ---
            // def action_validate_step_payment_provider(self):
            // """ Override of `onboarding` to validate other steps as well. """
            // return self.action_validate_step('payment.onboarding_onboarding_step_payment_provider')
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}