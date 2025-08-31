using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Iap
{
    [Route("api/v1/iap/IapAccount")]
    public partial class IapAccountController : AbpControllerBase
    {
        private readonly IIapAccountAppService _appService;
        public IapAccountController(IIapAccountAppService appService) { _appService = appService; }
    }
}