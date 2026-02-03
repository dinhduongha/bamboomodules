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
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("Account", Category = "Accounting", Depends = new[] { "base_setup", "onboarding", "product", "analytic", "portal", "digest" })]
    public partial class AccountReconcileModelAppService : GenericAppService<AccountReconcileModel>, IAccountReconcileModelAppService
    {
        private readonly IMailThreadAppService _mailThreadAppService;
        public AccountReconcileModelAppService(IRepository<AccountReconcileModel, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailThreadAppService mailThreadAppService) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {
            _mailThreadAppService = mailThreadAppService;
        }

        protected async Task<AccountReconcileModel> CheckMatchLabelParamInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_reconcile_model.py) ---
            // def _check_match_label_param(self):
            // for record in self:
            //     if record.match_label == 'match_regex':
            //         try:
            //             re.compile(record.match_label_param)
            //         except re.error:
            //             raise UserError(_('The regex is not valid'))
            */
            return default;
        }

        protected async Task<AccountReconcileModel> ComputeCanBeProposedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_reconcile_model.py) ---
            // def _compute_can_be_proposed(self):
            // for model in self:
            //     model.can_be_proposed = not model.mapped_partner_id and (model.match_label or model.match_amount or model.match_partner_ids or model.trigger == 'auto_reconcile')
            */
            return default;
        }

        protected async Task<AccountReconcileModel> ComputePartnerMappingInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_reconcile_model.py) ---
            // def _compute_partner_mapping(self):
            // for model in self:
            //     is_partner_mapping = model.match_label and len(model.line_ids) == 1 and model.line_ids[0].partner_id and not model.line_ids[0].account_id
            //     model.mapped_partner_id = is_partner_mapping and model.line_ids[0].partner_id.id
            */
            return default;
        }

        public async Task<AccountReconcileModel> CopyDataAsync(AccountReconcileModelCopyDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_reconcile_model.py) ---
            // def copy_data(self, default=None):
            // default = dict(default or {})
            // vals_list = super().copy_data(default)
            // if default.get('name'):
            //     return vals_list
            // for model, vals in zip(self, vals_list):
            //     name = _("%s (copy)", model.name)
            //     while self.env['account.reconcile.model'].search_count([('name', '=', name)], limit=1):
            //         name = _("%s (copy)", name)
            //     vals['name'] = name
            // return vals_list
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountReconcileModel> ReconcileStatAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_reconcile_model.py) ---
            // def action_reconcile_stat(self):
            // self.ensure_one()
            // action = self.env["ir.actions.actions"]._for_xml_id("account.action_move_journal_line")
            // self.env.cr.execute('''
            //     SELECT ARRAY_AGG(DISTINCT move_id)
            //     FROM account_move_line
            //     WHERE reconcile_model_id = %s
            // ''', [self.id])
            // action.update({
            //     'context': {},
            //     'domain': [('id', 'in', self.env.cr.fetchone()[0])],
            //     'help': """<p class="o_view_nocontent_empty_folder">{}</p>""".format(_('This reconciliation model has created no entry so far')),
            // })
            // return action
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountReconcileModel> SetAutoReconcileAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_reconcile_model.py) ---
            // def action_set_auto_reconcile(self):
            // self.trigger = 'auto_reconcile'
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountReconcileModel> SetManualAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_reconcile_model.py) ---
            // def action_set_manual(self):
            // self.trigger = 'manual'
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}