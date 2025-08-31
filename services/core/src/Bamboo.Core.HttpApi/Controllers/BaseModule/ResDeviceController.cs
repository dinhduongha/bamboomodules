using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    [Route("api/v1/base/ResDevice")]
    public partial class ResDeviceController : AbpControllerBase
    {
        private readonly IResDeviceAppService _appService;
        public ResDeviceController(IResDeviceAppService appService) { _appService = appService; }
    }
}