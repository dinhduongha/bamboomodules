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
    // Category: Website/Website, Module: website_sale
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/website/ProductPublicCategory")]
    public partial class ProductPublicCategoryController : AbpController
    {
        private readonly IProductPublicCategoryAppService _appService;
        public ProductPublicCategoryController(IProductPublicCategoryAppService appService) { _appService = appService; }
    }
}