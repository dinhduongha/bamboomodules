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
    // Category: Inventory/Purchase, Module: purchase
    [Authorize]
    [Route("api/v1/inventory/PurchaseBillLineMatch")]
    public partial class PurchaseBillLineMatchController : AbpController
    {
        private readonly IPurchaseBillLineMatchAppService _appService;
        public PurchaseBillLineMatchController(IPurchaseBillLineMatchAppService appService) { _appService = appService; }
    }
}