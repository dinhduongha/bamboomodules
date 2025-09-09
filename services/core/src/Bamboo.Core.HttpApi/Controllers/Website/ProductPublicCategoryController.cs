using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteSale
{
    [Route("api/v1/website/ProductPublicCategory")]
    public partial class ProductPublicCategoryController : AbpController
    {
        private readonly IProductPublicCategoryAppService _appService;
        public ProductPublicCategoryController(IProductPublicCategoryAppService appService) { _appService = appService; }
    }
}