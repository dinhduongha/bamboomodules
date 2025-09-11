using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Hidden, Module: resource
    [Authorize]
    [Route("api/v1/resource/ResourceResource")]
    public partial class ResourceResourceController : AbpController
    {
        private readonly IResourceResourceAppService _appService;
        public ResourceResourceController(IResourceResourceAppService appService) { _appService = appService; }
    }
}