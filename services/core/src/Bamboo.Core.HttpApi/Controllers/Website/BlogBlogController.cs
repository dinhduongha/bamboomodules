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
    [Route("api/v1/website/BlogBlog")]
    public partial class BlogBlogController : AbpController
    {
        private readonly IBlogBlogAppService _appService;
        public BlogBlogController(IBlogBlogAppService appService) { _appService = appService; }
    }
}