using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.AccountEdi
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