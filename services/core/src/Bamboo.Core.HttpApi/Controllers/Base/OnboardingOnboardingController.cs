using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Onboarding
{
    [Route("api/v1/onboarding/OnboardingOnboarding")]
    public partial class OnboardingOnboardingController : AbpController
    {
        private readonly IOnboardingOnboardingAppService _appService;
        public OnboardingOnboardingController(IOnboardingOnboardingAppService appService) { _appService = appService; }
    }
}