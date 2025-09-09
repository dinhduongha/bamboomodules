using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Survey
{
    [Route("api/v1/marketing/SurveySurvey")]
    public partial class SurveySurveyController : AbpController
    {
        private readonly ISurveySurveyAppService _appService;
        public SurveySurveyController(ISurveySurveyAppService appService) { _appService = appService; }
    }
}