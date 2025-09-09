using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    [Route("api/v1/base/ResDevice")]
    public partial class ResDeviceController : AbpController
    {
        private readonly IResDeviceAppService _appService;
        public ResDeviceController(IResDeviceAppService appService) { _appService = appService; }
    }
}