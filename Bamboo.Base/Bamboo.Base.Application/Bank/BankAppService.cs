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
    public class BaseBankAppService : AsyncCrudAppService<Bank, BankDto, Guid, BankFilterDto, CreateBankDto, BankDto>, IBankAppService
    {
        public BaseBankAppService(IRepository<Bank,Guid> repository)
            :base(repository)
        {

        }

        protected override IQueryable<Bank> CreateFilteredQuery(BankFilterDto input)
        {
            return base.CreateFilteredQuery(input);
        }

        protected override IQueryable<Bank> ApplySorting(IQueryable<Bank> query, BankFilterDto input)
        {
            return base.ApplySorting(query, input);
        }

        public override Task<BankDto> CreateAsync(CreateBankDto input)
        {
            return base.CreateAsync(input);
        }
    }
}