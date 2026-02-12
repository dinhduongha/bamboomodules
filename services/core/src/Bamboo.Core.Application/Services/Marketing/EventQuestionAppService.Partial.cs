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
    public partial class EventQuestionAppService
    {

        protected async Task<EventQuestion> ComputeEventCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_question.py, METHOD: _compute_event_count) ---
            */
            return default;
        }

        protected async Task<EventQuestion> ComputeIsReusableInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_question.py, METHOD: _compute_is_reusable) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<EventQuestion> LoadPosDataDomainInternalAsync(object data, object config)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_event, FILE: event_question.py, METHOD: _load_pos_data_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<EventQuestion> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_event, FILE: event_question.py, METHOD: _load_pos_data_fields) ---
            */
            return default;
        }

        protected async Task<EventQuestion> UnlinkExceptAnsweredQuestionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_question.py, METHOD: _unlink_except_answered_question) ---
            */
            return default;
        }

        protected async Task<EventQuestion> UnlinkExceptDefaultQuestionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_question.py, METHOD: _unlink_except_default_question) ---
            */
            return default;
        }
    }
}