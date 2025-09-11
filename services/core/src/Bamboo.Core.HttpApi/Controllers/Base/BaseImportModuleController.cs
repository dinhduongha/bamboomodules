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
    // Category: Hidden/Tools, Module: base_import_module
    [Authorize]
    [Route("api/v1/base-import-module/BaseImportModule")]
    public partial class BaseImportModuleController : AbpController
    {
        private readonly IBaseImportModuleAppService _appService;
        public BaseImportModuleController(IBaseImportModuleAppService appService) { _appService = appService; }
    }
}