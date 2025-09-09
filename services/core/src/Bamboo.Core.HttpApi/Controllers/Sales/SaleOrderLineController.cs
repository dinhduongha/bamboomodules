using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Sale
{
    [Route("api/v1/sales/SaleOrderLine")]
    public partial class SaleOrderLineController : AbpController
    {
        private readonly ISaleOrderLineAppService _appService;
        public SaleOrderLineController(ISaleOrderLineAppService appService) { _appService = appService; }
    }
}