using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Accounting, Module: om_account_followup
    [Authorize]
    [Route("api/v1/accounting/FollowupStatByPartner")]
    public partial class FollowupStatByPartnerController : AbpController
    {
        private readonly IFollowupStatByPartnerAppService _appService;
        public FollowupStatByPartnerController(IFollowupStatByPartnerAppService appService) { _appService = appService; }
    }
}