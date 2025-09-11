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
    // Category: Website/Website, Module: website_blog
    [Authorize]
    [Route("api/v1/website/BlogPost")]
    public partial class BlogPostController : AbpController
    {
        private readonly IBlogPostAppService _appService;
        public BlogPostController(IBlogPostAppService appService) { _appService = appService; }
    }
}