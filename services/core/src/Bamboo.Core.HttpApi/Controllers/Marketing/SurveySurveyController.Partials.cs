using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class SurveySurveyController
    {
        
        [HttpPost]
        [Route("action-archive")]
        public async Task<IActionResult> ActionArchiveAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ArchiveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-end-session")]
        public async Task<IActionResult> ActionEndSessionAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.EndSessionAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-load-sample-custom")]
        public async Task<IActionResult> ActionLoadSampleCustomAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.LoadSampleCustomAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-load-survey-template-sample")]
        public async Task<IActionResult> ActionLoadSurveyTemplateSampleAsync(SurveySurveyLoadSurveyTemplateSampleRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.LoadSurveyTemplateSampleAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-session-manager")]
        public async Task<IActionResult> ActionOpenSessionManagerAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenSessionManagerAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-print-survey")]
        public async Task<IActionResult> ActionPrintSurveyAsync(SurveySurveyPrintSurveyRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.PrintSurveyAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-result-survey")]
        public async Task<IActionResult> ActionResultSurveyAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ResultSurveyAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-send-survey")]
        public async Task<IActionResult> ActionSendSurveyAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SendSurveyAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-show-sample")]
        public async Task<IActionResult> ActionShowSampleAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ShowSampleAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-start-session")]
        public async Task<IActionResult> ActionStartSessionAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.StartSessionAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-start-survey")]
        public async Task<IActionResult> ActionStartSurveyAsync(SurveySurveyStartSurveyRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.StartSurveyAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-survey-preview-certification-template")]
        public async Task<IActionResult> ActionSurveyPreviewCertificationTemplateAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SurveyPreviewCertificationTemplateAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-survey-see-leads")]
        public async Task<IActionResult> ActionSurveySeeLeadsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SurveySeeLeadsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-survey-user-input")]
        public async Task<IActionResult> ActionSurveyUserInputAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SurveyUserInputAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-survey-user-input-certified")]
        public async Task<IActionResult> ActionSurveyUserInputCertifiedAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SurveyUserInputCertifiedAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-survey-user-input-completed")]
        public async Task<IActionResult> ActionSurveyUserInputCompletedAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SurveyUserInputCompletedAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-survey-view-slide-channels")]
        public async Task<IActionResult> ActionSurveyViewSlideChannelsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SurveyViewSlideChannelsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-test-survey")]
        public async Task<IActionResult> ActionTestSurveyAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.TestSurveyAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-unarchive")]
        public async Task<IActionResult> ActionUnarchiveAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.UnarchiveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-validity")]
        public async Task<IActionResult> CheckValidityAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CheckValidityAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync(SurveySurveyCopyDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-formview-id")]
        public async Task<IActionResult> GetFormviewIdAsync(SurveySurveyGetFormviewIdRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetFormviewIdAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-print-url")]
        public async Task<IActionResult> GetPrintUrlAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetPrintUrlAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-start-short-url")]
        public async Task<IActionResult> GetStartShortUrlAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetStartShortUrlAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-start-url")]
        public async Task<IActionResult> GetStartUrlAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetStartUrlAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-survey-templates-data")]
        public async Task<IActionResult> GetSurveyTemplatesDataAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetSurveyTemplatesDataAsync(ids);
            return Ok(result);
        }
    }
}