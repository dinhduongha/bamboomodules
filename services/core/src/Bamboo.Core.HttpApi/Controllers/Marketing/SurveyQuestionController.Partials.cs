using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
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