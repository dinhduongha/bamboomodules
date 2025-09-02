using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Survey
{
    [Route("api/v1/marketing/SurveyQuestion")]
    public partial class SurveyQuestionController : AbpControllerBase
    {
        private readonly ISurveyQuestionAppService _appService;
        public SurveyQuestionController(ISurveyQuestionAppService appService) { _appService = appService; }
    }
}