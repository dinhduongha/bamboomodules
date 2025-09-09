using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Project
{
    [Route("api/v1/services/ProjectTags")]
    public partial class ProjectTagsController : AbpController
    {
        private readonly IProjectTagsAppService _appService;
        public ProjectTagsController(IProjectTagsAppService appService) { _appService = appService; }
    }
}