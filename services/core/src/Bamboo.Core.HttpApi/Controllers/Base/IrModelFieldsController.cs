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
    [Route("api/v1/base/IrModelFields")]
    public partial class IrModelFieldsController : AbpController
    {
        private readonly IIrModelFieldsAppService _appService;
        public IrModelFieldsController(IIrModelFieldsAppService appService) { _appService = appService; }
    }
}