using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.PointOfSale
{
    [Route("api/v1/sales/PosSession")]
    public partial class PosSessionController : AbpController
    {
        private readonly IPosSessionAppService _appService;
        public PosSessionController(IPosSessionAppService appService) { _appService = appService; }
    }
}