using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Human Resources/Expenses, Module: hr_expense
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/human-resources/HrExpenseSheet")]
    public partial class HrExpenseSheetController : AbpController
    {
        private readonly IHrExpenseSheetAppService _appService;
        public HrExpenseSheetController(IHrExpenseSheetAppService appService) { _appService = appService; }
    }
}