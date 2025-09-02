using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Uom
{
    [Route("api/v1/sales/UomUom")]
    public partial class UomUomController : AbpControllerBase
    {
        private readonly IUomUomAppService _appService;
        public UomUomController(IUomUomAppService appService) { _appService = appService; }
    }
}