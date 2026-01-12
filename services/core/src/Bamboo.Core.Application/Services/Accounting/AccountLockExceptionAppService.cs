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
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("Account", Category = "Accounting", Depends = new[] { "base_setup", "onboarding", "product", "analytic", "portal", "digest" })]
    public class AccountLockExceptionAppService : GenericApplicationService<AccountLockException>, IAccountLockExceptionAppService
    {

        public AccountLockExceptionAppService(IRepository<AccountLockException, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<AccountLockException> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_lock_exception.py) ---
            // def _compute_display_name(self):
            // for record in self:
            //     record.display_name = _("Lock Date Exception %s", record.id)
            */
            return default;
        }

        protected async Task<AccountLockException> ComputeLockDatesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_lock_exception.py) ---
            // def _compute_lock_dates(self):
            // for exception in self:
            //     for field in SOFT_LOCK_DATE_FIELDS:
            //         if field == exception.lock_date_field:
            //             exception[field] = exception.lock_date
            //         else:
            //             exception[field] = date.max
            */
            return default;
        }

        protected async Task<AccountLockException> ComputeStateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_lock_exception.py) ---
            // def _compute_state(self):
            // for record in self:
            //     if not record.active:
            //         record.state = 'revoked'
            //     elif record.end_datetime and record.end_datetime < self.env.cr.now():
            //         record.state = 'expired'
            //     else:
            //         record.state = 'active'
            */
            return default;
        }

        protected async Task<AccountLockException> GetActiveExceptionsDomainInternalAsync(object company, object soft_lock_date_fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_lock_exception.py) ---
            // def _get_active_exceptions_domain(self, company, soft_lock_date_fields):
            // return [
            //     *expression.OR([(field, '<', company[field])] for field in soft_lock_date_fields if company[field]),
            //     ('company_id', '=', company.id),
            //     ('state', '=', 'active'),  # checks the datetime
            // ]
            */
            return default;
        }

        protected async Task<AccountLockException> GetAuditTrailDuringExceptionDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_lock_exception.py) ---
            // def _get_audit_trail_during_exception_domain(self):
            // self.ensure_one()
            // 
            // common_message_domain = [
            //     ('date', '>=', self.create_date),
            // ]
            // if self.user_id:
            //     common_message_domain.append(('create_uid', '=', self.user_id.id))
            // if self.end_datetime:
            //     common_message_domain.append(('date', '<=', self.end_datetime))
            // 
            // # Add restrictions on the accounting date to avoid unnecessary entries
            // min_date = self.lock_date
            // max_date = self.company_lock_date
            // move_date_domain = []
            // tracking_old_datetime_domain = []
            // tracking_new_datetime_domain = []
            // if min_date:
            //     move_date_domain.append([('date', '>=', min_date)])
            //     tracking_old_datetime_domain.append([('tracking_value_ids.old_value_datetime', '>=', min_date)])
            //     tracking_new_datetime_domain.append([('tracking_value_ids.new_value_datetime', '>=', min_date)])
            // if max_date:
            //     move_date_domain.append([('date', '<=', max_date)])
            //     tracking_old_datetime_domain.append([('tracking_value_ids.old_value_datetime', '<=', max_date)])
            //     tracking_new_datetime_domain.append([('tracking_value_ids.new_value_datetime', '<=', max_date)])
            // 
            // return [
            //     ('company_id', 'child_of', self.company_id.id),
            //     ('audit_trail_message_ids', 'any', common_message_domain),
            //     '|',
            //         # The date was changed from or to a value inside the excepted period
            //         ('audit_trail_message_ids', 'any', [
            //             ('tracking_value_ids.field_id', '=', self.env['ir.model.fields']._get('account.move', 'date').id),
            //             '|',
            //                 *expression.AND(tracking_old_datetime_domain),
            //                 *expression.AND(tracking_new_datetime_domain),
            //         ]),
            //         # The date of the move is inside the excepted period and sth. was changed on the move
            //         *expression.AND(move_date_domain),
            // ]
            */
            return default;
        }

        public async Task<AccountLockException> InitAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_lock_exception.py) ---
            // def init(self):
            // super().init()
            // create_index(
            //     self.env.cr,
            //     indexname='account_lock_exception_company_id_end_datetime_idx',
            //     tablename=self._table,
            //     expressions=['company_id', 'user_id', 'end_datetime'],
            //     where="active = TRUE"
            // )
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountLockException> InvalidateAffectedUserLockDatesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_lock_exception.py) ---
            // def _invalidate_affected_user_lock_dates(self):
            // affected_lock_date_fields = {exception.lock_date_field for exception in self}
            // self.env['res.company'].invalidate_model(
            //     fnames=[f'user_{field}' for field in list(affected_lock_date_fields)],
            // )
            */
            return default;
        }

        protected async Task<AccountLockException> RecreateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_lock_exception.py) ---
            // def _recreate(self):
            // """
            // 1. Copy all exceptions in self but update the company lock date.
            // 2. Revoke all exceptions in self.
            // 3. Return the new records from step 1.
            // """
            // if not self:
            //     return self.env['account.lock_exception']
            // vals_list = self.with_context(active_test=False).copy_data()
            // new_records = self.create(vals_list)
            // self.sudo().action_revoke()
            // return new_records
            */
            return default;
        }

        public async Task<AccountLockException> RevokeAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_lock_exception.py) ---
            // def action_revoke(self):
            // """Revokes an active exception."""
            // if not self.env.user.has_group('account.group_account_manager'):
            //     raise UserError(_("You cannot revoke Lock Date Exceptions. Ask someone with the 'Adviser' role."))
            // for record in self:
            //     if record.state == 'active':
            //         record_sudo = record.sudo()
            //         record_sudo.active = False
            //         record_sudo.end_datetime = fields.Datetime.now()
            //         record._invalidate_affected_user_lock_dates()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountLockException> SearchFiscalyearLockDateInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_lock_exception.py) ---
            // def _search_fiscalyear_lock_date(self, operator, value):
            // return self._search_lock_date('fiscalyear_lock_date', operator, value)
            */
            return default;
        }

        protected async Task<AccountLockException> SearchLockDateInternalAsync(object field, object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_lock_exception.py) ---
            // def _search_lock_date(self, field, operator, value):
            // if operator not in ['<', '<='] or not value:
            //     raise UserError(_('Operation not supported'))
            // return ['&',
            //           ('lock_date_field', '=', field),
            //           '|',
            //               ('lock_date', '=', False),
            //               ('lock_date', operator, value),
            //        ]
            */
            return default;
        }

        protected async Task<AccountLockException> SearchPurchaseLockDateInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_lock_exception.py) ---
            // def _search_purchase_lock_date(self, operator, value):
            // return self._search_lock_date('purchase_lock_date', operator, value)
            */
            return default;
        }

        protected async Task<AccountLockException> SearchSaleLockDateInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_lock_exception.py) ---
            // def _search_sale_lock_date(self, operator, value):
            // return self._search_lock_date('sale_lock_date', operator, value)
            */
            return default;
        }

        protected async Task<AccountLockException> SearchStateInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_lock_exception.py) ---
            // def _search_state(self, operator, value):
            // if operator not in ['=', '!='] or value not in ['revoked', 'expired', 'active']:
            //     raise UserError(_('Operation not supported'))
            // 
            // normal_domain_for_equals = []
            // if value == 'revoked':
            //     normal_domain_for_equals = [
            //         ('active', '=', False),
            //     ]
            // elif value == 'expired':
            //     normal_domain_for_equals = [
            //         '&',
            //             ('active', '=', True),
            //             ('end_datetime', '<', self.env.cr.now()),
            //     ]
            // elif value == 'active':
            //     normal_domain_for_equals = [
            //         '&',
            //             ('active', '=', True),
            //             '|',
            //                 ('end_datetime', '=', None),
            //                 ('end_datetime', '>=', self.env.cr.now()),
            //     ]
            // if operator == '=':
            //     return normal_domain_for_equals
            // else:
            //     return ['!'] + normal_domain_for_equals
            */
            return default;
        }

        protected async Task<AccountLockException> SearchTaxLockDateInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_lock_exception.py) ---
            // def _search_tax_lock_date(self, operator, value):
            // return self._search_lock_date('tax_lock_date', operator, value)
            */
            return default;
        }

        public async Task<AccountLockException> ShowAuditTrailDuringExceptionAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_lock_exception.py) ---
            // def action_show_audit_trail_during_exception(self):
            //  self.ensure_one()
            //  return {
            //      'name': _("Journal Items"),
            //      'type': 'ir.actions.act_window',
            //      'res_model': 'account.move.line',
            //      'view_mode': 'list,form',
            //      'domain': [('move_id', 'any', self._get_audit_trail_during_exception_domain())],
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}