using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Marketing/Surveys, Module: survey
    [Authorize]
    [Route("api/v1/marketing/SurveyQuestion")]
    public partial class SurveyQuestionController : AbpController
    {
        private readonly ISurveyQuestionAppService _appService;
        public SurveyQuestionController(ISurveyQuestionAppService appService) { _appService = appService; }
    }
}