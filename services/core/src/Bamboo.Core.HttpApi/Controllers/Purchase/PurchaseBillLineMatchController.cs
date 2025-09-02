using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Purchase
{
    [Route("api/v1/inventory/PurchaseBillLineMatch")]
    public partial class PurchaseBillLineMatchController : AbpControllerBase
    {
        private readonly IPurchaseBillLineMatchAppService _appService;
        public PurchaseBillLineMatchController(IPurchaseBillLineMatchAppService appService) { _appService = appService; }
    }
}