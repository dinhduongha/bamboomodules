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
    [Route("api/v1/sales/RestaurantTable")]
    public partial class RestaurantTableController : AbpController
    {
        private readonly IRestaurantTableAppService _appService;
        public RestaurantTableController(IRestaurantTableAppService appService) { _appService = appService; }
    }
}