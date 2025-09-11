using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Sales/Sales, Module: uom
    [Authorize]
    [Route("api/v1/sales/UomUom")]
    public partial class UomUomController : AbpController
    {
        private readonly IUomUomAppService _appService;
        public UomUomController(IUomUomAppService appService) { _appService = appService; }
    }
}