using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteSaleWishlist
{
    [Route("api/v1/website/ProductWishlist")]
    public partial class ProductWishlistController : AbpControllerBase
    {
        private readonly IProductWishlistAppService _appService;
        public ProductWishlistController(IProductWishlistAppService appService) { _appService = appService; }
    }
}