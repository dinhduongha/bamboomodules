using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Volo.Abp.ObjectMapping;
using Volo.Abp.MultiTenancy;
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
    public partial class AccountReportAppService
    {

        protected async Task<AccountReport> ComputeDefaultAvailabilityConditionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_report.py, METHOD: _compute_default_availability_condition) ---
            */
            return default;
        }

        protected async Task<AccountReport> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_report.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<AccountReport> ComputeReportOptionFilterInternalAsync(object field_name, object default_value)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_report.py, METHOD: _compute_report_option_filter) ---
            */
            return default;
        }

        protected async Task<AccountReport> ComputeUseSectionsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_report.py, METHOD: _compute_use_sections) ---
            */
            return default;
        }

        protected async Task<AccountReport> GetCopiedNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_report.py, METHOD: _get_copied_name) ---
            */
            return default;
        }

        protected async Task<AccountReport> OnchangeAvailabilityConditionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_report.py, METHOD: _onchange_availability_condition) ---
            */
            return default;
        }

        protected async Task<AccountReport> UnlinkIfNoVariantInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_report.py, METHOD: _unlink_if_no_variant) ---
            */
            return default;
        }

        protected async Task<AccountReport> ValidateAvailabilityConditionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_report.py, METHOD: _validate_availability_condition) ---
            */
            return default;
        }

        protected async Task<AccountReport> ValidateParentSequenceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_report.py, METHOD: _validate_parent_sequence) ---
            */
            return default;
        }

        protected async Task<AccountReport> ValidateRootReportIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_report.py, METHOD: _validate_root_report_id) ---
            */
            return default;
        }

        protected async Task<AccountReport> ValidateSectionReportIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_report.py, METHOD: _validate_section_report_ids) ---
            */
            return default;
        }
    }
}