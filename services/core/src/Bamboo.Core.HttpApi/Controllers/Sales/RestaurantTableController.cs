using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.PosRestaurant
{
    [Route("api/v1/sales/RestaurantTable")]
    public partial class RestaurantTableController : AbpController
    {
        private readonly IRestaurantTableAppService _appService;
        public RestaurantTableController(IRestaurantTableAppService appService) { _appService = appService; }
    }
}