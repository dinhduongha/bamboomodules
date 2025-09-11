using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class AccountEdiDocumentController
    {
        
        [HttpPost]
        [Route("{id}/action-export-xml")]
        public async Task<IActionResult> ActionExportXmlAsync(Guid id)
        {
            var result = await _appService.ExportXmlAsync(id);
            return Ok(result);
        }
    }
}