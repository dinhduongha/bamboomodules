using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteBlog
{
    [Route("api/v1/website/BlogPost")]
    public partial class BlogPostController : AbpControllerBase
    {
        private readonly IBlogPostAppService _appService;
        public BlogPostController(IBlogPostAppService appService) { _appService = appService; }
    }
}