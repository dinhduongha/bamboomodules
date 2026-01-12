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
    // Category: Hidden, Module: base
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/base/ResUsersApikeysDescription")]
    public partial class ResUsersApikeysDescriptionController : AbpController
    {
        private readonly IResUsersApikeysDescriptionAppService _appService;
        public ResUsersApikeysDescriptionController(IResUsersApikeysDescriptionAppService appService) { _appService = appService; }
    }
}