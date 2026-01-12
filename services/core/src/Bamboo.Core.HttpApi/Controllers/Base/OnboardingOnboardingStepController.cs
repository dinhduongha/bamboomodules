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
    [Route("api/v1/onboarding/OnboardingOnboardingStep")]
    public partial class OnboardingOnboardingStepController : AbpController
    {
        private readonly IOnboardingOnboardingStepAppService _appService;
        public OnboardingOnboardingStepController(IOnboardingOnboardingStepAppService appService) { _appService = appService; }
    }
}