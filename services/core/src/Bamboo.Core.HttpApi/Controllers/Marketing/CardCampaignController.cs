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
    // Category: Marketing/Social Marketing, Module: marketing_card
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/marketing/CardCampaign")]
    public partial class CardCampaignController : AbpController
    {
        private readonly ICardCampaignAppService _appService;
        public CardCampaignController(ICardCampaignAppService appService) { _appService = appService; }
    }
}