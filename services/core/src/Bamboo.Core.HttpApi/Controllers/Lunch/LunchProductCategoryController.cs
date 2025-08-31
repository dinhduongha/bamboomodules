using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Lunch
{
    [Route("api/v1/human-resources/LunchProductCategory")]
    public partial class LunchProductCategoryController : AbpControllerBase
    {
        private readonly ILunchProductCategoryAppService _appService;
        public LunchProductCategoryController(ILunchProductCategoryAppService appService) { _appService = appService; }
    }
}