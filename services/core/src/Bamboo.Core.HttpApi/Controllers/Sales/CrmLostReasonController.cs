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
    [Route("api/v1/sales/CrmLostReason")]
    public partial class CrmLostReasonController : AbpController
    {
        private readonly ICrmLostReasonAppService _appService;
        public CrmLostReasonController(ICrmLostReasonAppService appService) { _appService = appService; }
    }
}