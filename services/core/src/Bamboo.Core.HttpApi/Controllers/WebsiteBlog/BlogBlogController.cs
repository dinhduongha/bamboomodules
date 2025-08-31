using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteBlog
{
    [Route("api/v1/website/BlogBlog")]
    public partial class BlogBlogController : AbpControllerBase
    {
        private readonly IBlogBlogAppService _appService;
        public BlogBlogController(IBlogBlogAppService appService) { _appService = appService; }
    }
}