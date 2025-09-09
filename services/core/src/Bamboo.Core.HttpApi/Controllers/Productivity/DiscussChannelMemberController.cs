using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Mail
{
    [Route("api/v1/productivity/DiscussChannelMember")]
    public partial class DiscussChannelMemberController : AbpController
    {
        private readonly IDiscussChannelMemberAppService _appService;
        public DiscussChannelMemberController(IDiscussChannelMemberAppService appService) { _appService = appService; }
    }
}