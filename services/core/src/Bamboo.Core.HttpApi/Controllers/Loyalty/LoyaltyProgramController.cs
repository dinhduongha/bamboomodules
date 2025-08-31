using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Loyalty
{
    [Route("api/v1/sales/LoyaltyProgram")]
    public partial class LoyaltyProgramController : AbpControllerBase
    {
        private readonly ILoyaltyProgramAppService _appService;
        public LoyaltyProgramController(ILoyaltyProgramAppService appService) { _appService = appService; }
    }
}