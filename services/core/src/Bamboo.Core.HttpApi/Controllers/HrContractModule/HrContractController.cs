using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.HrContractModule
{
    [Route("api/v1/human-resources/HrContract")]
    public partial class HrContractController : AbpControllerBase
    {
        private readonly IHrContractAppService _appService;
        public HrContractController(IHrContractAppService appService) { _appService = appService; }
    }
}