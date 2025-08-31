using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.SpreadsheetDashboardModule
{
    [Route("api/v1/productivity/SpreadsheetDashboardShare")]
    public partial class SpreadsheetDashboardShareController : AbpControllerBase
    {
        private readonly ISpreadsheetDashboardShareAppService _appService;
        public SpreadsheetDashboardShareController(ISpreadsheetDashboardShareAppService appService) { _appService = appService; }
    }
}