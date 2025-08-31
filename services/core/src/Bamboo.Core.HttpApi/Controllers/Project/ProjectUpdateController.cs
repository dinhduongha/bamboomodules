using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Project
{
    [Route("api/v1/services/ProjectUpdate")]
    public partial class ProjectUpdateController : AbpControllerBase
    {
        private readonly IProjectUpdateAppService _appService;
        public ProjectUpdateController(IProjectUpdateAppService appService) { _appService = appService; }
    }
}