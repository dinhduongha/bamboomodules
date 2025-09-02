using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Iap
{
    [Route("api/v1/iap/IapAccount")]
    public partial class IapAccountController : AbpControllerBase
    {
        private readonly IIapAccountAppService _appService;
        public IapAccountController(IIapAccountAppService appService) { _appService = appService; }
    }
}