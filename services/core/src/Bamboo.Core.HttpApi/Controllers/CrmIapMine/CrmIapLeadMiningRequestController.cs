using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.CrmIapMine
{
    [Route("api/v1/sales/CrmIapLeadMiningRequest")]
    public partial class CrmIapLeadMiningRequestController : AbpControllerBase
    {
        private readonly ICrmIapLeadMiningRequestAppService _appService;
        public CrmIapLeadMiningRequestController(ICrmIapLeadMiningRequestAppService appService) { _appService = appService; }
    }
}