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
    // Category: Human Resources/Lunch, Module: lunch
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/human-resources/LunchSupplier")]
    public partial class LunchSupplierController : AbpController
    {
        private readonly ILunchSupplierAppService _appService;
        public LunchSupplierController(ILunchSupplierAppService appService) { _appService = appService; }
    }
}