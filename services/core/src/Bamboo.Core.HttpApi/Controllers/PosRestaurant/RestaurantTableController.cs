using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.PosRestaurant
{
    [Route("api/v1/sales/RestaurantTable")]
    public partial class RestaurantTableController : AbpControllerBase
    {
        private readonly IRestaurantTableAppService _appService;
        public RestaurantTableController(IRestaurantTableAppService appService) { _appService = appService; }
    }
}