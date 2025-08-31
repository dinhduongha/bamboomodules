using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.AuthTotp
{
    [Route("api/v1/extra-tools/AuthTotpDevice")]
    public partial class AuthTotpDeviceController : AbpControllerBase
    {
        private readonly IAuthTotpDeviceAppService _appService;
        public AuthTotpDeviceController(IAuthTotpDeviceAppService appService) { _appService = appService; }
    }
}