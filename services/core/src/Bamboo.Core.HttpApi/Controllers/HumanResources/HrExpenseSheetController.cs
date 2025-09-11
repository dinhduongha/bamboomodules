using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Human Resources/Expenses, Module: hr_expense
    [Authorize]
    [Route("api/v1/human-resources/HrExpenseSheet")]
    public partial class HrExpenseSheetController : AbpController
    {
        private readonly IHrExpenseSheetAppService _appService;
        public HrExpenseSheetController(IHrExpenseSheetAppService appService) { _appService = appService; }
    }
}