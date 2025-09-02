using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Loyalty
{
    [Route("api/v1/sales/LoyaltyCard")]
    public partial class LoyaltyCardController : AbpControllerBase
    {
        private readonly ILoyaltyCardAppService _appService;
        public LoyaltyCardController(ILoyaltyCardAppService appService) { _appService = appService; }
    }
}