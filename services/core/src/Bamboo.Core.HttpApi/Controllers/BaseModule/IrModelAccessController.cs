using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    [Route("api/v1/base/IrModelAccess")]
    public partial class IrModelAccessController : AbpControllerBase
    {
        private readonly IIrModelAccessAppService _appService;
        public IrModelAccessController(IIrModelAccessAppService appService) { _appService = appService; }
    }
}