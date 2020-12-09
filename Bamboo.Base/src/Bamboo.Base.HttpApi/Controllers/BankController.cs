using System;
using System.Threading.Tasks;
using Bamboo.Base.Dtos;
using Bamboo.Base.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Bamboo.Base.Controllers
{
    /*
    //[RemoteService]
    [Route("api/BankCo/bbbbbb")]
    //https://docs.abp.io/en/abp/latest/API/Auto-API-Controllers
    public class BankXXXController : BaseController, IBankAppService
    {
        private readonly IBankAppService _bankAppService;

        public BankXXXController(IBankAppService bankAppService)
        {
            _bankAppService = bankAppService;
        }

        [HttpPost]
        public Task<BankDto> CreateAsync(CreateBankDto input)
        {
            return _bankAppService.CreateAsync(input);
        }

        [HttpDelete]
        public Task DeleteAsync(Guid id)
        {
            return _bankAppService.DeleteAsync(id);
        }


        [HttpGet]
        public Task<BankDto> GetAsync(Guid id)
        {
            return _bankAppService.GetAsync(id);
        }

        [HttpGet]
        [Route("list")]
        public Task<PagedResultDto<BankDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            return _bankAppService.GetListAsync(input);
        }

        [HttpPut]
        public Task<BankDto> UpdateAsync(Guid id, UpdateBankDto input)
        {
            return _bankAppService.UpdateAsync(id, input);
        }
    }
    */

}
