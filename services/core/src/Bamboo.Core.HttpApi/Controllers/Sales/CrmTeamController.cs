using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Sales/Sales, Module: sales_team
    [Authorize]
    [Route("api/v1/sales/CrmTeam")]
    public partial class CrmTeamController : AbpController
    {
        private readonly ICrmTeamAppService _appService;
        public CrmTeamController(ICrmTeamAppService appService) { _appService = appService; }
    }
}