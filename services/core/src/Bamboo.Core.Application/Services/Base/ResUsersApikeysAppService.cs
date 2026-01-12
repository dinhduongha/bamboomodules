using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("BaseModule", Category = "Base")]
    public class ResUsersApikeysAppService : GenericApplicationService<ResUsersApikeys>, IResUsersApikeysAppService
    {

        public ResUsersApikeysAppService(IRepository<ResUsersApikeys, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<ResUsersApikeys> CheckCredentialsForUidInternalAsync()
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

        protected async Task<ResUsersApikeys> CheckCredentialsInternalAsync()
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

        protected async Task<ResUsersApikeys> CheckExpirationDateInternalAsync(object date)
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
            // max_duration = max(group.api_key_duration for group in self.env.user.all_group_ids) or 1.0
            // if date > datetime.datetime.now() + datetime.timedelta(days=max_duration):
            //     raise ValidationError(_("You cannot exceed %(duration)s days.", duration=max_duration))
            */
            return default;
        }

        protected async Task<ResUsersApikeys> GcUserApikeysInternalAsync()
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

        protected async Task<ResUsersApikeys> GenerateInternalAsync(object scope, object name, object expiration_date)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _generate(self, scope, name, expiration_date):
            // """Generates an api key.
            // :param str scope: the scope of the key. If None, the key will give access to any rpc.
            // :param str name: the name of the key, mainly intended to be displayed in the UI.
            // :param date expiration_date: the expiration date of the key.
            // :return: str: the key.
            // 
            // Note:
            // This method must be called in sudo to use a duration
            // greater than that allowed by the user's privileges.
            // For a persistent key (infinite duration), no value for expiration date.
            // """
            // self._check_expiration_date(expiration_date)
            // # no need to clear the LRU when *adding* a key, only when removing
            // k = binascii.hexlify(os.urandom(API_KEY_SIZE)).decode()
            // self.env.cr.execute("""
            // INSERT INTO {table} (name, user_id, scope, expiration_date, key, index)
            // VALUES (%s, %s, %s, %s, %s, %s)
            // RETURNING id
            // """.format(table=self._table),
            // [name, self.env.user.id, scope, expiration_date or None, KEY_CRYPT_CONTEXT.hash(k), k[:INDEX_SIZE]])
            // 
            // ip = request.httprequest.environ['REMOTE_ADDR'] if request else 'n/a'
            // _logger.info("%s generated: scope: <%s> for '%s' (#%s) from %s",
            //     self._description, scope, self.env.user.login, self.env.uid, ip)
            // 
            // return k
            */
            return default;
        }

        protected async Task<ResUsersApikeys> GetTrustedDeviceAgeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_totp, FILE: auth_totp.py) ---
            // def _get_trusted_device_age(self):
            // ICP = self.env['ir.config_parameter'].sudo()
            // try:
            //     nbr_days = int(ICP.get_param('auth_totp.trusted_device_age', TRUSTED_DEVICE_AGE_DAYS))
            //     if nbr_days <= 0:
            //         nbr_days = None
            // except ValueError:
            //     nbr_days = None
            // 
            // if nbr_days is None:
            //     _logger.warning("Invalid value for 'auth_totp.trusted_device_age', using default value.")
            //     nbr_days = TRUSTED_DEVICE_AGE_DAYS
            // 
            // return nbr_days * 86400
            */
            return default;
        }

        public async Task<ResUsersApikeys> InitAsync(Guid id)
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

        public async Task<ResUsersApikeys> RemoveAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def remove(self):
            // return self._remove()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResUsersApikeys> RemoveInternalAsync()
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
    }
}