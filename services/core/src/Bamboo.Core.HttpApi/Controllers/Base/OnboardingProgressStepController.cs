using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Onboarding
{
    [Route("api/v1/onboarding/OnboardingProgressStep")]
    public partial class OnboardingProgressStepController : AbpController
    {
        private readonly IOnboardingProgressStepAppService _appService;
        public OnboardingProgressStepController(IOnboardingProgressStepAppService appService) { _appService = appService; }
    }
}