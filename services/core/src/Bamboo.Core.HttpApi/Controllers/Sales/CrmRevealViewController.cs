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
    // Category: Sales/CRM, Module: website_crm_iap_reveal
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/sales/CrmRevealView")]
    public partial class CrmRevealViewController : AbpController
    {
        private readonly ICrmRevealViewAppService _appService;
        public CrmRevealViewController(ICrmRevealViewAppService appService) { _appService = appService; }
    }
}