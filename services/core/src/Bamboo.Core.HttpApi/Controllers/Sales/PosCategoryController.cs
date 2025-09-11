using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Sales/Point of Sale, Module: point_of_sale
    [Authorize]
    [Route("api/v1/sales/PosCategory")]
    public partial class PosCategoryController : AbpController
    {
        private readonly IPosCategoryAppService _appService;
        public PosCategoryController(IPosCategoryAppService appService) { _appService = appService; }
    }
}