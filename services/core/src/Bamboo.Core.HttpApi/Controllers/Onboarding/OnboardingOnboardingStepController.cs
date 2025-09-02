using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Onboarding
{
    [Route("api/v1/onboarding/OnboardingOnboardingStep")]
    public partial class OnboardingOnboardingStepController : AbpControllerBase
    {
        private readonly IOnboardingOnboardingStepAppService _appService;
        public OnboardingOnboardingStepController(IOnboardingOnboardingStepAppService appService) { _appService = appService; }
    }
}