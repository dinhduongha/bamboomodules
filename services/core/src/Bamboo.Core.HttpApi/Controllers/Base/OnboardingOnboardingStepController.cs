using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Onboarding
{
    [Route("api/v1/onboarding/OnboardingOnboardingStep")]
    public partial class OnboardingOnboardingStepController : AbpController
    {
        private readonly IOnboardingOnboardingStepAppService _appService;
        public OnboardingOnboardingStepController(IOnboardingOnboardingStepAppService appService) { _appService = appService; }
    }
}