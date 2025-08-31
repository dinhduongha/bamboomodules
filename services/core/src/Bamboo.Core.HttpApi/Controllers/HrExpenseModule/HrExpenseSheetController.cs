using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.HrExpenseModule
{
    [Route("api/v1/human-resources/HrExpenseSheet")]
    public partial class HrExpenseSheetController : AbpControllerBase
    {
        private readonly IHrExpenseSheetAppService _appService;
        public HrExpenseSheetController(IHrExpenseSheetAppService appService) { _appService = appService; }
    }
}