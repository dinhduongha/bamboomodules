using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteForum
{
    [Route("api/v1/website/ForumForum")]
    public partial class ForumForumController : AbpController
    {
        private readonly IForumForumAppService _appService;
        public ForumForumController(IForumForumAppService appService) { _appService = appService; }
    }
}