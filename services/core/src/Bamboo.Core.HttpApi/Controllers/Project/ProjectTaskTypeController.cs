using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Project
{
    [Route("api/v1/services/ProjectTaskType")]
    public partial class ProjectTaskTypeController : AbpControllerBase
    {
        private readonly IProjectTaskTypeAppService _appService;
        public ProjectTaskTypeController(IProjectTaskTypeAppService appService) { _appService = appService; }
    }
}