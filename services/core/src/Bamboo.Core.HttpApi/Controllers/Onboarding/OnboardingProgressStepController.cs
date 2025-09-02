using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Onboarding
{
    [Route("api/v1/onboarding/OnboardingProgressStep")]
    public partial class OnboardingProgressStepController : AbpControllerBase
    {
        private readonly IOnboardingProgressStepAppService _appService;
        public OnboardingProgressStepController(IOnboardingProgressStepAppService appService) { _appService = appService; }
    }
}