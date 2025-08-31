using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Project
{
    [Route("api/v1/services/ProjectProject")]
    public partial class ProjectProjectController : AbpControllerBase
    {
        private readonly IProjectProjectAppService _appService;
        public ProjectProjectController(IProjectProjectAppService appService) { _appService = appService; }
    }
}