using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Sales/Point of Sale, Module: pos_restaurant
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/sales/RestaurantFloor")]
    public partial class RestaurantFloorController : AbpController
    {
        private readonly IRestaurantFloorAppService _appService;
        public RestaurantFloorController(IRestaurantFloorAppService appService) { _appService = appService; }
    }
}