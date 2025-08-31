using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteSale
{
    [Route("api/v1/website/ProductPublicCategory")]
    public partial class ProductPublicCategoryController : AbpControllerBase
    {
        private readonly IProductPublicCategoryAppService _appService;
        public ProductPublicCategoryController(IProductPublicCategoryAppService appService) { _appService = appService; }
    }
}