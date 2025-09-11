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
    [Route("api/v1/services/ProjectProject")]
    public partial class ProjectProjectController : AbpController
    {
        private readonly IProjectProjectAppService _appService;
        public ProjectProjectController(IProjectProjectAppService appService) { _appService = appService; }
    }
}