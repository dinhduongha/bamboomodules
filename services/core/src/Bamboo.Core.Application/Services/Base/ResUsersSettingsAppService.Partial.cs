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
    public partial class ResUsersSettingsAppService
    {

        protected async Task<ResUsersSettings> BusChannelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: bus, FILE: res_users_settings.py, METHOD: _bus_channel) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResUsersSettings> FindOrCreateForUserInternalAsync(object user)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users_settings.py, METHOD: _find_or_create_for_user) ---
            */
            return default;
        }

        protected async Task<ResUsersSettings> FormatSettingsInternalAsync(object fields_to_format)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_users_settings.py, METHOD: _format_settings) ---
            --- METHOD SOURCE (MODULE: web, FILE: res_users_settings.py, METHOD: _format_settings) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_users_settings.py, METHOD: _format_settings) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResUsersSettings> GetFieldsBlacklistInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: res_users_settings.py, METHOD: _get_fields_blacklist) ---
            --- METHOD SOURCE (MODULE: google_calendar, FILE: res_users_settings.py, METHOD: _get_fields_blacklist) ---
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: res_users_settings.py, METHOD: _get_fields_blacklist) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_users_settings.py, METHOD: _get_fields_blacklist) ---
            */
            return default;
        }

        protected async Task<ResUsersSettings> GoogleCalendarAuthenticatedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: res_users_settings.py, METHOD: _google_calendar_authenticated) ---
            */
            return default;
        }

        protected async Task<ResUsersSettings> IsGoogleCalendarValidInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: res_users_settings.py, METHOD: _is_google_calendar_valid) ---
            */
            return default;
        }

        protected async Task<ResUsersSettings> RefreshGoogleCalendarTokenInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: res_users_settings.py, METHOD: _refresh_google_calendar_token) ---
            */
            return default;
        }

        protected async Task<ResUsersSettings> ResUsersSettingsFormatInternalAsync(object fields_to_format)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users_settings.py, METHOD: _res_users_settings_format) ---
            */
            return default;
        }

        protected async Task<ResUsersSettings> SetGoogleAuthTokensInternalAsync(object access_token, object refresh_token, object ttl)
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: res_users_settings.py, METHOD: _set_google_auth_tokens) ---
            */
            return default;
        }
    }
}