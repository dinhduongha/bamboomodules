using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Crm
{
    [Route("api/v1/sales/CrmLead")]
    public partial class CrmLeadController : AbpControllerBase
    {
        private readonly ICrmLeadAppService _appService;
        public CrmLeadController(ICrmLeadAppService appService) { _appService = appService; }
    }
}