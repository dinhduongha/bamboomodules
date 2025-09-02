using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Resource
{
    [Route("api/v1/resource/ResourceResource")]
    public partial class ResourceResourceController : AbpControllerBase
    {
        private readonly IResourceResourceAppService _appService;
        public ResourceResourceController(IResourceResourceAppService appService) { _appService = appService; }
    }
}