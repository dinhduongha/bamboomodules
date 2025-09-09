using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Project
{
    [Route("api/v1/services/ProjectProjectStage")]
    public partial class ProjectProjectStageController : AbpController
    {
        private readonly IProjectProjectStageAppService _appService;
        public ProjectProjectStageController(IProjectProjectStageAppService appService) { _appService = appService; }
    }
}