using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.PosRestaurant
{
    [Route("api/v1/sales/RestaurantFloor")]
    public partial class RestaurantFloorController : AbpControllerBase
    {
        private readonly IRestaurantFloorAppService _appService;
        public RestaurantFloorController(IRestaurantFloorAppService appService) { _appService = appService; }
    }
}