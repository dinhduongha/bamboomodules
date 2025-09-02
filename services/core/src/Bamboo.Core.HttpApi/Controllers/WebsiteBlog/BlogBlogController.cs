using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteBlog
{
    [Route("api/v1/website/BlogBlog")]
    public partial class BlogBlogController : AbpControllerBase
    {
        private readonly IBlogBlogAppService _appService;
        public BlogBlogController(IBlogBlogAppService appService) { _appService = appService; }
    }
}