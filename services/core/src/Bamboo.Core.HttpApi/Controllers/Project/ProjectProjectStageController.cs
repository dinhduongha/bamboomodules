using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Project
{
    [Route("api/v1/services/ProjectProjectStage")]
    public partial class ProjectProjectStageController : AbpControllerBase
    {
        private readonly IProjectProjectStageAppService _appService;
        public ProjectProjectStageController(IProjectProjectStageAppService appService) { _appService = appService; }
    }
}