using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Uom
{
    [Route("api/v1/sales/UomUom")]
    public partial class UomUomController : AbpControllerBase
    {
        private readonly IUomUomAppService _appService;
        public UomUomController(IUomUomAppService appService) { _appService = appService; }
    }
}