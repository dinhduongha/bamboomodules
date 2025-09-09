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
    [Module("BaseModule")]
    public class DecimalPrecisionAppService : GenericApplicationService<DecimalPrecision>, IDecimalPrecisionAppService
    {
        private readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public DecimalPrecisionAppService(IRepository<DecimalPrecision, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _posLoadMixinAppService = posLoadMixinAppService;
        }

        protected async Task<DecimalPrecision> CheckMainCurrencyRoundingInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: decimal_precision.py) ---
            // def _check_main_currency_rounding(self):
            // if any(precision.name == 'Account' and
            //         tools.float_compare(self.env.company.currency_id.rounding, 10 ** - precision.digits, precision_digits=6) == -1
            //         for precision in self):
            //     raise ValidationError(_("You cannot define the decimal precision of 'Account' as greater than the rounding factor of the company's main currency"))
            // return True
            */
            return default;
        }

        protected async Task<DecimalPrecision> LoadPosDataFieldsInternalAsync(Guid config_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: decimal_precision.py) ---
            // def _load_pos_data_fields(self, config_id):
            // return ['id', 'name', 'digits']
            */
            return default;
        }

        protected async Task<DecimalPrecision> OnchangeDigitsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: decimal_precision.py) ---
            // def _onchange_digits(self):
            // if self.name != "Product Unit of Measure":  # precision_get() relies on this name
            //     return
            // # We are changing the precision of UOM fields; check whether the
            // # precision is equal or higher than existing units of measure.
            // rounding = 1.0 / 10.0**self.digits
            // dangerous_uom = self.env['uom.uom'].search([('rounding', '<', rounding)])
            // if dangerous_uom:
            //     uom_descriptions = [
            //         " - %s (id=%s, precision=%s)" % (uom.name, uom.id, uom.rounding)
            //         for uom in dangerous_uom
            //     ]
            //     return {'warning': {
            //         'title': _('Warning!'),
            //         'message': _(
            //             "You are setting a Decimal Accuracy less precise than the UOMs:\n"
            //             "%s\n"
            //             "This may cause inconsistencies in computations.\n"
            //             "Please increase the rounding of those units of measure, or the digits of this Decimal Accuracy.",
            //             '\n'.join(uom_descriptions)),
            //     }}
            */
            return default;
        }

        protected async Task<DecimalPrecision> OnchangeDigitsWarningInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: decimal_precision.py) ---
            // def _onchange_digits_warning(self):
            // if self.digits < self._origin.digits:
            //     return {
            //         'warning': {
            //             'title': _("Warning for %s", self.name),
            //             'message': _(
            //                 "The precision has been reduced for %s.\n"
            //                 "Note that existing data WON'T be updated by this change.\n\n"
            //                 "As decimal precisions impact the whole system, this may cause critical issues.\n"
            //                 "E.g. reducing the precision could disturb your financial balance.\n\n"
            //                 "Therefore, changing decimal precisions in a running database is not recommended.",
            //                 self.name,
            //             )
            //         }
            //     }
            */
            return default;
        }

        public async Task<DecimalPrecision> PrecisionGetAsync(Guid id, DecimalPrecisionPrecisionGetRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: decimal_precision.py) ---
            // def precision_get(self, application):
            // stackmap = self.env.cr.cache.get('account_disable_recursion_stack', {})
            // if application == 'Discount' and stackmap.get('ignore_discount_precision'):
            //     return 100
            // return super().precision_get(application)
            --- ODOO METHOD SOURCE (MODULE: base, FILE: decimal_precision.py) ---
            // def precision_get(self, application):
            // self.flush_model(['name', 'digits'])
            // self.env.cr.execute('select digits from decimal_precision where name=%s', (application,))
            // res = self.env.cr.fetchone()
            // return res[0] if res else 2
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}