using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Lunch
{
    [Route("api/v1/human-resources/LunchSupplier")]
    public partial class LunchSupplierController : AbpController
    {
        private readonly ILunchSupplierAppService _appService;
        public LunchSupplierController(ILunchSupplierAppService appService) { _appService = appService; }
    }
}