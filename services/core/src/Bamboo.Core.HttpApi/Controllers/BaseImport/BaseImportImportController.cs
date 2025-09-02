using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.BaseImport
{
    [Route("api/v1/base-import/BaseImportImport")]
    public partial class BaseImportImportController : AbpControllerBase
    {
        private readonly IBaseImportImportAppService _appService;
        public BaseImportImportController(IBaseImportImportAppService appService) { _appService = appService; }
    }
}