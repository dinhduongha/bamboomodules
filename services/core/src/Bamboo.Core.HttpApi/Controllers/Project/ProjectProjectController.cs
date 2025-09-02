using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Project
{
    [Route("api/v1/services/ProjectProject")]
    public partial class ProjectProjectController : AbpControllerBase
    {
        private readonly IProjectProjectAppService _appService;
        public ProjectProjectController(IProjectProjectAppService appService) { _appService = appService; }
    }
}