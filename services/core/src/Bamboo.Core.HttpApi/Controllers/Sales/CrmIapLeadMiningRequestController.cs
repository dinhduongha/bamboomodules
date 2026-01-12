using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Sales/CRM, Module: crm_iap_mine
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/sales/CrmIapLeadMiningRequest")]
    public partial class CrmIapLeadMiningRequestController : AbpController
    {
        private readonly ICrmIapLeadMiningRequestAppService _appService;
        public CrmIapLeadMiningRequestController(ICrmIapLeadMiningRequestAppService appService) { _appService = appService; }
    }
}