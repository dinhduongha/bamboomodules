using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Models;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace Bamboo.Core.Application.Services
{
    [Module("BaseModule")]
    public class ResUsersSettingsAppService : GenericApplicationService<ResUsersSettings>, IResUsersSettingsAppService
    {
        private readonly IBusListenerMixinAppService _busListenerMixinAppService;
        public ResUsersSettingsAppService(IRepository<ResUsersSettings, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IBusListenerMixinAppService busListenerMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _busListenerMixinAppService = busListenerMixinAppService;
        }

        protected async Task<ResUsersSettings> BusChannelInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: bus, FILE: res_users_settings.py) ---
            // def _bus_channel(self):
            // return self.user_id._bus_channel()
            */
            return default;
        }

        protected async Task<ResUsersSettings> CleanupExpiredMutesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_users_settings.py) ---
            // def _cleanup_expired_mutes(self):
            // """
            // Cron job for cleanup expired unmute by resetting mute_until_dt and sending bus notifications.
            // """
            // settings = self.search([("mute_until_dt", "<=", fields.Datetime.now())])
            // settings.write({"mute_until_dt": False})
            // settings._notify_mute()
            */
            return default;
        }

        protected async Task<ResUsersSettings> FindOrCreateForUserInternalAsync(object user)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users_settings.py) ---
            // def _find_or_create_for_user(self, user):
            // settings = user.sudo().res_users_settings_ids
            // if not settings:
            //     settings = self.sudo().create({'user_id': user.id})
            // return settings
            */
            return default;
        }

        protected async Task<ResUsersSettings> FormatSettingsInternalAsync(object fields_to_format)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_users_settings.py) ---
            // def _format_settings(self, fields_to_format):
            // res = super()._format_settings(fields_to_format)
            // if 'volume_settings_ids' in fields_to_format:
            //     volume_settings = self.volume_settings_ids._discuss_users_settings_volume_format()
            //     res.pop('volume_settings_ids', None)
            //     res['volumes'] = [('ADD', volume_settings)]
            // if "mute_until_dt" in fields_to_format:
            //     res["mute_until_dt"] = fields.Datetime.to_string(self.mute_until_dt)
            // return res
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users_settings.py) ---
            // def _format_settings(self, fields_to_format):
            // res = self._read_format(fnames=fields_to_format)[0]
            // if 'user_id' in fields_to_format:
            //     res = self._read_format(fnames=fields_to_format)[0]
            //     res['user_id'] = {'id': self.user_id.id}
            // return res
            */
            return default;
        }

        protected async Task<ResUsersSettings> GetFieldsBlacklistInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: res_users_settings.py) ---
            // def _get_fields_blacklist(self):
            // """ Get list of calendar fields that won't be formatted in session_info. """
            // calendar_fields_blacklist = ['calendar_default_privacy']
            // return super()._get_fields_blacklist() + calendar_fields_blacklist
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: res_users_settings.py) ---
            // def _get_fields_blacklist(self):
            // """ Get list of google fields that won't be formatted in session_info. """
            // google_fields_blacklist = [
            //     'google_calendar_rtoken',
            //     'google_calendar_token',
            //     'google_calendar_token_validity',
            //     'google_calendar_sync_token',
            //     'google_calendar_cal_id',
            //     'google_synchronization_stopped'
            // ]
            // return super()._get_fields_blacklist() + google_fields_blacklist
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: res_users_settings.py) ---
            // def _get_fields_blacklist(self):
            // """ Get list of microsoft fields that won't be formatted in session_info. """
            // microsoft_fields_blacklist = [
            //     'microsoft_calendar_sync_token',
            //     'microsoft_synchronization_stopped',
            //     'microsoft_last_sync_date',
            // ]
            // return super()._get_fields_blacklist() + microsoft_fields_blacklist
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users_settings.py) ---
            // def _get_fields_blacklist(self):
            // """ Get list of fields that won't be formatted. """
            // return []
            */
            return default;
        }

        protected async Task<ResUsersSettings> GoogleCalendarAuthenticatedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: res_users_settings.py) ---
            // def _google_calendar_authenticated(self):
            // self.ensure_one()
            // return bool(self.sudo().google_calendar_rtoken)
            */
            return default;
        }

        protected async Task<ResUsersSettings> IsGoogleCalendarValidInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: res_users_settings.py) ---
            // def _is_google_calendar_valid(self):
            // self.ensure_one()
            // return self.sudo().google_calendar_token_validity and self.sudo().google_calendar_token_validity >= (fields.Datetime.now() + timedelta(minutes=1))
            */
            return default;
        }

        protected async Task<ResUsersSettings> NotifyMuteInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_users_settings.py) ---
            // def _notify_mute(self):
            // for setting in self:
            //     setting._bus_send("res.users.settings", {"mute_until_dt": setting.mute_until_dt})
            //     if setting.mute_until_dt and setting.mute_until_dt != -1:
            //         self.env.ref("mail.ir_cron_discuss_users_settings_unmute")._trigger(setting.mute_until_dt)
            */
            return default;
        }

        protected async Task<ResUsersSettings> RefreshGoogleCalendarTokenInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: res_users_settings.py) ---
            // def _refresh_google_calendar_token(self):
            // self.ensure_one()
            // 
            // try:
            //     access_token, ttl = self.env['google.service']._refresh_google_token('calendar', self.sudo().google_calendar_rtoken)
            //     self.sudo().write({
            //         'google_calendar_token': access_token,
            //         'google_calendar_token_validity': fields.Datetime.now() + timedelta(seconds=ttl),
            //     })
            // except requests.HTTPError as error:
            //     if error.response.status_code in (400, 401):  # invalid grant or invalid client
            //         # Delete refresh token and make sure it's commited
            //         self.env.cr.rollback()
            //         self.sudo()._set_google_auth_tokens(False, False, 0)
            //         self.env.cr.commit()
            //     error_key = error.response.json().get("error", "nc")
            //     error_msg = _("An error occurred while generating the token. Your authorization code may be invalid or has already expired [%s]. "
            //                   "You should check your Client ID and secret on the Google APIs plateform or try to stop and restart your calendar synchronization.",
            //                   error_key)
            //     raise UserError(error_msg)
            */
            return default;
        }

        protected async Task<ResUsersSettings> ResUsersSettingsFormatInternalAsync(object fields_to_format)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users_settings.py) ---
            // def _res_users_settings_format(self, fields_to_format=None):
            // self.ensure_one()
            // fields_blacklist = self._get_fields_blacklist()
            // if fields_to_format:
            //     fields_to_format = [field for field in fields_to_format if field not in fields_blacklist]
            // else:
            //     fields_to_format = [name for name, field in self._fields.items() if name == 'id' or (not field.automatic and name not in fields_blacklist)]
            // res = self._format_settings(fields_to_format)
            // return res
            */
            return default;
        }

        public async Task<ResUsersSettings> SetCustomNotificationsAsync(Guid id, ResUsersSettingsSetCustomNotificationsRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_users_settings.py) ---
            // def set_custom_notifications(self, custom_notifications):
            // self.set_res_users_settings({"channel_notifications": custom_notifications})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResUsersSettings> SetGoogleAuthTokensInternalAsync(object access_token, object refresh_token, object ttl)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: res_users_settings.py) ---
            // def _set_google_auth_tokens(self, access_token, refresh_token, ttl):
            // self.sudo().write({
            //     'google_calendar_rtoken': refresh_token,
            //     'google_calendar_token': access_token,
            //     'google_calendar_token_validity': fields.Datetime.now() + timedelta(seconds=ttl) if ttl else False,
            // })
            */
            return default;
        }

        public async Task<ResUsersSettings> SetResUsersSettingsAsync(Guid id, ResUsersSettingsSetResUsersSettingsRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_users_settings.py) ---
            // def set_res_users_settings(self, new_settings):
            // formatted = super().set_res_users_settings(new_settings)
            // self._bus_send("res.users.settings", formatted)
            // return formatted
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users_settings.py) ---
            // def set_res_users_settings(self, new_settings):
            // self.ensure_one()
            // changed_settings = {}
            // for setting in new_settings.keys():
            //     if setting in self._fields and new_settings[setting] != self[setting]:
            //         changed_settings[setting] = new_settings[setting]
            // self.write(changed_settings)
            // formated = self._res_users_settings_format([*changed_settings.keys(), 'id'])
            // return formated
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResUsersSettings> SetVolumeSettingAsync(Guid id, ResUsersSettingsSetVolumeSettingRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_users_settings.py) ---
            // def set_volume_setting(self, partner_id, volume, guest_id=None):
            // """
            // Saves the volume of a guest or a partner.
            // Either partner_id or guest_id must be specified.
            // :param float volume: the selected volume between 0 and 1
            // :param int partner_id:
            // :param int guest_id:
            // """
            // self.ensure_one()
            // volume_setting = self.env['res.users.settings.volumes'].search([
            //     ('user_setting_id', '=', self.id), ('partner_id', '=', partner_id), ('guest_id', '=', guest_id)
            // ])
            // if volume_setting:
            //     volume_setting.volume = volume
            // else:
            //     volume_setting = self.env['res.users.settings.volumes'].create({
            //         'user_setting_id': self.id,
            //         'volume': volume,
            //         'partner_id': partner_id,
            //         'guest_id': guest_id,
            //     })
            // self._bus_send(
            //     "res.users.settings.volumes", volume_setting._discuss_users_settings_volume_format()
            // )
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}