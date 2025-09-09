using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.CrmIapMine
{
    [Route("api/v1/sales/CrmIapLeadHelpers")]
    public partial class CrmIapLeadHelpersController : AbpController
    {
        private readonly ICrmIapLeadHelpersAppService _appService;
        public CrmIapLeadHelpersController(ICrmIapLeadHelpersAppService appService) { _appService = appService; }
    }
}