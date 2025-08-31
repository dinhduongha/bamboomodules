using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Crm
{
    [Route("api/v1/sales/CrmLead")]
    public partial class CrmLeadController : AbpControllerBase
    {
        private readonly ICrmLeadAppService _appService;
        public CrmLeadController(ICrmLeadAppService appService) { _appService = appService; }
    }
}