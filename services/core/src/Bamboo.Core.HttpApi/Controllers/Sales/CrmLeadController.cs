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
    // Category: Sales/CRM, Module: crm
    [Authorize]
    [Route("api/v1/sales/CrmLead")]
    public partial class CrmLeadController : AbpController
    {
        private readonly ICrmLeadAppService _appService;
        public CrmLeadController(ICrmLeadAppService appService) { _appService = appService; }
    }
}