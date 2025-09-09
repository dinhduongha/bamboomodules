using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Iap
{
    [Route("api/v1/iap/IapAccount")]
    public partial class IapAccountController : AbpController
    {
        private readonly IIapAccountAppService _appService;
        public IapAccountController(IIapAccountAppService appService) { _appService = appService; }
    }
}