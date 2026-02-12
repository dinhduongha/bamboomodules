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
    public partial class SnailmailLetterAppService
    {

        protected async Task<SnailmailLetter> AppendCoverPageInternalAsync(object invoice_bin)
        {
            /*
            --- METHOD SOURCE (MODULE: snailmail, FILE: snailmail_letter.py, METHOD: _append_cover_page) ---
            */
            return default;
        }

        protected async Task<SnailmailLetter> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: snailmail, FILE: snailmail_letter.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<SnailmailLetter> ComputeReferenceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: snailmail, FILE: snailmail_letter.py, METHOD: _compute_reference) ---
            */
            return default;
        }

        protected async Task<SnailmailLetter> CountPagesPdfInternalAsync(object bin_pdf)
        {
            /*
            --- METHOD SOURCE (MODULE: snailmail, FILE: snailmail_letter.py, METHOD: _count_pages_pdf) ---
            */
            return default;
        }

        protected async Task<SnailmailLetter> FetchAttachmentInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: snailmail, FILE: snailmail_letter.py, METHOD: _fetch_attachment) ---
            */
            return default;
        }

        protected async Task<SnailmailLetter> GenerateReportPdfInternalAsync(object report)
        {
            /*
            --- METHOD SOURCE (MODULE: snailmail, FILE: snailmail_letter.py, METHOD: _generate_report_pdf) ---
            */
            return default;
        }

        protected async Task<SnailmailLetter> GetCoverAddressSplitInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: snailmail, FILE: snailmail_letter.py, METHOD: _get_cover_address_split) ---
            */
            return default;
        }

        protected async Task<SnailmailLetter> GetErrorMessageInternalAsync(object error)
        {
            /*
            --- METHOD SOURCE (MODULE: snailmail, FILE: snailmail_letter.py, METHOD: _get_error_message) ---
            */
            return default;
        }

        protected async Task<SnailmailLetter> GetFailureTypeInternalAsync(object error)
        {
            /*
            --- METHOD SOURCE (MODULE: snailmail, FILE: snailmail_letter.py, METHOD: _get_failure_type) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<SnailmailLetter> IsValidAddressInternalAsync(object record)
        {
            /*
            --- METHOD SOURCE (MODULE: snailmail, FILE: snailmail_letter.py, METHOD: _is_valid_address) ---
            */
            return default;
        }

        protected async Task<SnailmailLetter> OverwriteMarginsInternalAsync(object invoice_bin)
        {
            /*
            --- METHOD SOURCE (MODULE: snailmail, FILE: snailmail_letter.py, METHOD: _overwrite_margins) ---
            */
            return default;
        }

        protected async Task<SnailmailLetter> SnailmailCreateInternalAsync(object route)
        {
            /*
            --- METHOD SOURCE (MODULE: snailmail, FILE: snailmail_letter.py, METHOD: _snailmail_create) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<SnailmailLetter> SnailmailCronInternalAsync(object autocommit)
        {
            /*
            --- METHOD SOURCE (MODULE: snailmail, FILE: snailmail_letter.py, METHOD: _snailmail_cron) ---
            */
            return default;
        }

        protected async Task<SnailmailLetter> SnailmailPrintInternalAsync(object immediate)
        {
            /*
            --- METHOD SOURCE (MODULE: snailmail, FILE: snailmail_letter.py, METHOD: _snailmail_print) ---
            */
            return default;
        }

        protected async Task<SnailmailLetter> SnailmailPrintInvalidAddressInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: snailmail, FILE: snailmail_letter.py, METHOD: _snailmail_print_invalid_address) ---
            */
            return default;
        }

        protected async Task<SnailmailLetter> SnailmailPrintValidAddressInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: snailmail, FILE: snailmail_letter.py, METHOD: _snailmail_print_valid_address) ---
            */
            return default;
        }
    }
}