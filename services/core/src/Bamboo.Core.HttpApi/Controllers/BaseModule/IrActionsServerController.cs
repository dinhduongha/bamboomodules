using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    [Route("api/v1/base/IrActionsServer")]
    public partial class IrActionsServerController : AbpControllerBase
    {
        private readonly IIrActionsServerAppService _appService;
        public IrActionsServerController(IIrActionsServerAppService appService) { _appService = appService; }
    }
}