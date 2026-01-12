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
    [Route("api/v1/services/ProjectTags")]
    public partial class ProjectTagsController : AbpController
    {
        private readonly IProjectTagsAppService _appService;
        public ProjectTagsController(IProjectTagsAppService appService) { _appService = appService; }
    }
}