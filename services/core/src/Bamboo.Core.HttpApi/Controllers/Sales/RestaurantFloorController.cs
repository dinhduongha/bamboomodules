using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.PosRestaurant
{
    [Route("api/v1/sales/RestaurantFloor")]
    public partial class RestaurantFloorController : AbpController
    {
        private readonly IRestaurantFloorAppService _appService;
        public RestaurantFloorController(IRestaurantFloorAppService appService) { _appService = appService; }
    }
}