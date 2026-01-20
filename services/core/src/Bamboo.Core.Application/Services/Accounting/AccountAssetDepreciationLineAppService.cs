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
using Microsoft.Extensions.Caching.Distributed;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("OmAccountAsset", Category = "Accounting", Depends = new[] { "account" })]
    public partial class AccountAssetDepreciationLineAppService : GenericApplicationService<AccountAssetDepreciationLine>, IAccountAssetDepreciationLineAppService
    {

        public AccountAssetDepreciationLineAppService(IRepository<AccountAssetDepreciationLine, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {

        }

        public async Task<AccountAssetDepreciationLine> CreateGroupedMoveAsync(Guid id, AccountAssetDepreciationLineCreateGroupedMoveRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def create_grouped_move(self, post_move=True):
            // if not self.exists():
            //     return []
            // 
            // created_moves = self.env['account.move']
            // move = self.env['account.move'].create(self._prepare_move_grouped())
            // self.write({'move_id': move.id, 'move_check': True})
            // created_moves |= move
            // 
            // if post_move and created_moves:
            //     created_moves.action_post()
            // return [x.id for x in created_moves]
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountAssetDepreciationLine> CreateMoveAsync(Guid id, AccountAssetDepreciationLineCreateMoveRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def create_move(self, post_move=True):
            // created_moves = self.env['account.move']
            // for line in self:
            //     if line.move_id:
            //         raise UserError(_('This depreciation is already linked to a journal entry. Please post or delete it.'))
            //     move_vals = self._prepare_move(line)
            //     move = self.env['account.move'].create(move_vals)
            //     line.write({'move_id': move.id, 'move_check': True})
            //     created_moves |= move
            // 
            // if post_move and created_moves:
            //     created_moves.filtered(lambda m: any(m.asset_depreciation_ids.mapped('asset_id.category_id.open_asset'))).action_post()
            // return [x.id for x in created_moves]
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountAssetDepreciationLine> GetMoveCheckInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def _get_move_check(self):
            // for line in self:
            //     line.move_check = bool(line.move_id)
            */
            return default;
        }

        protected async Task<AccountAssetDepreciationLine> GetMovePostedCheckInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def _get_move_posted_check(self):
            // for line in self:
            //     line.move_posted_check = True if line.move_id and line.move_id.state == 'posted' else False
            */
            return default;
        }

        public async Task<AccountAssetDepreciationLine> LogMessageWhenPostedAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def log_message_when_posted(self):
            // def _format_message(message_description, tracked_values):
            //     message = ''
            //     if message_description:
            //         message = '<span>%s</span>' % message_description
            //     for name, values in tracked_values.items():
            //         message += '<div> &nbsp; &nbsp; &bull; <b>%s</b>: ' % name
            //         message += '%s</div>' % values
            //     return Markup(message)
            // 
            // for line in self:
            //     if line.move_id and line.move_id.state == 'draft':
            //         partner_name = line.asset_id.partner_id.name
            //         currency_name = line.asset_id.currency_id.name
            //         msg_values = {_('Currency'): currency_name, _('Amount'): line.amount}
            //         if partner_name:
            //             msg_values[_('Partner')] = partner_name
            //         msg = _format_message(_('Depreciation line posted.'), msg_values)
            //         line.asset_id.message_post(body=msg)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountAssetDepreciationLine> PostLinesAndCloseAssetAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def post_lines_and_close_asset(self):
            // # we re-evaluate the assets to determine whether we can close them
            // for line in self:
            //     line.log_message_when_posted()
            //     asset = line.asset_id
            //     if asset.currency_id.is_zero(asset.value_residual):
            //         asset.message_post(body=_("Document closed."))
            //         asset.write({'state': 'close'})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountAssetDepreciationLine> PrepareMoveGroupedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def _prepare_move_grouped(self):
            // asset_id = self[0].asset_id
            // category_id = asset_id.category_id  # we can suppose that all lines have the same category
            // account_analytic_id = asset_id.account_analytic_id
            // # analytic_tag_ids = asset_id.analytic_tag_ids
            // analytic_distribution = asset_id.analytic_distribution
            // 
            // depreciation_date = self.env.context.get('depreciation_date') or fields.Date.context_today(self)
            // amount = 0.0
            // for line in self:
            //     # Sum amount of all depreciation lines
            //     company_currency = line.asset_id.company_id.currency_id
            //     current_currency = line.asset_id.currency_id
            //     company = line.asset_id.company_id
            //     amount += current_currency._convert(line.amount, company_currency, company, fields.Date.today())
            // 
            // name = category_id.name + _(' (grouped)')
            // move_line_1 = {
            //     'name': name,
            //     'account_id': category_id.account_depreciation_id.id,
            //     'debit': 0.0,
            //     'credit': amount,
            //     'journal_id': category_id.journal_id.id,
            //     'analytic_distribution': analytic_distribution,
            // }
            // move_line_2 = {
            //     'name': name,
            //     'account_id': category_id.account_depreciation_expense_id.id,
            //     'credit': 0.0,
            //     'debit': amount,
            //     'journal_id': category_id.journal_id.id,
            //     'analytic_distribution': analytic_distribution,
            // }
            // move_vals = {
            //     'ref': category_id.name,
            //     'date': depreciation_date or False,
            //     'journal_id': category_id.journal_id.id,
            //     'line_ids': [(0, 0, move_line_1), (0, 0, move_line_2)],
            // }
            // 
            // return move_vals
            */
            return default;
        }

        protected async Task<AccountAssetDepreciationLine> PrepareMoveInternalAsync(object line)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def _prepare_move(self, line):
            // category_id = line.asset_id.category_id
            // analytic_distribution = line.asset_id.analytic_distribution
            // depreciation_date = self.env.context.get('depreciation_date') or line.depreciation_date or fields.Date.context_today(self)
            // company_currency = line.asset_id.company_id.currency_id
            // current_currency = line.asset_id.currency_id
            // prec = company_currency.decimal_places
            // amount = current_currency._convert(
            //     line.amount, company_currency, line.asset_id.company_id, depreciation_date)
            // asset_name = line.asset_id.name + ' (%s/%s)' % (line.sequence, len(line.asset_id.depreciation_line_ids))
            // move_line_1 = {
            //     'name': asset_name,
            //     'account_id': category_id.account_depreciation_id.id,
            //     'debit': 0.0 if float_compare(amount, 0.0, precision_digits=prec) > 0 else -amount,
            //     'credit': amount if float_compare(amount, 0.0, precision_digits=prec) > 0 else 0.0,
            //     'partner_id': line.asset_id.partner_id.id,
            //     'analytic_distribution': analytic_distribution,
            //     'currency_id': company_currency != current_currency and current_currency.id or company_currency.id,
            //     'amount_currency': - 1.0 * line.amount
            // }
            // move_line_2 = {
            //     'name': asset_name,
            //     'account_id': category_id.account_depreciation_expense_id.id,
            //     'credit': 0.0 if float_compare(amount, 0.0, precision_digits=prec) > 0 else -amount,
            //     'debit': amount if float_compare(amount, 0.0, precision_digits=prec) > 0 else 0.0,
            //     'partner_id': line.asset_id.partner_id.id,
            //     'analytic_distribution': analytic_distribution,
            //     'currency_id': company_currency != current_currency and current_currency.id or company_currency.id,
            //     'amount_currency': line.amount,
            // }
            // move_vals = {
            //     'ref': line.asset_id.code,
            //     'date': depreciation_date or False,
            //     'journal_id': category_id.journal_id.id,
            //     'line_ids': [(0, 0, move_line_1), (0, 0, move_line_2)],
            // }
            // return move_vals
            */
            return default;
        }
    }
}