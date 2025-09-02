using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteForum
{
    [Route("api/v1/website/ForumPost")]
    public partial class ForumPostController : AbpControllerBase
    {
        private readonly IForumPostAppService _appService;
        public ForumPostController(IForumPostAppService appService) { _appService = appService; }
    }
}