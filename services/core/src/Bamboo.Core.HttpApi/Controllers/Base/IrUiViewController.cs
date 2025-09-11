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
    [Route("api/v1/base/IrUiView")]
    public partial class IrUiViewController : AbpController
    {
        private readonly IIrUiViewAppService _appService;
        public IrUiViewController(IIrUiViewAppService appService) { _appService = appService; }
    }
}