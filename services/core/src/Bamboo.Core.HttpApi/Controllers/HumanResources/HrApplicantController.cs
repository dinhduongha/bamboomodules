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
    // Category: Human Resources/Recruitment, Module: hr_recruitment
    [Authorize]
    [Route("api/v1/human-resources/HrApplicant")]
    public partial class HrApplicantController : AbpController
    {
        private readonly IHrApplicantAppService _appService;
        public HrApplicantController(IHrApplicantAppService appService) { _appService = appService; }
    }
}