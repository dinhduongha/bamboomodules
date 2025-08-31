using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.CrmIapMine
{
    [Route("api/v1/sales/CrmIapLeadMiningRequest")]
    public partial class CrmIapLeadMiningRequestController : AbpControllerBase
    {
        private readonly ICrmIapLeadMiningRequestAppService _appService;
        public CrmIapLeadMiningRequestController(ICrmIapLeadMiningRequestAppService appService) { _appService = appService; }
    }
}