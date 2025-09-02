using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Project
{
    [Route("api/v1/services/ProjectTags")]
    public partial class ProjectTagsController : AbpControllerBase
    {
        private readonly IProjectTagsAppService _appService;
        public ProjectTagsController(IProjectTagsAppService appService) { _appService = appService; }
    }
}