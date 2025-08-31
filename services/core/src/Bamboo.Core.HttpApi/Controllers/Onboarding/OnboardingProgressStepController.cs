using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Onboarding
{
    [Route("api/v1/onboarding/OnboardingProgressStep")]
    public partial class OnboardingProgressStepController : AbpControllerBase
    {
        private readonly IOnboardingProgressStepAppService _appService;
        public OnboardingProgressStepController(IOnboardingProgressStepAppService appService) { _appService = appService; }
    }
}