using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Application.Services;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
using Microsoft.Extensions.Caching.Memory;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;

namespace Bamboo.Core.Application.Services
{
    [Module("OmAccountAsset", Depends = new[] { "account" })]
    public class AccountAssetAssetAppService : GenericApplicationService<AccountAssetAsset>, IAccountAssetAssetAppService
    {
        private readonly IAnalyticMixinAppService _analyticMixinAppService;
        private readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        private readonly IMailThreadAppService _mailThreadAppService;
        public AccountAssetAssetAppService(IRepository<AccountAssetAsset, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IAnalyticMixinAppService analyticMixinAppService, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _analyticMixinAppService = analyticMixinAppService;
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
        }

        protected async Task<AccountAssetAsset> AmountResidualInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def _amount_residual(self):
            // for rec in self:
            //     total_amount = 0.0
            //     for line in rec.depreciation_line_ids:
            //         if line.move_check:
            //             total_amount += line.amount
            //     rec.value_residual = rec.value - total_amount - rec.salvage_value
            */
            return default;
        }

        protected async Task<AccountAssetAsset> CheckProrataInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def _check_prorata(self):
            // if self.prorata and self.method_time != 'number':
            //     raise ValidationError(_('Prorata temporis can be applied only for the "number of depreciations" time method.'))
            */
            return default;
        }

        protected async Task<AccountAssetAsset> ComputeBoardAmountInternalAsync(object sequence, object residual_amount, object amount_to_depr, object undone_dotation_number, List<Guid> posted_depreciation_line_ids, object total_days, object depreciation_date)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def _compute_board_amount(self, sequence, residual_amount, amount_to_depr,
            //                       undone_dotation_number, posted_depreciation_line_ids,
            //                       total_days, depreciation_date):
            // amount = 0
            // if sequence == undone_dotation_number:
            //     amount = residual_amount
            // else:
            //     if self.method == 'linear':
            //         amount = amount_to_depr / (undone_dotation_number - len(posted_depreciation_line_ids))
            //         if self.prorata:
            //             amount = amount_to_depr / self.method_number
            //             if sequence == 1:
            //                 date = self.date
            //                 if self.method_period % 12 != 0:
            //                     month_days = calendar.monthrange(date.year, date.month)[1]
            //                     days = month_days - date.day + 1
            //                     amount = (amount_to_depr / self.method_number) / month_days * days
            //                 else:
            //                     days = (self.company_id.compute_fiscalyear_dates(date)['date_to'] - date).days + 1
            //                     amount = (amount_to_depr / self.method_number) / total_days * days
            //     elif self.method == 'degressive':
            //         amount = residual_amount * self.method_progress_factor
            //         if self.prorata:
            //             if sequence == 1:
            //                 date = self.date
            //                 if self.method_period % 12 != 0:
            //                     month_days = calendar.monthrange(date.year, date.month)[1]
            //                     days = month_days - date.day + 1
            //                     amount = (residual_amount * self.method_progress_factor) / month_days * days
            //                 else:
            //                     days = (self.company_id.compute_fiscalyear_dates(date)['date_to'] - date).days + 1
            //                     amount = (residual_amount * self.method_progress_factor) / total_days * days
            // return amount
            */
            return default;
        }

        protected async Task<AccountAssetAsset> ComputeBoardUndoneDotationNbInternalAsync(object depreciation_date, object total_days)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def _compute_board_undone_dotation_nb(self, depreciation_date, total_days):
            // undone_dotation_number = self.method_number
            // if self.method_time == 'end':
            //     end_date = self.method_end
            //     undone_dotation_number = 0
            //     while depreciation_date <= end_date:
            //         depreciation_date = date(depreciation_date.year, depreciation_date.month,
            //                                  depreciation_date.day) + relativedelta(months=+self.method_period)
            //         undone_dotation_number += 1
            // if self.prorata:
            //     undone_dotation_number += 1
            // return undone_dotation_number
            */
            return default;
        }

        public async Task<AccountAssetAsset> ComputeDepreciationBoardAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def compute_depreciation_board(self):
            // self.ensure_one()
            // 
            // posted_depreciation_line_ids = self.depreciation_line_ids.filtered(lambda x: x.move_check).sorted(key=lambda l: l.depreciation_date)
            // unposted_depreciation_line_ids = self.depreciation_line_ids.filtered(lambda x: not x.move_check)
            // 
            // # Remove old unposted depreciation lines. We cannot use unlink() with One2many field
            // commands = [(2, line_id.id, False) for line_id in unposted_depreciation_line_ids]
            // 
            // if self.value_residual != 0.0:
            //     amount_to_depr = residual_amount = self.value_residual
            // 
            //     # if we already have some previous validated entries, starting date is last entry + method period
            //     if posted_depreciation_line_ids and posted_depreciation_line_ids[-1].depreciation_date:
            //         last_depreciation_date = fields.Date.from_string(posted_depreciation_line_ids[-1].depreciation_date)
            //         depreciation_date = last_depreciation_date + relativedelta(months=+self.method_period)
            //     else:
            //         # depreciation_date computed from the purchase date
            //         depreciation_date = self.date
            //         if self.date_first_depreciation == 'last_day_period':
            //             # depreciation_date = the last day of the month
            //             depreciation_date = depreciation_date + relativedelta(day=31)
            //             # ... or fiscalyear depending the number of period
            //             if self.method_period == 12:
            //                 depreciation_date = depreciation_date + relativedelta(month=int(self.company_id.fiscalyear_last_month))
            //                 depreciation_date = depreciation_date + relativedelta(day=int(self.company_id.fiscalyear_last_day))
            //                 if depreciation_date < self.date:
            //                     depreciation_date = depreciation_date + relativedelta(years=1)
            //         elif self.first_depreciation_manual_date and self.first_depreciation_manual_date != self.date:
            //             # depreciation_date set manually from the 'first_depreciation_manual_date' field
            //             depreciation_date = self.first_depreciation_manual_date
            //     total_days = (depreciation_date.year % 4) and 365 or 366
            //     month_day = depreciation_date.day
            //     undone_dotation_number = self._compute_board_undone_dotation_nb(depreciation_date, total_days)
            // 
            //     for x in range(len(posted_depreciation_line_ids), undone_dotation_number):
            //         sequence = x + 1
            //         amount = self._compute_board_amount(sequence, residual_amount, amount_to_depr,
            //                                             undone_dotation_number, posted_depreciation_line_ids,
            //                                             total_days, depreciation_date)
            //         amount = self.currency_id.round(amount)
            //         if float_is_zero(amount, precision_rounding=self.currency_id.rounding):
            //             continue
            //         residual_amount -= amount
            //         vals = {
            //             'amount': amount,
            //             'asset_id': self.id,
            //             'sequence': sequence,
            //             'name': (self.code or '') + '/' + str(sequence),
            //             'remaining_value': residual_amount,
            //             'depreciated_value': self.value - (self.salvage_value + residual_amount),
            //             'depreciation_date': depreciation_date,
            //         }
            //         commands.append((0, False, vals))
            // 
            //         depreciation_date = depreciation_date + relativedelta(months=+self.method_period)
            // 
            //         if month_day > 28 and self.date_first_depreciation == 'manual':
            //             max_day_in_month = calendar.monthrange(depreciation_date.year, depreciation_date.month)[1]
            //             depreciation_date = depreciation_date.replace(day=min(max_day_in_month, month_day))
            // 
            //         # datetime doesn't take into account that the number of days is not the same for each month
            //         if not self.prorata and self.method_period % 12 != 0 and self.date_first_depreciation == 'last_day_period':
            //             max_day_in_month = calendar.monthrange(depreciation_date.year, depreciation_date.month)[1]
            //             depreciation_date = depreciation_date.replace(day=max_day_in_month)
            // 
            // self.write({'depreciation_line_ids': commands})
            // 
            // return True
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountAssetAsset> ComputeEntriesInternalAsync(object date, object group_entries)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def _compute_entries(self, date, group_entries=False):
            // depreciation_ids = self.env['account.asset.depreciation.line'].search([
            //     ('asset_id', 'in', self.ids), ('depreciation_date', '<=', date),
            //     ('move_check', '=', False)])
            // if group_entries:
            //     return depreciation_ids.create_grouped_move()
            // return depreciation_ids.create_move()
            */
            return default;
        }

        public async Task<AccountAssetAsset> ComputeGeneratedEntriesAsync(Guid id, AccountAssetAssetComputeGeneratedEntriesRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def compute_generated_entries(self, date, asset_type=None):
            // # Entries generated : one by grouped category and one by asset from ungrouped category
            // created_move_ids = []
            // type_domain = []
            // if asset_type:
            //     type_domain = [('type', '=', asset_type)]
            // 
            // ungrouped_assets = self.env['account.asset.asset'].search(type_domain + [('state', '=', 'open'), ('category_id.group_entries', '=', False)])
            // created_move_ids += ungrouped_assets._compute_entries(date, group_entries=False)
            // 
            // for grouped_category in self.env['account.asset.category'].search(type_domain + [('group_entries', '=', True)]):
            //     assets = self.env['account.asset.asset'].search([('state', '=', 'open'), ('category_id', '=', grouped_category.id)])
            //     created_move_ids += assets._compute_entries(date, group_entries=True)
            // return created_move_ids
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountAssetAsset> CopyDataAsync(Guid id, AccountAssetAssetCopyDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def copy_data(self, default=None):
            // if default is None:
            //     default = {}
            // default['name'] = self.name + _(' (copy)')
            // return super(AccountAssetAsset, self).copy_data(default)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountAssetAsset> CronGenerateEntriesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def _cron_generate_entries(self):
            // self.compute_generated_entries(datetime.today())
            */
            return default;
        }

        protected async Task<AccountAssetAsset> EntryCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def _entry_count(self):
            // for asset in self:
            //     res = self.env['account.asset.depreciation.line'].search_count([('asset_id', '=', asset.id), ('move_id', '!=', False)])
            //     asset.entry_count = res or 0
            */
            return default;
        }

        protected async Task<AccountAssetAsset> GetDisposalMovesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def _get_disposal_moves(self):
            // move_ids = []
            // for asset in self:
            //     unposted_depreciation_line_ids = asset.depreciation_line_ids.filtered(lambda x: not x.move_check)
            //     if unposted_depreciation_line_ids:
            //         old_values = {
            //             'method_end': asset.method_end,
            //             'method_number': asset.method_number,
            //         }
            // 
            //         # Remove all unposted depr. lines
            //         commands = [(2, line_id.id, False) for line_id in unposted_depreciation_line_ids]
            // 
            //         # Create a new depr. line with the residual amount and post it
            //         sequence = len(asset.depreciation_line_ids) - len(unposted_depreciation_line_ids) + 1
            //         today = fields.Datetime.today()
            //         vals = {
            //             'amount': asset.value_residual,
            //             'asset_id': asset.id,
            //             'sequence': sequence,
            //             'name': (asset.code or '') + '/' + str(sequence),
            //             'remaining_value': 0,
            //             'depreciated_value': asset.value - asset.salvage_value,  # the asset is completely depreciated
            //             'depreciation_date': today,
            //         }
            //         commands.append((0, False, vals))
            //         asset.write({'depreciation_line_ids': commands, 'method_end': today, 'method_number': sequence})
            //         tracked_fields = self.env['account.asset.asset'].fields_get(['method_number', 'method_end'])
            //         changes, tracking_value_ids = asset._mail_track(tracked_fields, old_values)
            //         if changes:
            //             asset.message_post(subject=_('Asset sold or disposed. Accounting entry awaiting for validation.'), tracking_value_ids=tracking_value_ids)
            //         move_ids += asset.depreciation_line_ids[-1].create_move(post_move=False)
            // 
            // return move_ids
            */
            return default;
        }

        public async Task<AccountAssetAsset> OnchangeCategoryIdAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def onchange_category_id(self):
            // vals = self.onchange_category_id_values(self.category_id.id)
            // # We cannot use 'write' on an object that doesn't exist yet
            // if vals:
            //     for k, v in vals['value'].items():
            //         setattr(self, k, v)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountAssetAsset> OnchangeCategoryIdValuesAsync(Guid id, AccountAssetAssetOnchangeCategoryIdValuesRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def onchange_category_id_values(self, category_id):
            // if category_id:
            //     category = self.env['account.asset.category'].browse(category_id)
            //     return {
            //         'value': {
            //             'method': category.method,
            //             'method_number': category.method_number,
            //             'method_time': category.method_time,
            //             'method_period': category.method_period,
            //             'method_progress_factor': category.method_progress_factor,
            //             'method_end': category.method_end,
            //             'prorata': category.prorata,
            //             'date_first_depreciation': category.date_first_depreciation,
            //             'account_analytic_id': category.account_analytic_id.id,
            //             'analytic_distribution': category.analytic_distribution,
            //         }
            //     }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountAssetAsset> OnchangeCompanyIdAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def onchange_company_id(self):
            // self.currency_id = self.company_id.currency_id.id
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountAssetAsset> OnchangeDateFirstDepreciationAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def onchange_date_first_depreciation(self):
            // for record in self:
            //     if record.date_first_depreciation == 'manual':
            //         record.first_depreciation_manual_date = record.date
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountAssetAsset> OnchangeMethodTimeAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def onchange_method_time(self):
            // if self.method_time != 'number':
            //     self.prorata = False
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountAssetAsset> OpenEntriesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def open_entries(self):
            // move_ids = []
            // for asset in self:
            //     for depreciation_line in asset.depreciation_line_ids:
            //         if depreciation_line.move_id:
            //             move_ids.append(depreciation_line.move_id.id)
            // return {
            //     'name': _('Journal Entries'),
            //     'view_type': 'form',
            //     'view_mode': 'list,form',
            //     'res_model': 'account.move',
            //     'view_id': False,
            //     'type': 'ir.actions.act_window',
            //     'domain': [('id', 'in', move_ids)],
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountAssetAsset> ReturnDisposalViewInternalAsync(List<Guid> move_ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def _return_disposal_view(self, move_ids):
            // name = _('Disposal Move')
            // view_mode = 'form'
            // if len(move_ids) > 1:
            //     name = _('Disposal Moves')
            //     view_mode = 'tree,form'
            // return {
            //     'name': name,
            //     'view_type': 'form',
            //     'view_mode': view_mode,
            //     'res_model': 'account.move',
            //     'type': 'ir.actions.act_window',
            //     'target': 'current',
            //     'res_id': move_ids[0],
            // }
            */
            return default;
        }

        public async Task<AccountAssetAsset> SetToCloseAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def set_to_close(self):
            // move_ids = self._get_disposal_moves()
            // if move_ids:
            //     return self._return_disposal_view(move_ids)
            // # Fallback, as if we just clicked on the smartbutton
            // return self.open_entries()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountAssetAsset> SetToDraftAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def set_to_draft(self):
            // self.write({'state': 'draft'})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountAssetAsset> ValidateAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def validate(self):
            // self.write({'state': 'open'})
            // fields = [
            //     'method',
            //     'method_number',
            //     'method_period',
            //     'method_end',
            //     'method_progress_factor',
            //     'method_time',
            //     'salvage_value',
            //     'invoice_id',
            // ]
            // ref_tracked_fields = self.env['account.asset.asset'].fields_get(fields)
            // for asset in self:
            //     tracked_fields = ref_tracked_fields.copy()
            //     if asset.method == 'linear':
            //         del(tracked_fields['method_progress_factor'])
            //     if asset.method_time != 'end':
            //         del(tracked_fields['method_end'])
            //     else:
            //         del(tracked_fields['method_number'])
            //     dummy, tracking_value_ids = asset._mail_track(tracked_fields, dict.fromkeys(fields))
            //     asset.message_post(subject=_('Asset created'), tracking_value_ids=tracking_value_ids)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}