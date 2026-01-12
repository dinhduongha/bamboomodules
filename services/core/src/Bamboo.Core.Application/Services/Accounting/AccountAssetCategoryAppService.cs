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
    [Module("OmAccountAsset", Category = "Accounting", Depends = new[] { "account" })]
    public class AccountAssetCategoryAppService : GenericApplicationService<AccountAssetCategory>, IAccountAssetCategoryAppService
    {
        private readonly IAnalyticMixinAppService _analyticMixinAppService;
        private readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        private readonly IMailThreadAppService _mailThreadAppService;
        public AccountAssetCategoryAppService(IRepository<AccountAssetCategory, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IAnalyticMixinAppService analyticMixinAppService, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _analyticMixinAppService = analyticMixinAppService;
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
        }

        public async Task<AccountAssetCategory> OnchangeAccountAssetAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def onchange_account_asset(self):
            // if self.type == "purchase":
            //     self.account_depreciation_id = self.account_asset_id
            // elif self.type == "sale":
            //     self.account_depreciation_expense_id = self.account_asset_id
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountAssetCategory> OnchangeMethodTimeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def _onchange_method_time(self):
            // if self.method_time != 'number':
            //     self.prorata = False
            */
            return default;
        }

        public async Task<AccountAssetCategory> OnchangeTypeAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def onchange_type(self):
            // if self.type == 'sale':
            //     self.prorata = True
            //     self.method_period = 1
            // else:
            //     self.method_period = 12
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}