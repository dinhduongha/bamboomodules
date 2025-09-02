using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Project
{
    [Route("api/v1/services/ProjectMilestone")]
    public partial class ProjectMilestoneController : AbpControllerBase
    {
        private readonly IProjectMilestoneAppService _appService;
        public ProjectMilestoneController(IProjectMilestoneAppService appService) { _appService = appService; }
    }
}