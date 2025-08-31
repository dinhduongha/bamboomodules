using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteForum
{
    [Route("api/v1/website/ForumPost")]
    public partial class ForumPostController : AbpControllerBase
    {
        private readonly IForumPostAppService _appService;
        public ForumPostController(IForumPostAppService appService) { _appService = appService; }
    }
}