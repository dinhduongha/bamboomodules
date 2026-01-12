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
    [Module("Onboarding", Category = "Base", Depends = new[] { "web" })]
    public class OnboardingOnboardingAppService : GenericApplicationService<OnboardingOnboarding>, IOnboardingOnboardingAppService
    {

        public OnboardingOnboardingAppService(IRepository<OnboardingOnboarding, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        public async Task<OnboardingOnboarding> CloseAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: onboarding, FILE: onboarding_onboarding.py) ---
            // def action_close(self):
            // """Close the onboarding panel."""
            // self.current_progress_id.action_close()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<OnboardingOnboarding> ClosePanelAccountDashboardAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: onboarding_onboarding.py) ---
            // def action_close_panel_account_dashboard(self):
            // self.action_close_panel('account.onboarding_onboarding_account_dashboard')
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<OnboardingOnboarding> ClosePanelAccountInvoiceAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: onboarding_onboarding.py) ---
            // def action_close_panel_account_invoice(self):
            // self.action_close_panel('account.onboarding_onboarding_account_invoice')
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<OnboardingOnboarding> ClosePanelAsync(Guid id, OnboardingOnboardingClosePanelRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: onboarding, FILE: onboarding_onboarding.py) ---
            // def action_close_panel(self, xmlid):
            // """Close the onboarding panel identified by its `xmlid`.
            // 
            // If not found, quietly do nothing.
            // """
            // if onboarding := self.env.ref(xmlid, raise_if_not_found=False):
            //     onboarding.action_close()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<OnboardingOnboarding> ComputeCurrentProgressInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: onboarding, FILE: onboarding_onboarding.py) ---
            // def _compute_current_progress(self):
            // for onboarding in self:
            //     current_progress_id = onboarding.progress_ids.filtered(
            //         lambda progress: progress.company_id.id in {False, self.env.company.id})
            //     if current_progress_id:
            //         onboarding.current_onboarding_state = current_progress_id.onboarding_state
            //         onboarding.current_progress_id = current_progress_id
            //         onboarding.is_onboarding_closed = current_progress_id.is_onboarding_closed
            //     else:
            //         onboarding.current_onboarding_state = 'not_done'
            //         onboarding.current_progress_id = False
            //         onboarding.is_onboarding_closed = False
            */
            return default;
        }

        protected async Task<OnboardingOnboarding> ComputeIsPerCompanyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: onboarding, FILE: onboarding_onboarding.py) ---
            // def _compute_is_per_company(self):
            // # Once an onboarding is made "per-company", there is no drawback to simply still consider
            // # it per-company even when if its last per-company step is unlinked. This allows to avoid
            // # handling the merging of existing progress (step) records.
            // 
            // onboardings_with_per_company_steps_or_progress = self.filtered(
            //     lambda o: o.progress_ids.company_id or (True in o.step_ids.mapped('is_per_company')))
            // onboardings_with_per_company_steps_or_progress.is_per_company = True
            // (self - onboardings_with_per_company_steps_or_progress).is_per_company = False
            */
            return default;
        }

        protected async Task<OnboardingOnboarding> CreateProgressInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: onboarding, FILE: onboarding_onboarding.py) ---
            // def _create_progress(self):
            // return self.env['onboarding.progress'].create([
            //     {
            //         'company_id': self.env.company.id if onboarding.is_per_company else False,
            //         'onboarding_id': onboarding.id,
            //         'progress_step_ids': onboarding.step_ids.progress_ids.filtered(
            //             lambda p: p.company_id.id in [False, self.env.company.id]
            //         ),
            //     }
            //     for onboarding in self
            // ])
            */
            return default;
        }

        protected async Task<OnboardingOnboarding> PrepareRenderingValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: onboarding_onboarding.py) ---
            // def _prepare_rendering_values(self):
            // """Compute existence of invoices for company."""
            // self.ensure_one()
            // if self == self.env.ref('account.onboarding_onboarding_account_invoice', raise_if_not_found=False):
            //     step = self.env.ref('account.onboarding_onboarding_step_create_invoice', raise_if_not_found=False)
            //     if step and step.current_step_state == 'not_done':
            //         if self.env['account.move'].search_count(
            //             [('company_id', '=', self.env.company.id), ('move_type', '=', 'out_invoice')], limit=1
            //         ):
            //             step.action_set_just_done()
            // return super()._prepare_rendering_values()
            --- ODOO METHOD SOURCE (MODULE: onboarding, FILE: onboarding_onboarding.py) ---
            // def _prepare_rendering_values(self):
            // self.ensure_one()
            // values = {
            //     'close_method': self.panel_close_action_name,
            //     'close_model': 'onboarding.onboarding',
            //     'steps': self.step_ids,
            //     'state': self.current_progress_id._get_and_update_onboarding_state(),
            //     'text_completed': self.text_completed,
            // }
            // 
            // return values
            */
            return default;
        }

        public async Task<OnboardingOnboarding> RefreshProgressIdsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: onboarding, FILE: onboarding_onboarding.py) ---
            // def action_refresh_progress_ids(self):
            // """Re-initialize onboarding progress records (after step is_per_company change).
            // 
            // Meant to be called when `is_per_company` of linked steps is modified (or per-company
            // steps are added to an onboarding).
            // """
            // onboardings_to_refresh_progress = self.filtered(
            //     lambda o: o.is_per_company and o.progress_ids and not o.progress_ids.company_id
            // )
            // onboardings_to_refresh_progress.progress_ids.unlink()
            // onboardings_to_refresh_progress._create_progress()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<OnboardingOnboarding> SearchOrCreateProgressInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: onboarding, FILE: onboarding_onboarding.py) ---
            // def _search_or_create_progress(self):
            // """Create Progress record(s) as necessary for the context."""
            // onboardings_without_progress = self.filtered(lambda onboarding: not onboarding.current_progress_id)
            // onboardings_without_progress._create_progress()
            // return self.current_progress_id
            */
            return default;
        }

        public async Task<OnboardingOnboarding> ToggleVisibilityAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: onboarding, FILE: onboarding_onboarding.py) ---
            // def action_toggle_visibility(self):
            // self.current_progress_id.action_toggle_visibility()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}