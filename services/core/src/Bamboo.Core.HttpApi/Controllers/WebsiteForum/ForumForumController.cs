using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteForum
{
    [Route("api/v1/website/ForumForum")]
    public partial class ForumForumController : AbpControllerBase
    {
        private readonly IForumForumAppService _appService;
        public ForumForumController(IForumForumAppService appService) { _appService = appService; }
    }
}