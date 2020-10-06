using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.Collections.Extensions;

using Bamboo.Base.Shared;
using Bamboo.Base.Core;

namespace Bamboo.Base
{
    public class BaseBankAccountAppService : AsyncCrudAppService<BankAccount, BankAccountDto, Guid, BankAccountFilterDto, CreateBankAccountDto, BankAccountDto>, IBankAccountAppService
    {
        public BaseBankAccountAppService(IRepository<BankAccount,Guid> repository)
            :base(repository)
        {

        }

        protected override IQueryable<BankAccount> CreateFilteredQuery(BankAccountFilterDto input)
        {
            return base.CreateFilteredQuery(input);
        }

        protected override IQueryable<BankAccount> ApplySorting(IQueryable<BankAccount> query, BankAccountFilterDto input)
        {
            return base.ApplySorting(query, input);
        }

        public override async Task<BankAccountDto> CreateAsync(CreateBankAccountDto input)
        {
            await Task.CompletedTask;
            return null;
        }
    }

}