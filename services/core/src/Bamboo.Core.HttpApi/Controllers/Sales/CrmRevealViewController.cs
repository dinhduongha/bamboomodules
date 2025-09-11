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
    // Category: Sales/CRM, Module: website_crm_iap_reveal
    [Authorize]
    [Route("api/v1/sales/CrmRevealView")]
    public partial class CrmRevealViewController : AbpController
    {
        private readonly ICrmRevealViewAppService _appService;
        public CrmRevealViewController(ICrmRevealViewAppService appService) { _appService = appService; }
    }
}