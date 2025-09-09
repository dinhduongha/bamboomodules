using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    [Route("api/v1/base/IrUiMenu")]
    public partial class IrUiMenuController : AbpController
    {
        private readonly IIrUiMenuAppService _appService;
        public IrUiMenuController(IIrUiMenuAppService appService) { _appService = appService; }
    }
}