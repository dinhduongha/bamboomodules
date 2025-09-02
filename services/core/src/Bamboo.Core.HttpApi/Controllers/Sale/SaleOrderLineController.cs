using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Sale
{
    [Route("api/v1/sales/SaleOrderLine")]
    public partial class SaleOrderLineController : AbpControllerBase
    {
        private readonly ISaleOrderLineAppService _appService;
        public SaleOrderLineController(ISaleOrderLineAppService appService) { _appService = appService; }
    }
}