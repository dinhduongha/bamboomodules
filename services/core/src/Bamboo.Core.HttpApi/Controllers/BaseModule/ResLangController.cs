using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    [Route("api/v1/base/ResLang")]
    public partial class ResLangController : AbpControllerBase
    {
        private readonly IResLangAppService _appService;
        public ResLangController(IResLangAppService appService) { _appService = appService; }
    }
}