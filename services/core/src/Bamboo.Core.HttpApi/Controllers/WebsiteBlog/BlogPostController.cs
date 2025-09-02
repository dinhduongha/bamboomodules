using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteBlog
{
    [Route("api/v1/website/BlogPost")]
    public partial class BlogPostController : AbpControllerBase
    {
        private readonly IBlogPostAppService _appService;
        public BlogPostController(IBlogPostAppService appService) { _appService = appService; }
    }
}