using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Hidden, Module: resource
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/resource/ResourceResource")]
    public partial class ResourceResourceController : AbpController
    {
        private readonly IResourceResourceAppService _appService;
        public ResourceResourceController(IResourceResourceAppService appService) { _appService = appService; }
    }
}