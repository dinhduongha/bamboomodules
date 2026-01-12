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
    // Category: Human Resources/Recruitment, Module: hr_recruitment
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/human-resources/HrRecruitmentSource")]
    public partial class HrRecruitmentSourceController : AbpController
    {
        private readonly IHrRecruitmentSourceAppService _appService;
        public HrRecruitmentSourceController(IHrRecruitmentSourceAppService appService) { _appService = appService; }
    }
}