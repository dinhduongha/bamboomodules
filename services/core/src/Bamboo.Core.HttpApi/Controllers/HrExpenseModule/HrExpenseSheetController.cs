using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.HrExpenseModule
{
    [Route("api/v1/human-resources/HrExpenseSheet")]
    public partial class HrExpenseSheetController : AbpControllerBase
    {
        private readonly IHrExpenseSheetAppService _appService;
        public HrExpenseSheetController(IHrExpenseSheetAppService appService) { _appService = appService; }
    }
}