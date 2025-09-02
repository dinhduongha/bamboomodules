using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Lunch
{
    [Route("api/v1/human-resources/LunchProductCategory")]
    public partial class LunchProductCategoryController : AbpControllerBase
    {
        private readonly ILunchProductCategoryAppService _appService;
        public LunchProductCategoryController(ILunchProductCategoryAppService appService) { _appService = appService; }
    }
}