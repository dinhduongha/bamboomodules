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
    public class DecimalPrecisionAppService : GenericApplicationService<DecimalPrecision>, IDecimalPrecisionAppService
    {
        private readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public DecimalPrecisionAppService(IRepository<DecimalPrecision, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _posLoadMixinAppService = posLoadMixinAppService;
        }

        protected async Task<DecimalPrecision> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: decimal_precision.py) ---
            // def _load_pos_data_fields(self, config):
            // return ['id', 'name', 'digits']
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
            //             'title': self.env._("Warning for %s", self.name),
            //             'message': self.env._(
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