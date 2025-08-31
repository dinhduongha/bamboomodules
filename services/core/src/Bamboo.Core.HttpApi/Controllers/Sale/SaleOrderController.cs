using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Sale
{
    [Route("api/v1/sales/SaleOrder")]
    public partial class SaleOrderController : AbpControllerBase
    {
        private readonly ISaleOrderAppService _appService;
        public SaleOrderController(ISaleOrderAppService appService) { _appService = appService; }
    }
}