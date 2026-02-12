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
    public partial class MailAliasAppService
    {

        protected async Task<MailAlias> AliasBounceIncomingEmailInternalAsync(object message, object message_dict, object set_invalid)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_alias.py, METHOD: _alias_bounce_incoming_email) ---
            */
            return default;
        }

        protected async Task<MailAlias> CheckAliasDefaultsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_alias.py, METHOD: _check_alias_defaults) ---
            */
            return default;
        }

        protected async Task<MailAlias> CheckAliasDomainClashInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_alias.py, METHOD: _check_alias_domain_clash) ---
            */
            return default;
        }

        protected async Task<MailAlias> CheckAliasDomainIdMcInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_alias.py, METHOD: _check_alias_domain_id_mc) ---
            */
            return default;
        }

        protected async Task<MailAlias> CheckAliasIsAsciiInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_alias.py, METHOD: _check_alias_is_ascii) ---
            */
            return default;
        }

        protected async Task<MailAlias> CheckUniqueInternalAsync(object alias_names, object alias_domains)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_alias.py, METHOD: _check_unique) ---
            */
            return default;
        }

        protected async Task<MailAlias> ComputeAliasFullNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_alias.py, METHOD: _compute_alias_full_name) ---
            */
            return default;
        }

        protected async Task<MailAlias> ComputeAliasStatusInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_alias.py, METHOD: _compute_alias_status) ---
            */
            return default;
        }

        protected async Task<MailAlias> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_alias.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<MailAlias> GetAliasBouncedBodyFallbackInternalAsync(object message_dict)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_alias.py, METHOD: _get_alias_bounced_body_fallback) ---
            */
            return default;
        }

        protected async Task<MailAlias> GetAliasBouncedBodyInternalAsync(object message_dict)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_alias.py, METHOD: _get_alias_bounced_body) ---
            */
            return default;
        }

        protected async Task<MailAlias> GetAliasContactDescriptionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: mail_alias.py, METHOD: _get_alias_contact_description) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_alias.py, METHOD: _get_alias_contact_description) ---
            */
            return default;
        }

        protected async Task<MailAlias> GetAliasInvalidBodyInternalAsync(object message_dict)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_alias.py, METHOD: _get_alias_invalid_body) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<MailAlias> IsEncodableInternalAsync(object alias_name, object charset)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_alias.py, METHOD: _is_encodable) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<MailAlias> SanitizeAliasNameInternalAsync(object name, object is_email)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_alias.py, METHOD: _sanitize_alias_name) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<MailAlias> SanitizeAllowedDomainsInternalAsync(object allowed_domains)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_alias.py, METHOD: _sanitize_allowed_domains) ---
            */
            return default;
        }
    }
}