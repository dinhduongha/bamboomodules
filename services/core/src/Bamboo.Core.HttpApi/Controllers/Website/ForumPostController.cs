using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteForum
{
    [Route("api/v1/website/ForumPost")]
    public partial class ForumPostController : AbpController
    {
        private readonly IForumPostAppService _appService;
        public ForumPostController(IForumPostAppService appService) { _appService = appService; }
    }
}