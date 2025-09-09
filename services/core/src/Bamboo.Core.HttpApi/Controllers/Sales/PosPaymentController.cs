using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.PointOfSale
{
    [Route("api/v1/sales/PosPayment")]
    public partial class PosPaymentController : AbpController
    {
        private readonly IPosPaymentAppService _appService;
        public PosPaymentController(IPosPaymentAppService appService) { _appService = appService; }
    }
}