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
    [Module("Lunch", Category = "HumanResources", Depends = new[] { "mail" })]
    public partial class LunchCashmoveAppService : GenericApplicationService<LunchCashmove>, ILunchCashmoveAppService
    {

        public LunchCashmoveAppService(IRepository<LunchCashmove, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<LunchCashmove> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_cashmove.py) ---
            // def _compute_display_name(self):
            // for cashmove in self:
            //     cashmove.display_name = '{} {}'.format(_('Lunch Cashmove'), '#%s' % (cashmove.id or "_"))
            */
            return default;
        }

        public async Task<LunchCashmove> GetWalletBalanceAsync(Guid id, LunchCashmoveGetWalletBalanceRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_cashmove.py) ---
            // def get_wallet_balance(self, user, include_config=True):
            // result = float_round(sum(move['amount'] for move in self.env['lunch.cashmove.report'].search_read(
            //     [('user_id', '=', user.id)], ['amount'])), precision_digits=2)
            // if include_config:
            //     result += user.company_id.lunch_minimum_threshold
            // return result
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}