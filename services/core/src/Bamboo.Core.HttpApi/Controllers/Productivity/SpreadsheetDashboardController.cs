using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.SpreadsheetDashboardModule
{
    [Route("api/v1/productivity/SpreadsheetDashboard")]
    public partial class SpreadsheetDashboardController : AbpController
    {
        private readonly ISpreadsheetDashboardAppService _appService;
        public SpreadsheetDashboardController(ISpreadsheetDashboardAppService appService) { _appService = appService; }
    }
}