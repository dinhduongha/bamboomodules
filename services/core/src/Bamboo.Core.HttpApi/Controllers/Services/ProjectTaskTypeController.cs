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
    [Route("api/v1/services/ProjectTaskType")]
    public partial class ProjectTaskTypeController : AbpController
    {
        private readonly IProjectTaskTypeAppService _appService;
        public ProjectTaskTypeController(IProjectTaskTypeAppService appService) { _appService = appService; }
    }
}