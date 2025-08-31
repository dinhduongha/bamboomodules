using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.SalesTeam
{
    [Route("api/v1/sales/CrmTeam")]
    public partial class CrmTeamController : AbpControllerBase
    {
        private readonly ICrmTeamAppService _appService;
        public CrmTeamController(ICrmTeamAppService appService) { _appService = appService; }
    }
}