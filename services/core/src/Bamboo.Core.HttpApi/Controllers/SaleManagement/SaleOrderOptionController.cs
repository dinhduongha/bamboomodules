using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.SaleManagement
{
    [Route("api/v1/sales/SaleOrderOption")]
    public partial class SaleOrderOptionController : AbpControllerBase
    {
        private readonly ISaleOrderOptionAppService _appService;
        public SaleOrderOptionController(ISaleOrderOptionAppService appService) { _appService = appService; }
    }
}