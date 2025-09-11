using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Sales/CRM, Module: crm_iap_mine
    [Authorize]
    [Route("api/v1/sales/CrmIapLeadHelpers")]
    public partial class CrmIapLeadHelpersController : AbpController
    {
        private readonly ICrmIapLeadHelpersAppService _appService;
        public CrmIapLeadHelpersController(ICrmIapLeadHelpersAppService appService) { _appService = appService; }
    }
}