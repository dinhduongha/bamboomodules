using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Hidden, Module: base
    [Authorize]
    [Route("api/v1/base/ResDeviceLog")]
    public partial class ResDeviceLogController : AbpController
    {
        private readonly IResDeviceLogAppService _appService;
        public ResDeviceLogController(IResDeviceLogAppService appService) { _appService = appService; }
    }
}