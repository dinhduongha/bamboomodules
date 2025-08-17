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
    [Module("AuthTotp", Depends = new[] { "web" })]
    public class AuthTotpDeviceAppService : GenericApplicationService<AuthTotpDevice>, IAuthTotpDeviceAppService
    {

        public AuthTotpDeviceAppService(IRepository<AuthTotpDevice, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<AuthTotpDevice> CheckCredentialsForUidInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_totp, FILE: auth_totp.py) ---
            // def _check_credentials_for_uid(self, *, scope, key, uid):
            // """Return True if device key matches given `scope` for user ID `uid`"""
            // assert uid, "uid is required"
            // return self._check_credentials(scope=scope, key=key) == uid
            */
            return default;
        }

        protected async Task<AuthTotpDevice> CheckCredentialsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _check_credentials(self, *, scope, key):
            // assert scope and key, "scope and key required"
            // index = key[:INDEX_SIZE]
            // self.env.cr.execute('''
            //     SELECT user_id, key
            //     FROM {} INNER JOIN res_users u ON (u.id = user_id)
            //     WHERE
            //         u.active and index = %s
            //         AND (scope IS NULL OR scope = %s)
            //         AND (
            //             expiration_date IS NULL OR
            //             expiration_date >= now() at time zone 'utc'
            //         )
            // '''.format(self._table),
            // [index, scope])
            // for user_id, current_key in self.env.cr.fetchall():
            //     if key and KEY_CRYPT_CONTEXT.verify(key, current_key):
            //         return user_id
            */
            return default;
        }

        protected async Task<AuthTotpDevice> CheckExpirationDateInternalAsync(object date)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _check_expiration_date(self, date):
            // # To be in a sudoed environment or to be an administrator
            // # to create a persistent key (no expiration date) or
            // # to exceed the maximum duration determined by the user's privileges.
            // if self.env.is_system():
            //     return
            // if not date:
            //     raise ValidationError(_("The API key must have an expiration date"))
            // max_duration = max(group.api_key_duration for group in self.env.user.groups_id) or 1.0
            // if date > datetime.datetime.now() + datetime.timedelta(days=max_duration):
            //     raise ValidationError(_("You cannot exceed %(duration)s days.", duration=max_duration))
            */
            return default;
        }

        protected async Task<AuthTotpDevice> ClassifyByUserInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_totp_mail, FILE: auth_totp_device.py) ---
            // def _classify_by_user(self):
            // devices_by_user = defaultdict(lambda: self.env['auth_totp.device'])
            // for device in self:
            //     devices_by_user[device.user_id] |= device
            // 
            // return devices_by_user
            */
            return default;
        }

        protected async Task<AuthTotpDevice> GcUserApikeysInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _gc_user_apikeys(self):
            // self.env.cr.execute(SQL("""
            //     DELETE FROM %s
            //     WHERE
            //         expiration_date IS NOT NULL AND
            //         expiration_date < now() at time zone 'utc'
            // """, SQL.identifier(self._table)))
            // _logger.info("GC %r delete %d entries", self._name, self.env.cr.rowcount)
            */
            return default;
        }

        protected async Task<AuthTotpDevice> GenerateInternalAsync(object scope, object name, object expiration_date)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_totp_mail, FILE: auth_totp_device.py) ---
            // def _generate(self, scope, name, expiration_date):
            // """ Notify users when trusted devices are added onto their account.
            // We override this method instead of 'create' as those records are inserted directly into the
            // database using raw SQL. """
            // 
            // res = super()._generate(scope, name, expiration_date)
            // 
            // self.env.user._notify_security_setting_update(
            //     _("Security Update: Device Added"),
            //     _(
            //         "A trusted device has just been added to your account: %(device_name)s",
            //         device_name=name
            //     ),
            // )
            // 
            // return res
            */
            return default;
        }

        public async Task<AuthTotpDevice> InitAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def init(self):
            // table = SQL.identifier(self._table)
            // self.env.cr.execute(SQL("""
            // CREATE TABLE IF NOT EXISTS %(table)s (
            //     id serial primary key,
            //     name varchar not null,
            //     user_id integer not null REFERENCES res_users(id) ON DELETE CASCADE,
            //     scope varchar,
            //     expiration_date timestamp without time zone,
            //     index varchar(%(index_size)s) not null CHECK (char_length(index) = %(index_size)s),
            //     key varchar not null,
            //     create_date timestamp without time zone DEFAULT (now() at time zone 'utc')
            // )
            // """, table=table, index_size=INDEX_SIZE))
            // 
            // index_name = self._table + "_user_id_index_idx"
            // if len(index_name) > 63:
            //     # unique determinist index name
            //     index_name = self._table[:50] + "_idx_" + sha256(self._table.encode()).hexdigest()[:8]
            // self.env.cr.execute(SQL(
            //     "CREATE INDEX IF NOT EXISTS %s ON %s (user_id, index)",
            //     SQL.identifier(index_name),
            //     table,
            // ))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AuthTotpDevice> RemoveAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def remove(self):
            // return self._remove()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AuthTotpDevice> RemoveInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _remove(self):
            // """Use the remove() method to remove an API Key. This method implement logic,
            // but won't check the identity (mainly used to remove trusted devices)"""
            // if not self:
            //     return {'type': 'ir.actions.act_window_close'}
            // if self.env.is_system() or self.mapped('user_id') == self.env.user:
            //     ip = request.httprequest.environ['REMOTE_ADDR'] if request else 'n/a'
            //     _logger.info("API key(s) removed: scope: <%s> for '%s' (#%s) from %s",
            //        self.mapped('scope'), self.env.user.login, self.env.uid, ip)
            //     self.sudo().unlink()
            //     return {'type': 'ir.actions.act_window_close'}
            // raise AccessError(_("You can not remove API keys unless they're yours or you are a system user"))
            */
            return default;
        }

        public override async Task<object> UnlinkAsync(List<Guid> ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_totp_mail, FILE: auth_totp_device.py) ---
            // def unlink(self):
            // """ Notify users when trusted devices are removed from their account. """
            // removed_devices_by_user = self._classify_by_user()
            // for user, removed_devices in removed_devices_by_user.items():
            //     user._notify_security_setting_update(
            //         _("Security Update: Device Removed"),
            //         _(
            //             "A trusted device has just been removed from your account: %(device_names)s",
            //             device_names=', '.join([device.name for device in removed_devices])
            //         ),
            //     )
            // 
            // return super().unlink()
            */
            return await base.UnlinkAsync(ids);
        }
    }
}