using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.SpreadsheetDashboardModule
{
    [Route("api/v1/productivity/SpreadsheetDashboardShare")]
    public partial class SpreadsheetDashboardShareController : AbpControllerBase
    {
        private readonly ISpreadsheetDashboardShareAppService _appService;
        public SpreadsheetDashboardShareController(ISpreadsheetDashboardShareAppService appService) { _appService = appService; }
    }
}