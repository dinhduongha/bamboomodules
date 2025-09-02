using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.PosRestaurant
{
    [Route("api/v1/sales/RestaurantTable")]
    public partial class RestaurantTableController : AbpControllerBase
    {
        private readonly IRestaurantTableAppService _appService;
        public RestaurantTableController(IRestaurantTableAppService appService) { _appService = appService; }
    }
}