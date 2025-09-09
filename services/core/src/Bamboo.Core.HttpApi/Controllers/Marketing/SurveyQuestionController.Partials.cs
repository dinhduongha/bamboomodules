using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.Survey
{
    public partial class SurveyQuestionController
    {
        
        [HttpPost]
        [Route("{id}/validate-question")]
        public async Task<IActionResult> ValidateQuestionAsync(Guid id, [FromBody] SurveyQuestionValidateQuestionRequestDto input)
        {
            var result = await _appService.ValidateQuestionAsync(id, input);
            return Ok(result);
        }
    }
}