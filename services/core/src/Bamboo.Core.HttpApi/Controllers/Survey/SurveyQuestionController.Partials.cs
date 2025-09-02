using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
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