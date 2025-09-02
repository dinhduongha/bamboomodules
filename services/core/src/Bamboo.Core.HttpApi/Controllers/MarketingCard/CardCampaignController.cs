using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.MarketingCard
{
    [Route("api/v1/marketing/CardCampaign")]
    public partial class CardCampaignController : AbpControllerBase
    {
        private readonly ICardCampaignAppService _appService;
        public CardCampaignController(ICardCampaignAppService appService) { _appService = appService; }
    }
}