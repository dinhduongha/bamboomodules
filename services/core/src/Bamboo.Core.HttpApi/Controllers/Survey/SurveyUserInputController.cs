using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Survey
{
    [Route("api/v1/marketing/SurveyUserInput")]
    public partial class SurveyUserInputController : AbpControllerBase
    {
        private readonly ISurveyUserInputAppService _appService;
        public SurveyUserInputController(ISurveyUserInputAppService appService) { _appService = appService; }
    }
}