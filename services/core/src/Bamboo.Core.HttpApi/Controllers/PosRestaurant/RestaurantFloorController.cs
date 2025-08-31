using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.PosRestaurant
{
    [Route("api/v1/sales/RestaurantFloor")]
    public partial class RestaurantFloorController : AbpControllerBase
    {
        private readonly IRestaurantFloorAppService _appService;
        public RestaurantFloorController(IRestaurantFloorAppService appService) { _appService = appService; }
    }
}