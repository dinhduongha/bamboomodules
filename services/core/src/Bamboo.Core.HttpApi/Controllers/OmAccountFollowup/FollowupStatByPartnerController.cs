using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.OmAccountFollowup
{
    [Route("api/v1/accounting/FollowupStatByPartner")]
    public partial class FollowupStatByPartnerController : AbpControllerBase
    {
        private readonly IFollowupStatByPartnerAppService _appService;
        public FollowupStatByPartnerController(IFollowupStatByPartnerAppService appService) { _appService = appService; }
    }
}