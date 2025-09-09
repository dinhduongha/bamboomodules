using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Project
{
    [Route("api/v1/services/ProjectTaskType")]
    public partial class ProjectTaskTypeController : AbpController
    {
        private readonly IProjectTaskTypeAppService _appService;
        public ProjectTaskTypeController(IProjectTaskTypeAppService appService) { _appService = appService; }
    }
}