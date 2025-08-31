using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    [Route("api/v1/base/DecimalPrecision")]
    public partial class DecimalPrecisionController : AbpControllerBase
    {
        private readonly IDecimalPrecisionAppService _appService;
        public DecimalPrecisionController(IDecimalPrecisionAppService appService) { _appService = appService; }
    }
}