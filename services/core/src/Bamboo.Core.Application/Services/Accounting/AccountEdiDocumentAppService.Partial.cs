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
    public partial class AccountEdiDocumentAppService
    {

        protected async Task<AccountEdiDocument> ComputeEdiContentInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi, FILE: account_edi_document.py, METHOD: _compute_edi_content) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountEdiDocument> CronProcessDocumentsWebServicesInternalAsync(object job_count)
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi, FILE: account_edi_document.py, METHOD: _cron_process_documents_web_services) ---
            */
            return default;
        }

        protected async Task<AccountEdiDocument> FilterEdiAttachmentsForMailingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi, FILE: account_edi_document.py, METHOD: _filter_edi_attachments_for_mailing) ---
            */
            return default;
        }

        protected async Task<AccountEdiDocument> PrepareJobsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi, FILE: account_edi_document.py, METHOD: _prepare_jobs) ---
            */
            return default;
        }

        protected async Task<AccountEdiDocument> ProcessDocumentsNoWebServicesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi, FILE: account_edi_document.py, METHOD: _process_documents_no_web_services) ---
            */
            return default;
        }

        protected async Task<AccountEdiDocument> ProcessDocumentsWebServicesInternalAsync(object job_count, object with_commit)
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi, FILE: account_edi_document.py, METHOD: _process_documents_web_services) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountEdiDocument> ProcessJobInternalAsync(object job)
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi, FILE: account_edi_document.py, METHOD: _process_job) ---
            */
            return default;
        }
    }
}