using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Accounting, Module: om_account_followup
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/accounting/FollowupStatByPartner")]
    public partial class FollowupStatByPartnerController : AbpController
    {
        private readonly IFollowupStatByPartnerAppService _appService;
        public FollowupStatByPartnerController(IFollowupStatByPartnerAppService appService) { _appService = appService; }
    }
}