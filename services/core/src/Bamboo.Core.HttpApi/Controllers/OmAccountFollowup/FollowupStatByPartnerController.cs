using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.OmAccountFollowup
{
    [Route("api/v1/accounting/FollowupStatByPartner")]
    public partial class FollowupStatByPartnerController : AbpControllerBase
    {
        private readonly IFollowupStatByPartnerAppService _appService;
        public FollowupStatByPartnerController(IFollowupStatByPartnerAppService appService) { _appService = appService; }
    }
}