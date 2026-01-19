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
    public partial class AccountRootAppService : GenericApplicationService<AccountRoot>, IAccountRootAppService
    {

        public AccountRootAppService(IRepository<AccountRoot, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        [ApiPrivate]
        public async Task<AccountRoot> BrowseAsync(Guid id, AccountRootBrowseRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_root.py) ---
            // def browse(self, ids=()):
            // if isinstance(ids, str):
            //     ids = (ids,)
            // return super().browse(ids)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<AccountRoot> ComputeRootInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_root.py) ---
            // def _compute_root(self):
            // for root in self:
            //     root.name = root.id
            //     root.parent_id = self.browse(root.id[:-1] if len(root.id) > 1 else False)
            */
            return default;
        }

        protected async Task<AccountRoot> FromAccountCodeInternalAsync(object code)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_root.py) ---
            // def _from_account_code(self, code):
            // return self.browse(code and code[:2])
            */
            return default;
        }

        protected async Task<object> SearchInternalAsync(object domain, object offset, object limit, object order)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_root.py) ---
            // def _search(self, domain, offset=0, limit=None, order=None, **kw) -> Query:
            // match list(domain):
            //     case [('id', 'in', ids)]:
            //         return self.browse(sorted(ids))._as_query()
            //     case [('id', 'parent_of', ids)]:
            //         return self.browse(sorted({s for _id in ids for s in accumulate(_id)}))._as_query()
            // raise UserError(self.env._("Filter on the Account or its Display Name instead"))
            */
            return default;
        }
    }
}