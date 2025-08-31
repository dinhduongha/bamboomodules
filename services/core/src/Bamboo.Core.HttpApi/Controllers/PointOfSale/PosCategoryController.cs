using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.PointOfSale
{
    [Route("api/v1/sales/PosCategory")]
    public partial class PosCategoryController : AbpControllerBase
    {
        private readonly IPosCategoryAppService _appService;
        public PosCategoryController(IPosCategoryAppService appService) { _appService = appService; }
    }
}