using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Stock
{
    [Route("api/v1/inventory/ProcurementGroup")]
    public partial class ProcurementGroupController : AbpControllerBase
    {
        private readonly IProcurementGroupAppService _appService;
        public ProcurementGroupController(IProcurementGroupAppService appService) { _appService = appService; }
    }
}