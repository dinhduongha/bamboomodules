using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    [Route("api/v1/base/ResPartner")]
    public partial class ResPartnerController : AbpControllerBase
    {
        private readonly IResPartnerAppService _appService;
        public ResPartnerController(IResPartnerAppService appService) { _appService = appService; }
    }
}