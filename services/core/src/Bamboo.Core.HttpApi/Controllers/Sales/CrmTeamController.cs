using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.SalesTeam
{
    [Route("api/v1/sales/CrmTeam")]
    public partial class CrmTeamController : AbpController
    {
        private readonly ICrmTeamAppService _appService;
        public CrmTeamController(ICrmTeamAppService appService) { _appService = appService; }
    }
}