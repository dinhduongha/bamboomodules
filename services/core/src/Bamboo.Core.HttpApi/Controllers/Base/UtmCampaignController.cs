using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Utm
{
    [Route("api/v1/utm/UtmCampaign")]
    public partial class UtmCampaignController : AbpController
    {
        private readonly IUtmCampaignAppService _appService;
        public UtmCampaignController(IUtmCampaignAppService appService) { _appService = appService; }
    }
}