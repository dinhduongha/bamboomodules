using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.MarketingCard
{
    [Route("api/v1/marketing/CardCampaign")]
    public partial class CardCampaignController : AbpController
    {
        private readonly ICardCampaignAppService _appService;
        public CardCampaignController(ICardCampaignAppService appService) { _appService = appService; }
    }
}