using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.HrContractModule
{
    [Route("api/v1/human-resources/HrContract")]
    public partial class HrContractController : AbpControllerBase
    {
        private readonly IHrContractAppService _appService;
        public HrContractController(IHrContractAppService appService) { _appService = appService; }
    }
}