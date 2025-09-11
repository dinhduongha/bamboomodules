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
    // Category: Hidden/Tools, Module: base_import
    [Authorize]
    [Route("api/v1/base-import/BaseImportImport")]
    public partial class BaseImportImportController : AbpController
    {
        private readonly IBaseImportImportAppService _appService;
        public BaseImportImportController(IBaseImportImportAppService appService) { _appService = appService; }
    }
}