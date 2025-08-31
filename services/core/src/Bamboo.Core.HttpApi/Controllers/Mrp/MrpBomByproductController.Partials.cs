using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Mrp
{
    public partial class MrpBomByproductController
    {
        
        [HttpPost]
        [Route("{id}/action-add-from-catalog")]
        public async Task<IActionResult> ActionAddFromCatalogAsync(Guid id)
        {
            var result = await _appService.AddFromCatalogAsync(id);
            return Ok(result);
        }
    }
}