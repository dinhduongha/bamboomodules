using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.AuthTotp
{
    [Route("api/v1/extra-tools/AuthTotpDevice")]
    public partial class AuthTotpDeviceController : AbpController
    {
        private readonly IAuthTotpDeviceAppService _appService;
        public AuthTotpDeviceController(IAuthTotpDeviceAppService appService) { _appService = appService; }
    }
}