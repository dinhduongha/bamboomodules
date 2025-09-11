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
    // Category: Website/Website, Module: website_sale_wishlist
    [Authorize]
    [Route("api/v1/website/ProductWishlist")]
    public partial class ProductWishlistController : AbpController
    {
        private readonly IProductWishlistAppService _appService;
        public ProductWishlistController(IProductWishlistAppService appService) { _appService = appService; }
    }
}