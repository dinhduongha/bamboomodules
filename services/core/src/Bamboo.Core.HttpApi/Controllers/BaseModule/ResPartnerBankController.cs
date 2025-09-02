using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    [Route("api/v1/base/ResPartnerBank")]
    public partial class ResPartnerBankController : AbpControllerBase
    {
        private readonly IResPartnerBankAppService _appService;
        public ResPartnerBankController(IResPartnerBankAppService appService) { _appService = appService; }
    }
}