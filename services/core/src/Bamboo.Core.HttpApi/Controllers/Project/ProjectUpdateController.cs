using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Project
{
    [Route("api/v1/services/ProjectUpdate")]
    public partial class ProjectUpdateController : AbpControllerBase
    {
        private readonly IProjectUpdateAppService _appService;
        public ProjectUpdateController(IProjectUpdateAppService appService) { _appService = appService; }
    }
}