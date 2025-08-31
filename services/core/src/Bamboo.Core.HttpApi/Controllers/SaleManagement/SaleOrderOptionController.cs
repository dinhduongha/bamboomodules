using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.SaleManagement
{
    [Route("api/v1/sales/SaleOrderOption")]
    public partial class SaleOrderOptionController : AbpControllerBase
    {
        private readonly ISaleOrderOptionAppService _appService;
        public SaleOrderOptionController(ISaleOrderOptionAppService appService) { _appService = appService; }
    }
}