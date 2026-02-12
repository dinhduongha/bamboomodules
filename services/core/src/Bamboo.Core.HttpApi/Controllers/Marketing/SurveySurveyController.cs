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
    [Route("api/v1/marketing/SurveySurvey")]
    public partial class SurveySurveyController : AbpController
    {
        protected readonly ISurveySurveyAppService _appService;
        public SurveySurveyController(ISurveySurveyAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-archive")]
        public async Task<IActionResult> ArchiveAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ArchiveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-end-session")]
        public async Task<IActionResult> EndSessionAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.EndSessionAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-load-sample-custom")]
        public async Task<IActionResult> LoadSampleCustomAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.LoadSampleCustomAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-load-survey-template-sample")]
        public async Task<IActionResult> LoadSurveyTemplateSampleAsync([FromBody] SurveySurveyLoadSurveyTemplateSampleRequestDto input)
        {
            var result = await _appService.LoadSurveyTemplateSampleAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-session-manager")]
        public async Task<IActionResult> OpenSessionManagerAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenSessionManagerAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-print-survey")]
        public async Task<IActionResult> PrintSurveyAsync([FromBody] SurveySurveyPrintSurveyRequestDto input)
        {
            var result = await _appService.PrintSurveyAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-result-survey")]
        public async Task<IActionResult> ResultSurveyAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ResultSurveyAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-send-survey")]
        public async Task<IActionResult> SendSurveyAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SendSurveyAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-show-sample")]
        public async Task<IActionResult> ShowSampleAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ShowSampleAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-start-session")]
        public async Task<IActionResult> StartSessionAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.StartSessionAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-start-survey")]
        public async Task<IActionResult> StartSurveyAsync([FromBody] SurveySurveyStartSurveyRequestDto input)
        {
            var result = await _appService.StartSurveyAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-survey-preview-certification-template")]
        public async Task<IActionResult> SurveyPreviewCertificationTemplateAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SurveyPreviewCertificationTemplateAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-survey-see-leads")]
        public async Task<IActionResult> SurveySeeLeadsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SurveySeeLeadsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-survey-user-input")]
        public async Task<IActionResult> SurveyUserInputAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SurveyUserInputAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-survey-user-input-certified")]
        public async Task<IActionResult> SurveyUserInputCertifiedAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SurveyUserInputCertifiedAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-survey-user-input-completed")]
        public async Task<IActionResult> SurveyUserInputCompletedAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SurveyUserInputCompletedAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-survey-view-slide-channels")]
        public async Task<IActionResult> SurveyViewSlideChannelsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SurveyViewSlideChannelsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-test-survey")]
        public async Task<IActionResult> TestSurveyAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.TestSurveyAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-unarchive")]
        public async Task<IActionResult> UnarchiveAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.UnarchiveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-validity")]
        public async Task<IActionResult> CheckValidityAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CheckValidityAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync([FromBody] SurveySurveyCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-formview-id")]
        public async Task<IActionResult> GetFormviewIdAsync([FromBody] SurveySurveyGetFormviewIdRequestDto input)
        {
            var result = await _appService.GetFormviewIdAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-print-url")]
        public async Task<IActionResult> GetPrintUrlAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetPrintUrlAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-start-short-url")]
        public async Task<IActionResult> GetStartShortUrlAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetStartShortUrlAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-start-url")]
        public async Task<IActionResult> GetStartUrlAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetStartUrlAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-survey-templates-data")]
        public async Task<IActionResult> GetSurveyTemplatesDataAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetSurveyTemplatesDataAsync(ids);
            return Ok(result);
        }
    }
    
}