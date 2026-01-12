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
    [Route("api/v1/marketing/SurveyQuestion")]
    public partial class SurveyQuestionController : AbpController
    {
        private readonly ISurveyQuestionAppService _appService;
        public SurveyQuestionController(ISurveyQuestionAppService appService) { _appService = appService; }
    }
}