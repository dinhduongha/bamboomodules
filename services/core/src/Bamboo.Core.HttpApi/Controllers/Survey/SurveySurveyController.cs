using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Survey
{
    [Route("api/v1/marketing/SurveySurvey")]
    public partial class SurveySurveyController : AbpControllerBase
    {
        private readonly ISurveySurveyAppService _appService;
        public SurveySurveyController(ISurveySurveyAppService appService) { _appService = appService; }
    }
}