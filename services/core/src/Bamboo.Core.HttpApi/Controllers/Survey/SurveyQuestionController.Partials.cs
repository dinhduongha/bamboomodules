using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Survey
{
    public partial class SurveyQuestionController
    {
        
        [HttpPost]
        [Route("{id}/validate-question")]
        public async Task<IActionResult> ValidateQuestionAsync(Guid id, [FromBody] SurveyQuestionValidateQuestionRequestDto input)
        {
            var result = await _appService.ValidateQuestionAsync(id, input.Answer, input.Comment);
            return Ok(result);
        }
    }
}