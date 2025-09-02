using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Sale
{
    [Route("api/v1/sales/SaleOrder")]
    public partial class SaleOrderController : AbpControllerBase
    {
        private readonly ISaleOrderAppService _appService;
        public SaleOrderController(ISaleOrderAppService appService) { _appService = appService; }
    }
}