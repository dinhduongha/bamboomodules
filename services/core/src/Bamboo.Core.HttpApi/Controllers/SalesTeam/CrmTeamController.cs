using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.SalesTeam
{
    [Route("api/v1/sales/CrmTeam")]
    public partial class CrmTeamController : AbpControllerBase
    {
        private readonly ICrmTeamAppService _appService;
        public CrmTeamController(ICrmTeamAppService appService) { _appService = appService; }
    }
}