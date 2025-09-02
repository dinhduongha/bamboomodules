using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.SpreadsheetDashboardModule
{
    [Route("api/v1/productivity/SpreadsheetDashboard")]
    public partial class SpreadsheetDashboardController : AbpControllerBase
    {
        private readonly ISpreadsheetDashboardAppService _appService;
        public SpreadsheetDashboardController(ISpreadsheetDashboardAppService appService) { _appService = appService; }
    }
}