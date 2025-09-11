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
    // Category: Marketing/Social Marketing, Module: marketing_card
    [Authorize]
    [Route("api/v1/marketing/CardCampaign")]
    public partial class CardCampaignController : AbpController
    {
        private readonly ICardCampaignAppService _appService;
        public CardCampaignController(ICardCampaignAppService appService) { _appService = appService; }
    }
}