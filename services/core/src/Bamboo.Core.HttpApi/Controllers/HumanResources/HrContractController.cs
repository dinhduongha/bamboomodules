using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.HrContractModule
{
    [Route("api/v1/human-resources/HrContract")]
    public partial class HrContractController : AbpController
    {
        private readonly IHrContractAppService _appService;
        public HrContractController(IHrContractAppService appService) { _appService = appService; }
    }
}