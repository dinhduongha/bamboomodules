using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Onboarding
{
    [Route("api/v1/onboarding/OnboardingProgress")]
    public partial class OnboardingProgressController : AbpController
    {
        private readonly IOnboardingProgressAppService _appService;
        public OnboardingProgressController(IOnboardingProgressAppService appService) { _appService = appService; }
    }
}