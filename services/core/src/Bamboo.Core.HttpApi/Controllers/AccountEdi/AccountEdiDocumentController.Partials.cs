using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
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