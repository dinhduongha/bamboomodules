using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Services/Project, Module: project
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/services/ProjectMilestone")]
    public partial class ProjectMilestoneController : AbpController
    {
        private readonly IProjectMilestoneAppService _appService;
        public ProjectMilestoneController(IProjectMilestoneAppService appService) { _appService = appService; }
    }
}