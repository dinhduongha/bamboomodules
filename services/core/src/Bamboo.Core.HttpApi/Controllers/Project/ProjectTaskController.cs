using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Project
{
    [Route("api/v1/services/ProjectTask")]
    public partial class ProjectTaskController : AbpControllerBase
    {
        private readonly IProjectTaskAppService _appService;
        public ProjectTaskController(IProjectTaskAppService appService) { _appService = appService; }
    }
}