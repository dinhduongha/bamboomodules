using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Loyalty
{
    [Route("api/v1/sales/LoyaltyProgram")]
    public partial class LoyaltyProgramController : AbpControllerBase
    {
        private readonly ILoyaltyProgramAppService _appService;
        public LoyaltyProgramController(ILoyaltyProgramAppService appService) { _appService = appService; }
    }
}