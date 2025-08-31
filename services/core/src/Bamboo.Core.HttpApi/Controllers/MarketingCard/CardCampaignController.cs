using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.MarketingCard
{
    [Route("api/v1/marketing/CardCampaign")]
    public partial class CardCampaignController : AbpControllerBase
    {
        private readonly ICardCampaignAppService _appService;
        public CardCampaignController(ICardCampaignAppService appService) { _appService = appService; }
    }
}