using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    [Route("api/v1/base/IrUiView")]
    public partial class IrUiViewController : AbpControllerBase
    {
        private readonly IIrUiViewAppService _appService;
        public IrUiViewController(IIrUiViewAppService appService) { _appService = appService; }
    }
}