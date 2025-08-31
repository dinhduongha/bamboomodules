using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.SpreadsheetDashboardModule
{
    [Route("api/v1/productivity/SpreadsheetDashboard")]
    public partial class SpreadsheetDashboardController : AbpControllerBase
    {
        private readonly ISpreadsheetDashboardAppService _appService;
        public SpreadsheetDashboardController(ISpreadsheetDashboardAppService appService) { _appService = appService; }
    }
}