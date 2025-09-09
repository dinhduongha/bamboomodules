using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.PointOfSale
{
    [Route("api/v1/sales/PosPaymentMethod")]
    public partial class PosPaymentMethodController : AbpController
    {
        private readonly IPosPaymentMethodAppService _appService;
        public PosPaymentMethodController(IPosPaymentMethodAppService appService) { _appService = appService; }
    }
}