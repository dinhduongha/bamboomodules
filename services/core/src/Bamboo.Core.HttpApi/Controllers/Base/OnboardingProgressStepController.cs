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
    // Category: Hidden, Module: onboarding
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/onboarding/OnboardingProgressStep")]
    public partial class OnboardingProgressStepController : AbpController
    {
        private readonly IOnboardingProgressStepAppService _appService;
        public OnboardingProgressStepController(IOnboardingProgressStepAppService appService) { _appService = appService; }
    }
}