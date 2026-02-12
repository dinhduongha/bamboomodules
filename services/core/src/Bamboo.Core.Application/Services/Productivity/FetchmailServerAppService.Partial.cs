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
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Services
{
    public partial class FetchmailServerAppService
    {

        protected async Task<FetchmailServer> CheckUseGoogleGmailServiceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: google_gmail, FILE: fetchmail_server.py, METHOD: _check_use_google_gmail_service) ---
            */
            return default;
        }

        protected async Task<FetchmailServer> CheckUseMicrosoftOutlookServiceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_outlook, FILE: fetchmail_server.py, METHOD: _check_use_microsoft_outlook_service) ---
            */
            return default;
        }

        protected async Task<FetchmailServer> ComputeServerTypeInfoInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: google_gmail, FILE: fetchmail_server.py, METHOD: _compute_server_type_info) ---
            --- METHOD SOURCE (MODULE: mail, FILE: fetchmail.py, METHOD: _compute_server_type_info) ---
            --- METHOD SOURCE (MODULE: microsoft_outlook, FILE: fetchmail_server.py, METHOD: _compute_server_type_info) ---
            */
            return default;
        }

        protected async Task<FetchmailServer> ConnectInternalAsync(object allow_archived)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: fetchmail.py, METHOD: _connect__) ---
            */
            return default;
        }

        protected async Task<FetchmailServer> FetchMailInternalAsync(object batch_limit)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: fetchmail.py, METHOD: _fetch_mail) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<FetchmailServer> FetchMailsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: fetchmail.py, METHOD: _fetch_mails) ---
            */
            return default;
        }

        protected async Task<FetchmailServer> GetConnectionTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: google_gmail, FILE: fetchmail_server.py, METHOD: _get_connection_type) ---
            --- METHOD SOURCE (MODULE: mail, FILE: fetchmail.py, METHOD: _get_connection_type) ---
            --- METHOD SOURCE (MODULE: microsoft_outlook, FILE: fetchmail_server.py, METHOD: _get_connection_type) ---
            */
            return default;
        }

        protected async Task<FetchmailServer> ImapLoginInternalAsync(object connection)
        {
            /*
            --- METHOD SOURCE (MODULE: google_gmail, FILE: fetchmail_server.py, METHOD: _imap_login__) ---
            --- METHOD SOURCE (MODULE: mail, FILE: fetchmail.py, METHOD: _imap_login__) ---
            --- METHOD SOURCE (MODULE: microsoft_outlook, FILE: fetchmail_server.py, METHOD: _imap_login__) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<FetchmailServer> UpdateCronInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: fetchmail.py, METHOD: _update_cron) ---
            */
            return default;
        }
    }
}