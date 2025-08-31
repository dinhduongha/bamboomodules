using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    [Route("api/v1/base/IrModelConstraint")]
    public partial class IrModelConstraintController : AbpControllerBase
    {
        private readonly IIrModelConstraintAppService _appService;
        public IrModelConstraintController(IIrModelConstraintAppService appService) { _appService = appService; }
    }
}