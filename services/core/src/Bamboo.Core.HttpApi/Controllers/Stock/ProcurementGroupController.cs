using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Stock
{
    [Route("api/v1/inventory/ProcurementGroup")]
    public partial class ProcurementGroupController : AbpControllerBase
    {
        private readonly IProcurementGroupAppService _appService;
        public ProcurementGroupController(IProcurementGroupAppService appService) { _appService = appService; }
    }
}