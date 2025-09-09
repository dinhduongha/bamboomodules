using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Project
{
    [Route("api/v1/services/ProjectMilestone")]
    public partial class ProjectMilestoneController : AbpController
    {
        private readonly IProjectMilestoneAppService _appService;
        public ProjectMilestoneController(IProjectMilestoneAppService appService) { _appService = appService; }
    }
}