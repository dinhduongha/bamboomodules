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
    // Category: Sales/CRM, Module: crm
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/sales/CrmLead")]
    public partial class CrmLeadController : AbpController
    {
        private readonly ICrmLeadAppService _appService;
        public CrmLeadController(ICrmLeadAppService appService) { _appService = appService; }
    }
}