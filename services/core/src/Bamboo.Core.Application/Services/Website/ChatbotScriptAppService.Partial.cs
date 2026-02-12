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
    public partial class ChatbotScriptAppService
    {

        protected async Task<ChatbotScript> CheckQuestionSelectionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py, METHOD: _check_question_selection) ---
            */
            return default;
        }

        protected async Task<ChatbotScript> ComputeFirstStepWarningInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py, METHOD: _compute_first_step_warning) ---
            */
            return default;
        }

        protected async Task<ChatbotScript> ComputeLeadCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm_livechat, FILE: chatbot_script.py, METHOD: _compute_lead_count) ---
            */
            return default;
        }

        protected async Task<ChatbotScript> ComputeLivechatChannelCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py, METHOD: _compute_livechat_channel_count) ---
            */
            return default;
        }

        protected async Task<ChatbotScript> GetChatbotLanguageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py, METHOD: _get_chatbot_language) ---
            */
            return default;
        }

        protected async Task<ChatbotScript> GetWelcomeStepsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py, METHOD: _get_welcome_steps) ---
            */
            return default;
        }

        protected async Task<ChatbotScript> OnchangeScriptStepIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py, METHOD: _onchange_script_step_ids) ---
            */
            return default;
        }

        protected async Task<ChatbotScript> PostWelcomeStepsInternalAsync(object discuss_channel)
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py, METHOD: _post_welcome_steps) ---
            */
            return default;
        }

        protected async Task<ChatbotScript> ToStoreDefaultsInternalAsync(object target)
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py, METHOD: _to_store_defaults) ---
            */
            return default;
        }

        protected async Task<ChatbotScript> ValidateEmailInternalAsync(object email_address, object discuss_channel)
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py, METHOD: _validate_email) ---
            */
            return default;
        }
    }
}