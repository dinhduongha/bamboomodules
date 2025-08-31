using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Purchase
{
    [Route("api/v1/inventory/PurchaseBillLineMatch")]
    public partial class PurchaseBillLineMatchController : AbpControllerBase
    {
        private readonly IPurchaseBillLineMatchAppService _appService;
        public PurchaseBillLineMatchController(IPurchaseBillLineMatchAppService appService) { _appService = appService; }
    }
}