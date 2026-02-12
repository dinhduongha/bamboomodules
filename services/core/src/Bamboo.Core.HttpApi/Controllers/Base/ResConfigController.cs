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
    [Route("api/v1/base/ResConfig")]
    public partial class ResConfigController : AbpController
    {
        protected readonly IResConfigAppService _appService;
        public ResConfigController(IResConfigAppService appService) { _appService = appService; }


        [HttpPost]
        [Route("action-cancel")]
        public async Task<IActionResult> CancelAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CancelAsync(ids);
            return Ok(result);
        }

        [HttpPost]
        [Route("action-next")]
        public async Task<IActionResult> NextAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.NextAsync(ids);
            return Ok(result);
        }

        [HttpPost]
        [Route("action-skip")]
        public async Task<IActionResult> SkipAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SkipAsync(ids);
            return Ok(result);
        }

        [HttpPost]
        [Route("cancel")]
        public async Task<IActionResult> CancelActionAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CancelActionAsync(ids);
            return Ok(result);
        }

        [HttpPost]
        [Route("execute")]
        public async Task<IActionResult> ExecuteAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ExecuteAsync(ids);
            return Ok(result);
        }

        [HttpPost]
        [Route("next")]
        public async Task<IActionResult> NextActionAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.NextActionAsync(ids);
            return Ok(result);
        }

        [HttpPost]
        [Route("start")]
        public async Task<IActionResult> StartAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.StartAsync(ids);
            return Ok(result);
        }
    }

}