using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.CrmIapMine
{
    [Route("api/v1/sales/CrmIapLeadMiningRequest")]
    public partial class CrmIapLeadMiningRequestController : AbpController
    {
        private readonly ICrmIapLeadMiningRequestAppService _appService;
        public CrmIapLeadMiningRequestController(ICrmIapLeadMiningRequestAppService appService) { _appService = appService; }
    }
}