using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.PointOfSale
{
    [Route("api/v1/sales/PosCategory")]
    public partial class PosCategoryController : AbpController
    {
        private readonly IPosCategoryAppService _appService;
        public PosCategoryController(IPosCategoryAppService appService) { _appService = appService; }
    }
}