using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.BaseImportModuleModule
{
    [Route("api/v1/base-import-module/BaseImportModule")]
    public partial class BaseImportModuleController : AbpControllerBase
    {
        private readonly IBaseImportModuleAppService _appService;
        public BaseImportModuleController(IBaseImportModuleAppService appService) { _appService = appService; }
    }
}