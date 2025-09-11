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
    // Category: Services/Project, Module: project
    [Authorize]
    [Route("api/v1/services/ProjectTaskType")]
    public partial class ProjectTaskTypeController : AbpController
    {
        private readonly IProjectTaskTypeAppService _appService;
        public ProjectTaskTypeController(IProjectTaskTypeAppService appService) { _appService = appService; }
    }
}