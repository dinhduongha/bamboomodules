using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Hidden/Tools, Module: base_import
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/base-import/BaseImportImport")]
    public partial class BaseImportImportController : AbpController
    {
        private readonly IBaseImportImportAppService _appService;
        public BaseImportImportController(IBaseImportImportAppService appService) { _appService = appService; }
    }
}