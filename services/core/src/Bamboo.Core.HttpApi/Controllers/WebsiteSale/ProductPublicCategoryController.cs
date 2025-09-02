using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteSale
{
    [Route("api/v1/website/ProductPublicCategory")]
    public partial class ProductPublicCategoryController : AbpControllerBase
    {
        private readonly IProductPublicCategoryAppService _appService;
        public ProductPublicCategoryController(IProductPublicCategoryAppService appService) { _appService = appService; }
    }
}