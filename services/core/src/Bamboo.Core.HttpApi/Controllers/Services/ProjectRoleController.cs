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
    [Route("api/v1/services/ProjectRole")]
    public partial class ProjectRoleController : AbpController
    {
        private readonly IProjectRoleAppService _appService;
        public ProjectRoleController(IProjectRoleAppService appService) { _appService = appService; }
    }
}