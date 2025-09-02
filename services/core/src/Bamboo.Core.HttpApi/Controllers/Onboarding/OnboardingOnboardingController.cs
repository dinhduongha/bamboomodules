using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Onboarding
{
    [Route("api/v1/onboarding/OnboardingOnboarding")]
    public partial class OnboardingOnboardingController : AbpControllerBase
    {
        private readonly IOnboardingOnboardingAppService _appService;
        public OnboardingOnboardingController(IOnboardingOnboardingAppService appService) { _appService = appService; }
    }
}