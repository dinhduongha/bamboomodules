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
    public class ResCountryAppService : GenericApplicationService<ResCountry>, IResCountryAppService
    {
        private readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public ResCountryAppService(IRepository<ResCountry, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _posLoadMixinAppService = posLoadMixinAppService;
        }

        protected async Task<ResCountry> CheckAddressFormatInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_country.py) ---
            // def _check_address_format(self):
            // for record in self:
            //     if record.address_format:
            //         address_fields = self.env['res.partner']._formatting_address_fields() + ['state_code', 'state_name', 'country_code', 'country_name', 'company_name']
            //         try:
            //             record.address_format % {i: 1 for i in address_fields}
            //         except (ValueError, KeyError):
            //             raise UserError(_('The layout contains an invalid format key'))
            */
            return default;
        }

        protected async Task<ResCountry> ComputeImageUrlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_country.py) ---
            // def _compute_image_url(self):
            // for country in self:
            //     if not country.code or country.code in NO_FLAG_COUNTRIES:
            //         country.image_url = False
            //     else:
            //         code = FLAG_MAPPING.get(country.code, country.code.lower())
            //         country.image_url = "/base/static/img/country_flags/%s.png" % code
            */
            return default;
        }

        protected async Task<ResCountry> ComputeIsStripeSupportedCountryInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: res_country.py) ---
            // def _compute_is_stripe_supported_country(self):
            // for country in self:
            //     country.is_stripe_supported_country = stripe.const.COUNTRY_MAPPING.get(
            //         country.code, country.code
            //     ) in stripe.const.SUPPORTED_COUNTRIES
            */
            return default;
        }

        public async Task<ResCountry> GetAddressFieldsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_country.py) ---
            // def get_address_fields(self):
            // self.ensure_one()
            // return re.findall(r'\((.+?)\)', self.address_format)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResCountry> LoadPosDataFieldsInternalAsync(Guid config_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: res_country.py) ---
            // def _load_pos_data_fields(self, config_id):
            // return ['id', 'name', 'code', 'vat_label']
            */
            return default;
        }

        protected async Task<ResCountry> PhoneCodeForInternalAsync(object code)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_country.py) ---
            // def _phone_code_for(self, code):
            // return self.search([('code', '=', code)]).phone_code
            */
            return default;
        }
    }
}