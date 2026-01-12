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
    // Category: Human Resources/Employees, Module: hr
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/human-resources/HrVersion")]
    public partial class HrVersionController : AbpController
    {
        private readonly IHrVersionAppService _appService;
        public HrVersionController(IHrVersionAppService appService) { _appService = appService; }
    }
}