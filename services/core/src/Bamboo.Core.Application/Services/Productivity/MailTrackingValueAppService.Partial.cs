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
    public partial class MailTrackingValueAppService
    {

        [ApiModel]
        protected async Task<MailTrackingValue> CreateTrackingValuesInternalAsync(object initial_value, object new_value, object col_name, object col_info, object record)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_tracking_value.py, METHOD: _create_tracking_values) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<MailTrackingValue> CreateTrackingValuesPropertyInternalAsync(object initial_value, object col_name, object col_info, object record)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_tracking_value.py, METHOD: _create_tracking_values_property) ---
            */
            return default;
        }

        protected async Task<MailTrackingValue> ExceptAuditLogInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: mail_tracking_value.py, METHOD: _except_audit_log) ---
            */
            return default;
        }

        protected async Task<MailTrackingValue> FilterFreeFieldAccessInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_tracking_value.py, METHOD: _filter_free_field_access) ---
            */
            return default;
        }

        protected async Task<MailTrackingValue> FilterHasFieldAccessInternalAsync(object env)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_tracking_value.py, METHOD: _filter_has_field_access) ---
            */
            return default;
        }

        protected async Task<MailTrackingValue> FormatDisplayValueInternalAsync(object field_type, object @new)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_tracking_value.py, METHOD: _format_display_value) ---
            */
            return default;
        }

        protected async Task<MailTrackingValue> TrackingValueFormatInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_tracking_value.py, METHOD: _tracking_value_format) ---
            */
            return default;
        }

        protected async Task<MailTrackingValue> TrackingValueFormatModelInternalAsync(object model)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_tracking_value.py, METHOD: _tracking_value_format_model) ---
            */
            return default;
        }
    }
}