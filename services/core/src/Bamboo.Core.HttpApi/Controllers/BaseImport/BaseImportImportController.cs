using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.BaseImport
{
    [Route("api/v1/base-import/BaseImportImport")]
    public partial class BaseImportImportController : AbpControllerBase
    {
        private readonly IBaseImportImportAppService _appService;
        public BaseImportImportController(IBaseImportImportAppService appService) { _appService = appService; }
    }
}