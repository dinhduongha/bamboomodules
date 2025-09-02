using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.AuthTotp
{
    [Route("api/v1/extra-tools/AuthTotpDevice")]
    public partial class AuthTotpDeviceController : AbpControllerBase
    {
        private readonly IAuthTotpDeviceAppService _appService;
        public AuthTotpDeviceController(IAuthTotpDeviceAppService appService) { _appService = appService; }
    }
}