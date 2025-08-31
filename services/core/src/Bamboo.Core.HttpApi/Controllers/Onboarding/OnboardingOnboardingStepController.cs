using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Onboarding
{
    [Route("api/v1/onboarding/OnboardingOnboardingStep")]
    public partial class OnboardingOnboardingStepController : AbpControllerBase
    {
        private readonly IOnboardingOnboardingStepAppService _appService;
        public OnboardingOnboardingStepController(IOnboardingOnboardingStepAppService appService) { _appService = appService; }
    }
}