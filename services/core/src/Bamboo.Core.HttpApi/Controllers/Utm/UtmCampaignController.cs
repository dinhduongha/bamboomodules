using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Utm
{
    [Route("api/v1/utm/UtmCampaign")]
    public partial class UtmCampaignController : AbpControllerBase
    {
        private readonly IUtmCampaignAppService _appService;
        public UtmCampaignController(IUtmCampaignAppService appService) { _appService = appService; }
    }
}