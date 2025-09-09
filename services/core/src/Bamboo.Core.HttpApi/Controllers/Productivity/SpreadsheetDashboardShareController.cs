using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.SpreadsheetDashboardModule
{
    [Route("api/v1/productivity/SpreadsheetDashboardShare")]
    public partial class SpreadsheetDashboardShareController : AbpController
    {
        private readonly ISpreadsheetDashboardShareAppService _appService;
        public SpreadsheetDashboardShareController(ISpreadsheetDashboardShareAppService appService) { _appService = appService; }
    }
}