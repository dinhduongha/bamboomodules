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
    [Module("Account", Depends = new[] { "base_setup", "onboarding", "product", "analytic", "portal", "digest" })]
    public class AccountCashRoundingAppService : GenericApplicationService<AccountCashRounding>, IAccountCashRoundingAppService
    {
        private readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public AccountCashRoundingAppService(IRepository<AccountCashRounding, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _posLoadMixinAppService = posLoadMixinAppService;
        }

        protected async Task<AccountCashRounding> CheckSessionStateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _check_session_state(self):
            // open_session = self.env['pos.session'].search([('config_id.rounding_method', 'in', self.ids), ('state', '!=', 'closed')], limit=1)
            // if open_session:
            //     raise ValidationError(
            //         _("You are not allowed to change the cash rounding configuration while a pos session using it is already opened."))
            */
            return default;
        }

        public async Task<AccountCashRounding> ComputeDifferenceAsync(Guid id, AccountCashRoundingComputeDifferenceRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_cash_rounding.py) ---
            // def compute_difference(self, currency, amount):
            // """Compute the difference between the base_amount and the amount after rounding.
            // For example, base_amount=23.91, after rounding=24.00, the result will be 0.09.
            // 
            // :param currency: The currency.
            // :param amount: The amount
            // :return: round(difference)
            // """
            // amount = currency.round(amount)
            // difference = self.round(amount) - amount
            // return currency.round(difference)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountCashRounding> LoadPosDataDomainInternalAsync(object data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _load_pos_data_domain(self, data):
            // return [('id', '=', data['pos.config']['data'][0]['rounding_method'])]
            */
            return default;
        }

        protected async Task<AccountCashRounding> LoadPosDataFieldsInternalAsync(Guid config_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _load_pos_data_fields(self, config_id):
            // return ['id', 'name', 'rounding', 'rounding_method', 'strategy']
            */
            return default;
        }

        public async Task<AccountCashRounding> RoundAsync(Guid id, AccountCashRoundingRoundRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_cash_rounding.py) ---
            // def round(self, amount):
            // """Compute the rounding on the amount passed as parameter.
            // 
            // :param amount: the amount to round
            // :return: the rounded amount depending the rounding value and the rounding method
            // """
            // return float_round(amount, precision_rounding=self.rounding, rounding_method=self.rounding_method)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountCashRounding> UnlinkExceptPosConfigInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: account_cash_rounding.py) ---
            // def _unlink_except_pos_config(self):
            // if self.env['pos.config'].search_count([('rounding_method', 'in', self.ids)], limit=1):
            //     raise UserError(_('You cannot delete a rounding method that is used in a Point of Sale configuration.'))
            */
            return default;
        }

        public async Task<AccountCashRounding> ValidateRoundingAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_cash_rounding.py) ---
            // def validate_rounding(self):
            // for record in self:
            //     if record.rounding <= 0:
            //         raise ValidationError(_("Please set a strictly positive rounding value."))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}