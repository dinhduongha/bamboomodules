using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    [Route("api/v1/base/ResCompany")]
    public partial class ResCompanyController : AbpControllerBase
    {
        private readonly IResCompanyAppService _appService;
        public ResCompanyController(IResCompanyAppService appService) { _appService = appService; }
    }
}