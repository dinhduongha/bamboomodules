using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.BaseImportModuleModule
{
    [Route("api/v1/base-import-module/BaseImportModule")]
    public partial class BaseImportModuleController : AbpControllerBase
    {
        private readonly IBaseImportModuleAppService _appService;
        public BaseImportModuleController(IBaseImportModuleAppService appService) { _appService = appService; }
    }
}