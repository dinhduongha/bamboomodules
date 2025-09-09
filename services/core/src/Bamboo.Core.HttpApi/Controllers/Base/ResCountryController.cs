using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    [Route("api/v1/base/ResCountry")]
    public partial class ResCountryController : AbpController
    {
        private readonly IResCountryAppService _appService;
        public ResCountryController(IResCountryAppService appService) { _appService = appService; }
    }
}