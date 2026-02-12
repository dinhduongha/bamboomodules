using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    [NonController]
    [Authorize]
    [Route("api/v1/productivity/DiscussChannelMember")]
    public partial class DiscussChannelMemberController : AbpController
    {
        protected readonly IDiscussChannelMemberAppService _appService;
        public DiscussChannelMemberController(IDiscussChannelMemberAppService appService) { _appService = appService; }
        
        
    }
    
}