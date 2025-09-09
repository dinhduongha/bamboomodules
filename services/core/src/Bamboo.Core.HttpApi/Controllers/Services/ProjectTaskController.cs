using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Project
{
    [Route("api/v1/services/ProjectTask")]
    public partial class ProjectTaskController : AbpController
    {
        private readonly IProjectTaskAppService _appService;
        public ProjectTaskController(IProjectTaskAppService appService) { _appService = appService; }
    }
}