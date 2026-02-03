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
    [Module("Account", Category = "Accounting", Depends = new[] { "base_setup", "onboarding", "product", "analytic", "portal", "digest" })]
    public partial class AccountReportAppService : GenericAppService<AccountReport>, IAccountReportAppService
    {

        public AccountReportAppService(IRepository<AccountReport, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {

        }

        protected async Task<AccountReport> ComputeDefaultAvailabilityConditionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_report.py) ---
            // def _compute_default_availability_condition(self):
            // for report in self:
            //     if report.root_report_id and report.country_id:
            //         report.availability_condition = 'country'
            //     elif not report.availability_condition:
            //         report.availability_condition = 'always'
            */
            return default;
        }

        protected async Task<AccountReport> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_report.py) ---
            // def _compute_display_name(self):
            // for report in self:
            //     if report.name:
            //         report.display_name = report.name + (f' ({report.country_id.code})' if report.country_id else '')
            //     else:
            //         report.display_name = False
            */
            return default;
        }

        protected async Task<AccountReport> ComputeReportOptionFilterInternalAsync(object field_name, object default_value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_report.py) ---
            // def _compute_report_option_filter(self, field_name, default_value=False):
            // # We don't depend on the different filter fields on the root report, as we don't want a manual change on it to be reflected on all the reports
            // # using it as their root (would create confusion). The root report filters are only used as some kind of default values.
            // # When a report is a section, it can also get its default filter values from its parent composite report. This only happens when we're sure
            // # the report is not used as a section of multiple reports, nor as a standalone report.
            // for report in self.sorted(lambda x: not x.section_report_ids):
            //     # Reports are sorted in order to first treat the composite reports, in case they need to compute their filters a the same time
            //     # as their sections
            //     is_accessible = self.env['ir.actions.client'].search_count([('context', 'ilike', f"'report_id': {report.id}"), ('tag', '=', 'account_report')])
            //     is_variant = bool(report.root_report_id)
            //     if (is_accessible or is_variant) and report.section_main_report_ids:
            //         continue  # prevent updating the filters of a report when being added as a section of a report
            //     if report.root_report_id:
            //         report[field_name] = report.root_report_id[field_name]
            //     elif len(report.section_main_report_ids) == 1 and not is_accessible:
            //         report[field_name] = report.section_main_report_ids[field_name]
            //     else:
            //         report[field_name] = default_value
            */
            return default;
        }

        protected async Task<AccountReport> ComputeUseSectionsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_report.py) ---
            // def _compute_use_sections(self):
            // for report in self:
            //     report.use_sections = bool(report.section_report_ids)
            */
            return default;
        }

        public async Task<AccountReport> CopyDataAsync(AccountReportCopyDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_report.py) ---
            // def copy_data(self, default=None):
            // vals_list = super().copy_data(default=default)
            // return [dict(vals, name=report._get_copied_name()) for report, vals in zip(self, vals_list)]
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<AccountReport> GetCopiedNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_report.py) ---
            // def _get_copied_name(self):
            // '''Return a copied name of the account.report record by adding the suffix (copy) at the end
            // until the name is unique.
            // 
            // :return: an unique name for the copied account.report
            // '''
            // self.ensure_one()
            // name = self.name + ' ' + _('(copy)')
            // while self.search_count([('name', '=', name)]) > 0:
            //     name += ' ' + _('(copy)')
            // return name
            */
            return default;
        }

        protected async Task<AccountReport> OnchangeAvailabilityConditionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_report.py) ---
            // def _onchange_availability_condition(self):
            // if self.availability_condition != 'country':
            //     self.country_id = None
            */
            return default;
        }

        protected async Task<AccountReport> UnlinkIfNoVariantInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_report.py) ---
            // def _unlink_if_no_variant(self):
            // if self.variant_report_ids:
            //     raise UserError(_("You can't delete a report that has variants."))
            */
            return default;
        }

        protected async Task<AccountReport> ValidateAvailabilityConditionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_report.py) ---
            // def _validate_availability_condition(self):
            // for record in self:
            //     if record.availability_condition == 'country' and not record.country_id:
            //         raise ValidationError(_("The Availability is set to 'Country Matches' but the field Country is not set."))
            */
            return default;
        }

        protected async Task<AccountReport> ValidateParentSequenceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_report.py) ---
            // def _validate_parent_sequence(self):
            // previous_lines = self.env['account.report.line']
            // for line in self.line_ids.sorted('sequence'):
            //     if line.parent_id and line.parent_id not in previous_lines:
            //         raise ValidationError(
            //             _('Line "%(line)s" defines line "%(parent_line)s" as its parent, but appears before it in the report. '
            //               'The parent must always come first.', line=line.name, parent_line=line.parent_id.name))
            //     previous_lines |= line
            */
            return default;
        }

        protected async Task<AccountReport> ValidateRootReportIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_report.py) ---
            // def _validate_root_report_id(self):
            // for report in self:
            //     if report.root_report_id.root_report_id:
            //         raise ValidationError(_("Only a report without a root report of its own can be selected as root report."))
            */
            return default;
        }

        protected async Task<AccountReport> ValidateSectionReportIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_report.py) ---
            // def _validate_section_report_ids(self):
            // for record in self:
            //     if any(section.section_report_ids for section in record.section_report_ids):
            //         raise ValidationError(_("The sections defined on a report cannot have sections themselves."))
            */
            return default;
        }
    }
}