using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    [NonController]
    [Authorize]
    [Route("api/v1/accounting/AccountRoot")]
    public partial class AccountRootController : AbpController
    {
        protected readonly IAccountRootAppService _appService;
        public AccountRootController(IAccountRootAppService appService) { _appService = appService; }


        [HttpPost]
        [Route("browse")]
        public async Task<IActionResult> BrowseAsync([FromBody] Guid[] ids)
        {
            var input = new AccountRootBrowseRequestDto()
            {
                Ids = ids,
            };
            var result = await _appService.BrowseAsync(input);
            return Ok(result);
        }
    }

}