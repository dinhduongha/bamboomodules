using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteBlog
{
    [Route("api/v1/website/BlogBlog")]
    public partial class BlogBlogController : AbpController
    {
        private readonly IBlogBlogAppService _appService;
        public BlogBlogController(IBlogBlogAppService appService) { _appService = appService; }
    }
}