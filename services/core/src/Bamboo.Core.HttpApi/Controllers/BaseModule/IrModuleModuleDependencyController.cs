using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    [Route("api/v1/base/IrModuleModuleDependency")]
    public partial class IrModuleModuleDependencyController : AbpControllerBase
    {
        private readonly IIrModuleModuleDependencyAppService _appService;
        public IrModuleModuleDependencyController(IIrModuleModuleDependencyAppService appService) { _appService = appService; }
    }
}