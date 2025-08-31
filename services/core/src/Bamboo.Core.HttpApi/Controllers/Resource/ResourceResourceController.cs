using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Resource
{
    [Route("api/v1/resource/ResourceResource")]
    public partial class ResourceResourceController : AbpControllerBase
    {
        private readonly IResourceResourceAppService _appService;
        public ResourceResourceController(IResourceResourceAppService appService) { _appService = appService; }
    }
}