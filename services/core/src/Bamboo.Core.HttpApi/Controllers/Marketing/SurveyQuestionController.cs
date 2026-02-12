using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    [NonController]
    [Authorize]
    [Route("api/v1/marketing/SurveyQuestion")]
    public partial class SurveyQuestionController : AbpController
    {
        protected readonly ISurveyQuestionAppService _appService;
        public SurveyQuestionController(ISurveyQuestionAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("validate-question")]
        public async Task<IActionResult> ValidateQuestionAsync([FromBody] SurveyQuestionValidateQuestionRequestDto input)
        {
            var result = await _appService.ValidateQuestionAsync(input);
            return Ok(result);
        }
    }
    
}