using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Project
{
    [Route("api/v1/services/ProjectProject")]
    public partial class ProjectProjectController : AbpController
    {
        private readonly IProjectProjectAppService _appService;
        public ProjectProjectController(IProjectProjectAppService appService) { _appService = appService; }
    }
}