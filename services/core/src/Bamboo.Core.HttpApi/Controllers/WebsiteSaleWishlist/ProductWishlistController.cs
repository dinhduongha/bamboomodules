using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteSaleWishlist
{
    [Route("api/v1/website/ProductWishlist")]
    public partial class ProductWishlistController : AbpControllerBase
    {
        private readonly IProductWishlistAppService _appService;
        public ProductWishlistController(IProductWishlistAppService appService) { _appService = appService; }
    }
}