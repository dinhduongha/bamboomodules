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
    public partial class LoyaltyCardAppService
    {

        protected async Task<LoyaltyCard> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_card.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<LoyaltyCard> ComputePointsDisplayInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_card.py, METHOD: _compute_points_display) ---
            */
            return default;
        }

        protected async Task<LoyaltyCard> ComputeUseCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_card.py, METHOD: _compute_use_count) ---
            --- METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_card.py, METHOD: _compute_use_count) ---
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: loyalty_card.py, METHOD: _compute_use_count) ---
            */
            return default;
        }

        protected async Task<LoyaltyCard> ContrainsCodeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_card.py, METHOD: _contrains_code) ---
            */
            return default;
        }

        protected async Task<LoyaltyCard> FormatPointsInternalAsync(object points)
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_card.py, METHOD: _format_points) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<LoyaltyCard> GenerateCodeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_card.py, METHOD: _generate_code) ---
            */
            return default;
        }

        protected async Task<LoyaltyCard> GetDefaultTemplateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_card.py, METHOD: _get_default_template) ---
            --- METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_card.py, METHOD: _get_default_template) ---
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: loyalty_card.py, METHOD: _get_default_template) ---
            */
            return default;
        }

        protected async Task<LoyaltyCard> GetMailAuthorInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_card.py, METHOD: _get_mail_author) ---
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: loyalty_card.py, METHOD: _get_mail_author) ---
            */
            return default;
        }

        protected async Task<LoyaltyCard> GetSignatureInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_card.py, METHOD: _get_signature) ---
            --- METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_card.py, METHOD: _get_signature) ---
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: loyalty_card.py, METHOD: _get_signature) ---
            */
            return default;
        }

        protected async Task<LoyaltyCard> HasSourceOrderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_card.py, METHOD: _has_source_order) ---
            --- METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_card.py, METHOD: _has_source_order) ---
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: loyalty_card.py, METHOD: _has_source_order) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<LoyaltyCard> LoadPosDataDomainInternalAsync(object data, object config)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_card.py, METHOD: _load_pos_data_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<LoyaltyCard> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_card.py, METHOD: _load_pos_data_fields) ---
            */
            return default;
        }

        protected async Task<LoyaltyCard> MailGetPartnerFieldsInternalAsync(object introspect_fields)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_card.py, METHOD: _mail_get_partner_fields) ---
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: loyalty_card.py, METHOD: _mail_get_partner_fields) ---
            */
            return default;
        }

        protected async Task<LoyaltyCard> RestrictExpirationOnLoyaltyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_card.py, METHOD: _restrict_expiration_on_loyalty) ---
            */
            return default;
        }

        protected async Task<LoyaltyCard> SendCreationCommunicationInternalAsync(object force_send)
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_card.py, METHOD: _send_creation_communication) ---
            */
            return default;
        }

        protected async Task<LoyaltyCard> SendPointsReachCommunicationInternalAsync(object points_changes)
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_card.py, METHOD: _send_points_reach_communication) ---
            */
            return default;
        }
    }
}