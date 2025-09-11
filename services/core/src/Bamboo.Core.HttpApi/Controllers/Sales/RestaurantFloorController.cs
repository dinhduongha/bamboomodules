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
    // Category: Sales/Point of Sale, Module: pos_restaurant
    [Authorize]
    [Route("api/v1/sales/RestaurantFloor")]
    public partial class RestaurantFloorController : AbpController
    {
        private readonly IRestaurantFloorAppService _appService;
        public RestaurantFloorController(IRestaurantFloorAppService appService) { _appService = appService; }
    }
}