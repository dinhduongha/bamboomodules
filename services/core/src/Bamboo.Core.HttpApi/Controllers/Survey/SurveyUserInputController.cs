using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Survey
{
    [Route("api/v1/marketing/SurveyUserInput")]
    public partial class SurveyUserInputController : AbpControllerBase
    {
        private readonly ISurveyUserInputAppService _appService;
        public SurveyUserInputController(ISurveyUserInputAppService appService) { _appService = appService; }
    }
}