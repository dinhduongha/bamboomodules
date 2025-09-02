using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Utm
{
    [Route("api/v1/utm/UtmCampaign")]
    public partial class UtmCampaignController : AbpControllerBase
    {
        private readonly IUtmCampaignAppService _appService;
        public UtmCampaignController(IUtmCampaignAppService appService) { _appService = appService; }
    }
}