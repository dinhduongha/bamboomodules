using Bamboo.Base.Dtos;
using Bamboo.Base.Entities;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Bamboo.Base.Services
{
#if ENABLE_BANK_SERVICE
    //[RemoteService(IsEnabled = true)]
    public class BankAppService : BaseAppService, IBankAppService, IApplicationService
    {
        //private readonly IRepository<Bank, Guid> _repository;
        //IRepository<Bank, Guid> repository
        public BankAppService()
            :base()
        {
            //_repository = repository;
        }

        public Task<BankDto> CreateAsync(CreateBankDto input)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<BankDto> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResultDto<BankDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            return new PagedResultDto<BankDto>();
            //throw new NotImplementedException();
        }

        public Task<BankDto> UpdateAsync(Guid id, UpdateBankDto input)
        {
            throw new NotImplementedException();
        }
    }
#endif
}
