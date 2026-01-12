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
    // Category: Productivity/Dashboard, Module: spreadsheet_dashboard
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/productivity/SpreadsheetDashboard")]
    public partial class SpreadsheetDashboardController : AbpController
    {
        private readonly ISpreadsheetDashboardAppService _appService;
        public SpreadsheetDashboardController(ISpreadsheetDashboardAppService appService) { _appService = appService; }
    }
}