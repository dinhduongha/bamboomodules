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
    // Category: Human Resources/Employees, Module: hr_skills
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/human-resources/HrResumeLine")]
    public partial class HrResumeLineController : AbpController
    {
        private readonly IHrResumeLineAppService _appService;
        public HrResumeLineController(IHrResumeLineAppService appService) { _appService = appService; }
    }
}