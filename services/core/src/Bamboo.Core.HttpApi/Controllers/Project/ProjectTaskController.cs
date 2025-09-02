using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Project
{
    [Route("api/v1/services/ProjectTask")]
    public partial class ProjectTaskController : AbpControllerBase
    {
        private readonly IProjectTaskAppService _appService;
        public ProjectTaskController(IProjectTaskAppService appService) { _appService = appService; }
    }
}