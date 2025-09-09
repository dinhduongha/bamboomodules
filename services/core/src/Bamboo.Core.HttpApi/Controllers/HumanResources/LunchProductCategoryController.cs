using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Lunch
{
    [Route("api/v1/human-resources/LunchProductCategory")]
    public partial class LunchProductCategoryController : AbpController
    {
        private readonly ILunchProductCategoryAppService _appService;
        public LunchProductCategoryController(ILunchProductCategoryAppService appService) { _appService = appService; }
    }
}