using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Onboarding
{
    [Route("api/v1/onboarding/OnboardingProgress")]
    public partial class OnboardingProgressController : AbpControllerBase
    {
        private readonly IOnboardingProgressAppService _appService;
        public OnboardingProgressController(IOnboardingProgressAppService appService) { _appService = appService; }
    }
}