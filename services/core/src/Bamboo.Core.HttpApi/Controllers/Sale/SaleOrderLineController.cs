using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Sale
{
    [Route("api/v1/sales/SaleOrderLine")]
    public partial class SaleOrderLineController : AbpControllerBase
    {
        private readonly ISaleOrderLineAppService _appService;
        public SaleOrderLineController(ISaleOrderLineAppService appService) { _appService = appService; }
    }
}