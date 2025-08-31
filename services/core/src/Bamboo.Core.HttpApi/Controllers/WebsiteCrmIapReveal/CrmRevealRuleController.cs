using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteCrmIapReveal
{
    [Route("api/v1/sales/CrmRevealRule")]
    public partial class CrmRevealRuleController : AbpControllerBase
    {
        private readonly ICrmRevealRuleAppService _appService;
        public CrmRevealRuleController(ICrmRevealRuleAppService appService) { _appService = appService; }
    }
}