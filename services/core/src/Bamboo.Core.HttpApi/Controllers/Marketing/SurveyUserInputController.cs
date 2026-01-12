using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Marketing/Surveys, Module: survey
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/marketing/SurveyUserInput")]
    public partial class SurveyUserInputController : AbpController
    {
        private readonly ISurveyUserInputAppService _appService;
        public SurveyUserInputController(ISurveyUserInputAppService appService) { _appService = appService; }
    }
}