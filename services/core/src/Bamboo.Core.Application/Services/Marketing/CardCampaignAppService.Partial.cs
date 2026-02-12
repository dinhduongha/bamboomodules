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
    public partial class CardCampaignAppService
    {

        protected async Task<CardCampaign> ActionShareGetDefaultBodyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: _action_share_get_default_body) ---
            */
            return default;
        }

        protected async Task<CardCampaign> CheckAccessRightDynamicTemplateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: _check_access_right_dynamic_template) ---
            */
            return default;
        }

        protected async Task<CardCampaign> ComputeCardStatsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: _compute_card_stats) ---
            */
            return default;
        }

        protected async Task<CardCampaign> ComputeImagePreviewInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: _compute_image_preview) ---
            */
            return default;
        }

        protected async Task<CardCampaign> ComputeMailingCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: _compute_mailing_count) ---
            */
            return default;
        }

        protected async Task<CardCampaign> ComputeRenderModelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: _compute_render_model) ---
            */
            return default;
        }

        protected async Task<CardCampaign> ComputeResModelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: _compute_res_model) ---
            */
            return default;
        }

        protected async Task<CardCampaign> DefaultCardTemplateIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: _default_card_template_id) ---
            */
            return default;
        }

        protected async Task<CardCampaign> FetchOrCreatePreviewCardInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: _fetch_or_create_preview_card) ---
            */
            return default;
        }

        protected async Task<CardCampaign> GetCardElementValuesInternalAsync(object record)
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: _get_card_element_values) ---
            */
            return default;
        }

        protected async Task<CardCampaign> GetImageB64InternalAsync(object record)
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: _get_image_b64) ---
            */
            return default;
        }

        protected async Task<CardCampaign> GetModelSelectionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: _get_model_selection) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<CardCampaign> GetRenderFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: _get_render_fields) ---
            */
            return default;
        }

        protected async Task<CardCampaign> GetUrlFromResIdInternalAsync(Guid res_id, object suffix)
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: _get_url_from_res_id) ---
            */
            return default;
        }

        protected async Task<CardCampaign> UpdateCardsInternalAsync(object domain, object auto_commit)
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: _update_cards) ---
            */
            return default;
        }
    }
}