using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
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